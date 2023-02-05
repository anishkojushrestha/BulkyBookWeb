using BulkyBookWeb.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookWeb.Models
{
    public class Product:IBaseRepository
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "range between 100")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "range between 100")]
        public double Price { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "range between 100")]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "range between 100")]
        public double Price100 { get; set; }

        [ValidateNever]
        public string Image { get; set; }

        //Relationship
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category Category { get; set; }  

        public int CoverTypeId { get; set; }
        [ForeignKey(nameof(CoverTypeId))]
        [ValidateNever]
        public CoverType CoverType { get; set; }

    }
}
