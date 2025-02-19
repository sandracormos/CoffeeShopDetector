namespace CoffeeShopDetector
{
    internal class CsvLocalFilePathRepository : Repository<CoffeeShop>
    {
        public override List<CoffeeShop> GetAll()
        {
            if (elements != null)
            {
                return elements;
            }
            throw new Exception("List is empty");
        }

        public override CoffeeShop GetAt(int index)
        {
            if (index < 0 || index >= elements.Count)
                throw new IndexOutOfRangeException();

            return elements[index];
        }
        //Initializes the application by reading CSV data from the specified file path
        public override void Initialize(string filePath)
        {
            var csvData = string.Empty;
            try
            {
                csvData = File.ReadAllText(filePath);

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file at path '{filePath}' was not found.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(1);
            }
            LoadFromCsvString(csvData);
        }
        //Parses the provided CSV data and creates CoffeeShop objects from each valid line
        // Each line is split into fields and validated to ensure it contains exactly 3 values (name, x, y)
        protected void LoadFromCsvString(string csvData)
        {
            if (string.IsNullOrEmpty(csvData))
                return;

            foreach (var line in csvData.Split('\n'))
            {
                var fields = line.Split(',');
                if (fields.Length == 3 && Double.TryParse(fields[1], out var x) && Double.TryParse(fields[2], out var y))
                {
                    elements.Add(new CoffeeShop(x, y, Name: fields[0]));
                }
                else
                {
                    throw new Exception("Invalid data format");
                }
            }
        }
    }
}
