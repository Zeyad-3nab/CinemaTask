using Azure;
using CinemaTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CinemaTask.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CinemaTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        public DbSet<Category> categories { set; get; }
        public DbSet<Movie> movies { set; get; }
        public DbSet<Cinema> cinemas { set; get; }
        public DbSet<Actor> actors { set; get; }
        public DbSet<actorMovies> actorMovies { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>()
        .HasMany(e => e.Movies)
        .WithMany(e => e.Actors)
        .UsingEntity<actorMovies>();
        }
        public DbSet<CinemaTask.ViewModels.ActorVM> ActorVM { get; set; } = default!;
        public DbSet<CinemaTask.ViewModels.ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
    }
}