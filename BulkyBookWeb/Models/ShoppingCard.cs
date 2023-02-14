using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class ShoppingCard
    {
        public Product Product { get; set; }
        [Range(1, 1000, ErrorMessage = "please enter value bwterrn 1 and 1000")]
        public int Count { get; set; }
    }
}
