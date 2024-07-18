using CinemaTask.Data;
using CinemaTask.Models;
using CinemaTask.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MovieTask.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext context;

        public MovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Movie movie)
        {
            if (movie.StartDate < DateTime.Now && movie.EndDate > DateTime.Now)
            {
                movie.MovieStatus = (MovieStatus)1;
            }
            else if (movie.StartDate > DateTime.Now)
            {
                movie.MovieStatus = (MovieStatus)0;
            }
            else
            {
                movie.MovieStatus = (MovieStatus)2;

            }
            context.movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = context.movies.Find(id);
            context.movies.Remove(movie);
            context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return context.movies.ToList();
        }

        public List<Movie> GetAllById(int id)
        {
            var movie = context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.Actors).Where(e => e.Id == id).ToList();
           
            return movie;
        }

        public void Update(Movie movie)
        {
            if (movie.StartDate < DateTime.Now && movie.EndDate > DateTime.Now)
            {
                movie.MovieStatus = (MovieStatus)1;
            }
            else if (movie.StartDate > DateTime.Now)
            {
                movie.MovieStatus = (MovieStatus)0;
            }
            else
            {
                movie.MovieStatus = (MovieStatus)2;

            }
            context.movies.Update(movie);
            context.SaveChanges();
        }

        public List<Movie> GetMovieWithCinemaAndCategoryAnd()
        {
            var movies = context.movies.Include(e => e.Cinema).Include(e => e.Category).ToList();
            context.SaveChanges();
            return movies;
        }

        public Movie GetById(int id)
        {
            var result = context.movies.Find(id);
            return result;
        }

        public Movie SearchByName(string name)
        {
            var result=context.movies.FirstOrDefault(e=>e.Name==name);
            return result;
        }
    }
}
