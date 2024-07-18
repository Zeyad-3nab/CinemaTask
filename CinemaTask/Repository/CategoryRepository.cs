using CinemaTask.Data;
using CinemaTask.Models;
using CinemaTask.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CinemaTask.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Category category)
        {
            context.categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = context.categories.Find(id);
            context.categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.categories.ToList();
        }

        public Category GetById(int id)
        {
            var category = context.categories.Find(id);
            return category;
        }

        public void Update(Category category)
        {
            context.categories.Update(category);
            context.SaveChanges();
        }
        public List<Movie> GetMovieWithCategory(int id)
        {
            var result = context.movies.Include(e => e.Category).Include(e => e.Cinema).Where(e => e.CategoryId == id).ToList();
            return result;
        }
    }
}
