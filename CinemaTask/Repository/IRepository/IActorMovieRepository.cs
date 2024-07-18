using CinemaTask.Models;

namespace CinemaTask.Repository.IRepository
{
    public interface IActorMovieRepository
    {
        public void AddActorsToMovie(actorMovies actorMovies);
    }
}
