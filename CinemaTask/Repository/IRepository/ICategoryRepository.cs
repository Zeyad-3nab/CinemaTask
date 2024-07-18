using CinemaTask.Models;

namespace CinemaTask.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public List<Movie> GetMovieWithCategory(int id);
    }
}
