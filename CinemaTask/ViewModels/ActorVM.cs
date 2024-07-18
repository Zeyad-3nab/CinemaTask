namespace CinemaTask.ViewModels
{
    public class ActorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string ProfilePicture { get; set; } = null!;
        public string? News { get; set; }
    }
}
