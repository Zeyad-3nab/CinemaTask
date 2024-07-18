using CinemaTask.Data;
using CinemaTask.Models;
using CinemaTask.Repository.IRepository;

namespace CinemaTask.Repository
{
    public class ActorRepository : IActorRepository
    {

        private readonly ApplicationDbContext context;

        public ActorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Actor actor)
        {
            context.actors.Add(actor);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var actor = context.actors.Find(id);
            context.actors.Remove(actor);
            context.SaveChanges();
        }

        public List<Actor> GetAll()
        {
            return context.actors.ToList();
        }

        public Actor GetById(int id)
        {
            var actor = context.actors.Find(id);
            return actor;
        }

        public void Update(Actor actor)
        {
            context.actors.Update(actor);
            context.SaveChanges();
        }
    }
}
