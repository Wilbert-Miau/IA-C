using IACAST_WEB.Data;
using IACAST_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace IACAST_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IACAST_WEBContext _context;
        public HomeController(ILogger<HomeController> logger, IACAST_WEBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IACAST_WEBContext Get_context()
        {
            return _context;
        }

        public IActionResult Index()

        {
            

            ViewBag.PostDescription = _context.Post.Select(a => a.Description).FirstOrDefault();
            List<object> titulos= new List<object>();

            ViewBag.PostTitle =  _context.Post.Select(a => a.Title).FirstOrDefault();

            ViewBag.PostId = _context.Post.Select(a => a.Id).FirstOrDefault();
            ViewBag.PostImg = _context.Post.Select(a => a.ImageUrl).FirstOrDefault();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}