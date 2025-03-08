namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal? Salary { get; set; }
        public string Dept { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
