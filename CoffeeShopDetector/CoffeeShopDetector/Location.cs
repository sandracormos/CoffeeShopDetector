namespace CoffeeShopDetector
{
    internal class Location
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }

        public Location(double coordinateX, double coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        //Calculate Distance using Euclidean Distance Formula
        public double DistanceToCoffeeShop(CoffeeShop coffeeShop)
        {

            var deltaX = this.CoordinateX - coffeeShop.X;
            var deltaY = this.CoordinateY - coffeeShop.Y;

            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}
