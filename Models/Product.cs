using System.ComponentModel.DataAnnotations;

namespace BlazorWithDB.Models
{
    public class Product
    {
        public int Product_ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Product name is too long.")]
        public string P_name { get; set; }

        public int Category_ID { get; set; }
    }
}
