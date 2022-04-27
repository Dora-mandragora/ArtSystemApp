using System.ComponentModel.DataAnnotations;

namespace ArtSystemApp.ViewModels
{
    public class RegisterModel
    {        
        [EmailAddress]
        [Required(ErrorMessage = "Поле \"Email\" обязательно для заполнения")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле \"Логин\" обязательно для заполнения")]
        public string Login { get; set; }

        [DataType(DataType.Password)]  
        [MinLength(4)]
        [Required(ErrorMessage = "Поле \"Пароль\" обязательно для заполнения")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
