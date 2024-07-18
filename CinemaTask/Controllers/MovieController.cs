using CinemaTask.Models;
using CinemaTask.Repository.IRepository;
using CinemaTask.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTask.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IActorMovieRepository actorMovieRepository;
        private readonly ICinemaRepository cinemaRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IActorRepository actorRepository;

        public MovieController(IMovieRepository movieRepository,IActorMovieRepository actorMovieRepository ,ICinemaRepository cinemaRepository , ICategoryRepository categoryRepository,IActorRepository actorRepository)
        {
            this.movieRepository = movieRepository;
            this.actorMovieRepository = actorMovieRepository;
            this.cinemaRepository = cinemaRepository;
            this.categoryRepository = categoryRepository;
            this.actorRepository = actorRepository;
        }
        public IActionResult Index()
        {
            var result = movieRepository.GetMovieWithCinemaAndCategoryAnd();

            return View(result);

        }


        [HttpGet]
        public IActionResult Create() 
        {
            var cinemas = cinemaRepository.GetAll();
            var categories = categoryRepository.GetAll();
            ViewData["categories"] = categories;
            ViewData["cinemas"] = cinemas;
            return View();
        }


        [HttpPost]
        public IActionResult Create(MovieVM movieVM)
        {
            if (ModelState.IsValid) 
            {
                Movie movie = new Movie()
                {
                    Name = movieVM.Name,
                    Description = movieVM.Description,
                    Price = movieVM.Price,
                    ImgUrl = movieVM.ImgUrl,
                    TrailerUrl = movieVM.TrailerUrl,
                    StartDate = movieVM.StartDate,
                    EndDate = movieVM.EndDate,
                    CategoryId = movieVM.CategoryId,
                    CinemaId = movieVM.CinemaId,
                };
                movieRepository.Add(movie);
                return RedirectToAction("Index", "Movie");
            }
            return View(movieVM);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result =movieRepository.GetById(id);
            var cinemas = cinemaRepository.GetAll();
            var categories = categoryRepository.GetAll();
            ViewData["categories"] = categories;
            ViewData["cinemas"] = cinemas;
            return View(result);
        }


        [HttpPost]
        public IActionResult Edit(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie()
                {
                    Id=movieVM.Id,
                    Name = movieVM.Name,
                    Description = movieVM.Description,
                    Price = movieVM.Price,
                    ImgUrl = movieVM.ImgUrl,
                    TrailerUrl = movieVM.TrailerUrl,
                    StartDate = movieVM.StartDate,
                    EndDate = movieVM.EndDate,
                    CategoryId = movieVM.CategoryId,
                    CinemaId = movieVM.CinemaId,
                };
                movieRepository.Update(movie);
                return RedirectToAction("Index", "Movie");
            }
            return View(movieVM);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = movieRepository.GetById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var result = movieRepository.GetAllById(id);
            return View(result);
        }
        public IActionResult Search(string name) 
        {
            var result = movieRepository.SearchByName(name);
            if (result == null)
            {
                return View();
            }
            else 
            {
            return RedirectToAction("Details","Movie", new { id=result.Id});
            }

        }


        [HttpGet]
        public IActionResult AddActorToMovie(int  MovieId) 
        {
            var result = movieRepository.GetById(MovieId);
            ViewData["movie"] = result; 
            ViewData["actors"] = actorRepository.GetAll();
            return View();

            }

        [HttpPost]
        public IActionResult AddActorToMovie(actorMoviesVM actorMoviesVM)
        {
            actorMovies actorMovies=new actorMovies() 
            {
                movieId=actorMoviesVM.movieId,
                actorId=actorMoviesVM.actorId
            };
            actorMovieRepository.AddActorsToMovie(actorMovies);
            return RedirectToAction("Index", "Movie");

        }


    }
}
