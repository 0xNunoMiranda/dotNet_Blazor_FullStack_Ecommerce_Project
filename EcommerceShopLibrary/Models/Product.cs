using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceShopLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0.1,99999.99)]
        public Decimal Price { get; set; }
        [Required, DisplayName("Product Image")]
        public string? Base64Img { get; set; }
        [Required, Range(0,9999999)]
        public int Quantity { get; set; }
        public bool Featured { get; set; } = false;
        public DateTime DateUploaded { get; set; } = DateTime.Now;
    }
}
