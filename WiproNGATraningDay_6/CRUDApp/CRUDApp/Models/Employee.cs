using System.ComponentModel.DataAnnotations;

namespace CRUDApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }
    }
}
