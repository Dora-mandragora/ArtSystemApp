using System.ComponentModel.DataAnnotations;

namespace ArtSystemApp.ViewModels
{
    public class AddSubscriptionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }       
    }
}
