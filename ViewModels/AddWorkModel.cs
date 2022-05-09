using Microsoft.AspNetCore.Http;

namespace ArtSystemApp.ViewModels
{
    public class AddWorkModel
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public IFormFile Image { get; set; }
        public int Access { get; set; }
    }
}
