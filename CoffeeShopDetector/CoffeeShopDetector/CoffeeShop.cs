
namespace CoffeeShopDetector
{
    internal class CoffeeShop
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public string Name { get; private set; }

        public CoffeeShop(double CoordinateX, double CoordinateY, string Name)
        {
            this.X = CoordinateX;
            this.Y = CoordinateY;
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"{Name} {X} {Y}";
        }
    }
}
