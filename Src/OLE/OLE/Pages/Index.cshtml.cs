using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OLE.Entities;

namespace OLE.Pages
{
    public class indexModel : PageModel
    {
        OLEDbContext _dbContext;

        public indexModel(OLEDbContext db)
        {
            _dbContext = db;
        }
        
        public void OnGet()
        {
            //var result = new Placemark();
            //result.Description = "sdfsdfsfsdf";
            //_dbContext.Add(result);
            //_dbContext.SaveChanges();
            //var test = _dbContext.Placemark.ToList();
        }

        public void OnPostAsync(int xC, int yC)
        {

        }
    }
}