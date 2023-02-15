using BulkyBookWeb.Data.Repository.IRepository;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Company:IBaseRepository
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
