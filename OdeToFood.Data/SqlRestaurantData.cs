namespace OdeToFood.Data
{
    using Microsoft.EntityFrameworkCore;
    using OdeToFood.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _db.Add(newRestaurant);
            return newRestaurant;
        }

        public int commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                _db.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantByBame(string name)
        {
            return from r in _db.Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.CurrentCulture)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var query = _db.Restaurants.Attach(updateRestaurant);
            query.State = EntityState.Modified;
            return updateRestaurant;
        }
    }
}