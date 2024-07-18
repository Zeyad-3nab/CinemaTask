using CinemaTask.Models;

namespace CinemaTask.Repository.IRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public List<Movie> GetAllById(int id);
        public List<Movie> GetMovieWithCinemaAndCategoryAnd();
        public Movie SearchByName(string name);

    }
}
