using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Contollers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData resData)
        {
            _restaurantData = resData;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rest = new Restaurant();
                rest.Name = model.Name;
                rest.Cuisine = model.Cuisine;
                _restaurantData.Add(rest);
                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = rest.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id,RestaurantEditViewModel model)
        {
            var rest = _restaurantData.Get(id);

            if (rest != null && ModelState.IsValid)
            {
                rest.Name = model.Name;
                rest.Cuisine = model.Cuisine;
                _restaurantData.Commit();

                return RedirectToAction("Details", new { id = rest.Id });
            }
            return View(rest);
        }

        public IActionResult Delete(int id) {

            var rest = _restaurantData.Get(id);

            if (ModelState.IsValid && rest != null)
            {
                _restaurantData.Delete(rest);
                _restaurantData.Commit();
                return RedirectToAction("Index");
            }
            return View(rest);
        }
    }
}
