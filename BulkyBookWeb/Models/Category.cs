using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name should be between 5 to 50 length")]
        public string Name { get; set; }

        [Required]

        [DisplayName("Display Order")]

        [Range(1, 100, ErrorMessage = "range between 100")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
