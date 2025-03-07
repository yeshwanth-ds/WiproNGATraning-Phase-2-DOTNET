using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>(); // Temporary in-memory list

        // Show the form to add a new student
        public IActionResult Add()
        {
            return View();
        }

        // Handle form submission and add student
        [HttpPost]
        public IActionResult Add(Student student)
        {
            students.Add(student); // Add student to list
            return RedirectToAction("List"); // Redirect to the list view
        }

        // Display the list of students
        public IActionResult List()
        {
            return View(students);
        }
    }
}
