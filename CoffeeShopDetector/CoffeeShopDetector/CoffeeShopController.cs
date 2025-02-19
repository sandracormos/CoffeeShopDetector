using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDetector
{
    internal class CoffeeShopController
    {
        Repository<CoffeeShop> repository;

        public CoffeeShopController(Repository<CoffeeShop> repository)
        {
            this.repository = repository;
        }

        //Finds the top 3 nearest CoffeeShops to the given user location
        public List<(CoffeeShop, double Distance)> FindClosestCoffeeShops(Location userLocation, int coffeeShopCount)
        {
            List<(CoffeeShop, double Distance)> CoffeeShopsNearMe = new List<(CoffeeShop, double Distance)>();

            foreach (var shop in repository.GetAll())
            {
                var cs = userLocation.DistanceToCoffeeShop(shop);
                CoffeeShopsNearMe.Add((shop, cs));
            }

            return CoffeeShopsNearMe.OrderBy(t => t.Item2).Take(3).ToList();
        }
    }
}
