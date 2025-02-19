using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoffeeShopDetector
{
    internal class CsvRepository : Repository<CoffeeShop>
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

        public override void Initialize(string filePath)
        {
            var csvData = File.ReadAllText(filePath);
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
