using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByBame(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant Update(Restaurant updateRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int CountRestaurant();

        int commit();
    }
}