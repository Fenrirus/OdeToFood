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
                new Restaurant {Id = 1, Name = "Żabusia", Cusine = Restaurant.CusineType.Poland, Location ="Żabianka"},
                new Restaurant {Id = 2, Name = "Pueblo", Cusine = Restaurant.CusineType.Mexican, Location ="Centrum"},
                new Restaurant {Id = 3, Name = "Johns Pizza", Cusine = Restaurant.CusineType.Italian, Location ="Przymorze"},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}