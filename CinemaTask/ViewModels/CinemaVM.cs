namespace CinemaTask.ViewModels
{
    public class CinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? CinemaLogo { get; set; } 
        public string Address { get; set; } = null!;
    }
}
