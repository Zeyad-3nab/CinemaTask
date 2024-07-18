using CinemaTask.Models;
using CinemaTask.Repository.IRepository;
using CinemaTask.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTask.Controllers
{
    public class ActorController : Controller
    {

        private readonly IActorRepository actorRepository;

        public ActorController(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }
        public IActionResult Index()
        {
            var result = actorRepository.GetAll();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var result = actorRepository.GetById(id);
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ActorVM actorVM)
        {
            if (ModelState.IsValid) 
            {
                Actor actor = new Actor()
                {
                    FirstName = actorVM.FirstName,
                    LastName = actorVM.LastName,
                    ProfilePicture = actorVM.ProfilePicture,
                    Bio = actorVM.Bio,
                    News = actorVM.News
                };
                actorRepository.Add(actor);
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result=actorRepository.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(ActorVM actorVM)
        {
            if (ModelState.IsValid) 
            {
                Actor actor = new Actor()
                {
                    Id = actorVM.Id,
                    FirstName = actorVM.FirstName,
                    LastName = actorVM.LastName,
                    ProfilePicture = actorVM.ProfilePicture,
                    Bio = actorVM.Bio,
                    News = actorVM.News,
                };
                actorRepository.Update(actor);
                return RedirectToAction("Index", "Actor");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = actorRepository.GetById(id);
            if (result != null)
                return View(result);
            else
                return RedirectToAction("Index", "Actor");
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
             actorRepository.Delete(id);
            return RedirectToAction("Index", "Actor");
        }
    }
}
