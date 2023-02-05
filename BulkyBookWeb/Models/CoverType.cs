using BulkyBookWeb.Data.Repository.IRepository;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class CoverType: IBaseRepository
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(100, ErrorMessage = "Limited to 100 ")]
        public string Name { get; set; }
    }
}
