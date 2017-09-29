using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OLE.Models;
using System;
using System.Globalization;
using Newtonsoft.Json;

namespace OLE.Controllers
{
    public class HomeController : Controller
    {

        public OLEDbContext _context;

        public HomeController(OLEDbContext context) 
        {
            _context = context;
            //var pm = new Placemark();
            //pm.HintContent = "Текст подсказки";
            //pm.GeometryType = "Point";
            //pm.Options = "islands#blueSportCircleIcon";
            //pm.BalloonContent = "Содержимое балуна";
            //pm.ClusterCaption = "Еще одна метка";
            //pm.Type = "Feature";
            //pm.XCoordinate = 55.763338f;
            //pm.YCoordinate = 37.565466f;
            //_context.Add(pm);
            //_context.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public void SendToAsp(String jsn)
        {
            var pm = JsonConvert.DeserializeObject<Placemark>(jsn);
            _context.Add(pm);
            _context.SaveChanges();
        }

        [HttpPost]
        public JsonResult OnGetAsync(string enabledLayers)
        {
            var layers = enabledLayers.Split(',').ToArray();
            return Json(_context.Placemark.Where(x => layers.Contains(x.Category.Trim())).Select(x => new {
                type = x.Type,
                id = x.Id,
                category = x.Category,
                geometry = new {
                    type = x.GeometryType,
                    coordinates = new[] {
                        x.XCoordinate,
                        x.YCoordinate
                    }
                },
                properties = new {
                    balloonContent = x.BalloonContent,
                    clusterCaption = x.ClusterCaption,
                    hintContent = x.HintContent
                },
                options = new {
                    preset = x.Preset,
                    iconColor = x.IconColor
                }
            }));
        }
    }
}
