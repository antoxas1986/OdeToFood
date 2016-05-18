using OdeToFood.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OdeToFood.Services
{
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant rest);
        int Commit();
        void Delete(Restaurant rest);
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public void Add(Restaurant rest)
        {
            _context.Add(rest);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(Restaurant rest)
        {
            _context.Remove(rest);
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant> {
                new Restaurant {Id = 1, Name = "Tersiguel's"},
                new Restaurant {Id = 2, Name = "Lj's and the Kat"},
                new Restaurant {Id = 3, Name = "King's Contrivance"},
                new Restaurant {Id = 4, Name = "Burger King"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant rest)
        {
            rest.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(rest);
        }

        public int Commit()
        {
            return 0;
        }

        public void Delete(Restaurant rest)
        {
            _restaurants.Remove(rest);

        }
    }
}
