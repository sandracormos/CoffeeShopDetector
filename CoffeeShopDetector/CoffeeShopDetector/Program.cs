using CoffeeShopDetector;




const int CoffeeShopCount = 3;

var splitInput = Console.ReadLine().Split(" ");

//Check if data is in correct format
if(splitInput.Length == 3 && Double.TryParse(splitInput[0], out double inputX) && Double.TryParse(splitInput[1], out double inputY))
{
    Repository<CoffeeShop> repository = null;

    //Check if file exists on the computer
    if (File.Exists(splitInput[2]))
    {
        repository = new CsvLocalFilePathRepository();
    }
    //check if url is valid
    else if (splitInput[2].IsValidHttpUrl())
    {
        repository = new CsvHttpRequestRepository();
    }
    else
    {
        CancelApplicationOnWrongInput();
    }

    repository?.Initialize(splitInput[2]);       
    
    var userLocation = new Location(inputX, inputY);
    CoffeeShopController controller = new CoffeeShopController(repository);
    foreach (var coffeShopAndDistance in controller.FindClosestCoffeeShops(userLocation, CoffeeShopCount))
    {
        var shopName = coffeShopAndDistance.Item1.Name;
        var distance = coffeShopAndDistance.Item2;
        Console.WriteLine($"{shopName}, {distance.ToString(distance % 1 == 0 ? "0" : "0.0000")}");
    }    
}
else
{
    CancelApplicationOnWrongInput();
}

void CancelApplicationOnWrongInput()
{
    Console.WriteLine("Error: Wrong input. The program requires exactly three values separated by spaces.");
    Console.WriteLine("Press any key to exit the program...");
    Console.ReadKey();
    Environment.Exit(1);
}