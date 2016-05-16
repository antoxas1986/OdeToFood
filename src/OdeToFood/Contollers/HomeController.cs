using Microsoft.AspNet.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Contollers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData resData)
        {
            _restaurantData = resData;
        }
        public ViewResult Index() {
            var model = _restaurantData.GetAll();
            return View(model);
        }
    }
}
