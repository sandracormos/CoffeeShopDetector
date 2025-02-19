using CoffeeShopDetector;

const int CoffeeShopCount = 3;
var splitInput = "47.6 -122.4 coffee_shops.csv".Split(" ");

var repo = new CsvRepository();
repo.Initialize(splitInput[2]);

if (Double.TryParse(splitInput[0], out double inputX) && Double.TryParse(splitInput[1], out double inputY))
{
    var userLocation = new Location(inputX, inputY);
    CoffeeShopController controller = new CoffeeShopController(repo);
    foreach (var coffeShopAndDistance in controller.FindClosestCoffeeShops(userLocation, CoffeeShopCount))
    {
        var shopName = coffeShopAndDistance.Item1.Name;
        var distance = coffeShopAndDistance.Item2;
        Console.WriteLine($"{shopName}, {distance.ToString(distance % 1 == 0 ? "0" : "0.0000")}");
    }
}