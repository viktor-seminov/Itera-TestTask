using IteraTestTask.Models;
using IteraTestTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IteraTestTask.Controllers
{
    public class HomeController : Controller
    {
        IEntityRepository entityRepo;

        public HomeController(IEntityRepository repo)
        {
            entityRepo = repo;// new EntityRepository();
        }

        public ActionResult Index(string dishName, int? count, SortState sortOrder = SortState.IdAsc)
        {
            var orders = entityRepo.List();

            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["DishNameSort"] = sortOrder == SortState.DishNameAsc ? SortState.DishNameDesc : SortState.DishNameAsc;
            ViewData["CountSort"] = sortOrder == SortState.CountAsc ? SortState.CountDesc : SortState.CountAsc;

            switch (sortOrder)
            {
                case SortState.IdDesc:
                    orders = orders.OrderByDescending(s => s.Id);
                    break;
                case SortState.DishNameAsc:
                    orders = orders.OrderBy(s => s.DishName);
                    break;
                case SortState.DishNameDesc:
                    orders = orders.OrderByDescending(s => s.DishName);
                    break;
                case SortState.CountAsc:
                    orders = orders.OrderBy(s => s.Count);
                    break;
                case SortState.CountDesc:
                    orders = orders.OrderByDescending(s => s.Count);
                    break;
                default:
                    orders = orders.OrderBy(s => s.Id);
                    break;
            }

            if (dishName != null && dishName != string.Empty)
            {
                orders = orders.Where(p => p.DishName.ToLower().Contains(dishName));
            }
            if (count != null && count != 0)
            {
                orders = orders.Where(p => p.Count == count);
            }

            DishesOrdersViewModel viewModel = new DishesOrdersViewModel
            {
                FoodOrders = orders,
                DishNameFilter = string.Empty,
                CountFilter = 0
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            var foodOrder = entityRepo.Get(id);

            if (foodOrder != null)
            {
                return View("EditFoodOrder", foodOrder);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                entityRepo.Update(foodOrder);
                return RedirectToAction("Index");
            }
            return View("EditFoodOrder", foodOrder);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var foodOrder = entityRepo.Get(id);

            if(foodOrder != null)
            {
                return View("DeleteFoodOrder", foodOrder);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(FoodOrder foodOrder)
        {
            entityRepo.Delete(foodOrder);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateFoodOrder");
        }

        [HttpPost]
        public ActionResult Create(FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                entityRepo.Create(foodOrder);
                return RedirectToAction("Index");
            }
            return View("CreateFoodOrder", foodOrder);
        }
    }
}