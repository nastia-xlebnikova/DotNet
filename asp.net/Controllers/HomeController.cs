using Microsoft.AspNetCore.Mvc;

namespace khlebnikova
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var students = DataStudents.students;

            return View(students);
        }
    }
}