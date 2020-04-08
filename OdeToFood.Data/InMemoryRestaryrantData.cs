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
                new Restaurant {Id = 1, Name = "Żabusia", Cuisine = CusineType.Poland, Location ="Żabianka"},
                new Restaurant {Id = 2, Name = "Pueblo", Cuisine = CusineType.Mexican, Location ="Centrum"},
                new Restaurant {Id = 3, Name = "Johns Pizza", Cuisine = CusineType.Italian, Location ="Przymorze"},
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(m => m.Id) + 1;
            return newRestaurant;
        }

        public int commit()
        {
            return 0;
        }

        public int CountRestaurant()
        {
            return restaurants.Count();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(f => f.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantByBame(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, System.StringComparison.CurrentCulture)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(s => s.Id == id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(s => s.Id == updateRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}