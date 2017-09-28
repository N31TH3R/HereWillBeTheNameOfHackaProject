using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OLE.Models;
using OLE;
using Newtonsoft.Json;

namespace OLE.Controllers
{
    public class HomeController : Controller
    {

        public OLEDbContext _context;

        public HomeController(OLEDbContext context) 
        {
            _context = context;
            var tttt = _context.Placemark.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void OnPostAsync()
        {

        }

        public JsonResult OnGet()
        {
            return Json(_context.Placemark.ToList<Placemark>());
        }
    }
}
