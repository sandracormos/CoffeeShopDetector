using System.Text.RegularExpressions;

namespace CoffeeShopDetector
{
    internal static  class StringExtensions
    {
        //Validates if the input string is a properly formatted HTTP or HTTPS URL using a regular expression
        public static bool IsValidHttpUrl(this string input)
        {
            //regex pattern for a valid HTTP/HTTPS URL
            string pattern = @"^(https?:\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(:[0-9]{1,5})?(\/[^\s]*)?$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
