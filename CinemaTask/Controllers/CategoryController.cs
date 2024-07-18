using CinemaTask.Models;
using CinemaTask.Repository;
using CinemaTask.Repository.IRepository;
using CinemaTask.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTask.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var result = categoryRepository.GetAll();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var result = categoryRepository.GetMovieWithCategory(id);
            if(result.Count!=0)
            return View(result);
            else return RedirectToAction("Search","Movie");
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Name = categoryVM.Name
                };
                categoryRepository.Add(category);
                TempData["alert"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = categoryRepository.GetById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Id = categoryVM.Id,
                    Name = categoryVM.Name
                };
                categoryRepository.Update(category);
                TempData["alert"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = categoryRepository.GetById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            categoryRepository.Delete(id);
            TempData["alert"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
