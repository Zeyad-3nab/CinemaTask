using CinemaTask.Data;
using CinemaTask.Models;
using CinemaTask.Repository.IRepository;

namespace CinemaTask.Repository
{
    public class ActorMovieRepository : IActorMovieRepository
    {
        private readonly ApplicationDbContext context;

        public ActorMovieRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddActorsToMovie(actorMovies actorMovies)
        {

            context.actorMovies.Add(actorMovies);
            context.SaveChanges();
        }
    }
}
