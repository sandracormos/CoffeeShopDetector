using System.IO.Compression;
using System.Net;

namespace CoffeeShopDetector
{
    internal class CsvHttpRequestRepository : CsvLocalFilePathRepository
    {
        public override void Initialize(string filePath)
        {
            string csvData = GetCoffeeShopsCsvAsync(filePath).Result;
            LoadFromCsvString(csvData);
        }


        // Fetches a CSV file of coffeeshops from the given url
        // It checks if the response content is GZIP compressed and decompresses it if its necessary
        // If the content is not compressed, it reads the response as plain text
        private async Task<string> GetCoffeeShopsCsvAsync(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Check if the content is compressed using GZIP
                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        string result = await streamReader.ReadToEndAsync();
                        return result;
                    }
                }
                else
                {
                    // If not compressed read as usual
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            else
            {
                throw new HttpRequestException($"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }
    }
}
