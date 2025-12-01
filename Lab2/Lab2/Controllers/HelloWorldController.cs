using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Lab2.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View(); // Gọi View Template
        }
        public IActionResult Welcome(string name, int numTimes = 1, int id = 0)
        {
            ViewData["Message"] = "Hello " + (name ?? "World"); // Thêm giá trị mặc định cho name để tránh "Hello "

            
            ViewData["NumTimes"] = id;

            return View();
        }
        public string WelcomeWithId(string name, int numTimes = 1, int id = 0)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {id}, NumTimes is: {numTimes}");
        }
    }
}