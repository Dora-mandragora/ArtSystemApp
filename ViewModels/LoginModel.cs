using System.ComponentModel.DataAnnotations;

namespace ArtSystemApp.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Все поля обязательны для заполнения")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Все поля обязательны для заполнения")]
        [DataType(DataType.Password)]                
        public string Password { get; set; }

    }
}
