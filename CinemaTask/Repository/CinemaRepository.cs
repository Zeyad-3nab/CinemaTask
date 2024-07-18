using CinemaTask.Data;
using CinemaTask.Models;
using CinemaTask.Repository.IRepository;

namespace CinemaTask.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext context;

        public CinemaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Cinema cinema)
        {
            context.cinemas.Add(cinema);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cinema = context.cinemas.Find(id);
            context.cinemas.Remove(cinema);
            context.SaveChanges();
        }

        public List<Cinema> GetAll()
        {
            return context.cinemas.ToList();
        }

        public Cinema GetById(int id)
        {
            var cinema = context.cinemas.Find(id);
            return cinema;
        }

        public void Update(Cinema cinema)
        {
            context.cinemas.Update(cinema);
            context.SaveChanges();
        }
    }
}
