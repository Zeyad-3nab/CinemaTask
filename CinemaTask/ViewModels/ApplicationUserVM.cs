using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaTask.ViewModels
{
    public class ApplicationUserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;



        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;



        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirmed Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
