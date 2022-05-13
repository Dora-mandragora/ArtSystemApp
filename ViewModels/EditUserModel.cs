using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArtSystemApp.ViewModels
{
    public class EditUserModel
    {
        public string Login { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
