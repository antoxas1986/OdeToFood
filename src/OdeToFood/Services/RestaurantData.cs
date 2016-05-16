
using OdeToFood.Models;
using System.Collections.Generic;
using System;

namespace OdeToFood.Services
{
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant> {
                new Restaurant {Id = 1, Name="Tersiguel's"},
                new Restaurant {Id = 2, Name="Lj's and the Kat"},
                new Restaurant {Id = 3, Name="King's Contrivance"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
