using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Azure;
using NuGet.Versioning;
using ShelterManagerRedux.DataAccess;
using ShelterManagerRedux.Models;
using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
namespace ShelterManagerRedux.Controllers
{
    public class ClientViewController : Controller
    {
        public IActionResult ClientView()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            ShelterLocationContext cv = new ShelterLocationContext(connStr);

            var query = from v in cv.ShelterLocations
                        orderby v.Shelter_Location_Available_Room descending
                        select v;

            List<ShelterLocation> myData = query.ToList();

            return View(myData);
        }

        [HttpPost]
        public IActionResult ShowInterest(int shelterID)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;
               
            using (ShelterLocationContext db = new ShelterLocationContext(connStr))
            {
                var shelter = db.ShelterLocations.FirstOrDefault(s => s.Shelter_Location_ID == shelterID);

                if (shelter != null)
                {
                    if (shelter.Shelter_Location_Available_Room > 0)
                    {
                        // Update the shelter availability or perform other actions as needed
                        shelter.Shelter_Location_Available_Room -= 1;
                        db.SaveChanges();
                    }
                    
                    else
                    {
                        ViewData["ErrorMessage"] = "This shelter has no available space";
                        return View("ClientView", db.ShelterLocations.ToList());
                    }
                }
            }

            // Return whatever view you want after the interest is shown
            return RedirectToAction("ClientView");
        }


    }
}
