using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLogin.Models;


namespace WebLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebLoginContext _context;

        public HomeController(WebLoginContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Home()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        // GET: Users/login
        //public IActionResult Login(User data)
        //{
        //    return View();
        //}
        public IActionResult Login()
        {
            return View();
        }

        //public  IActionResult Details(string username)
        //{
        //    ViewData["username"] = username;
        //    return View(user);
        //}

        // GET: Users/login
        public IActionResult LoginUser(User data)
        {
            var user = _context.User.FirstOrDefault(m => m.Username == data.Username && m.Password==data.Password);
                
            if (user == null)
            {
                return NotFound();
            }
            ViewData["username"] = user.Username;
            return View("Details");
        }
        // GET: Users/Create
        public IActionResult Register()
        {
            return View();
        }
        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("ID,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("LoginUser",user);
            }
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
