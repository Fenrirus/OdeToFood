using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaryrantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaryrantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Żabusia", Cuisine = Restaurant.CusineType.Poland, Location ="Żabianka"},
                new Restaurant {Id = 2, Name = "Pueblo", Cuisine = Restaurant.CusineType.Mexican, Location ="Centrum"},
                new Restaurant {Id = 3, Name = "Johns Pizza", Cuisine = Restaurant.CusineType.Italian, Location ="Przymorze"},
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByBame(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(s => s.Id == id);
        }
    }
}