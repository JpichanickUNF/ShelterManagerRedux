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
                        orderby v.Shelter_Location_ID
                        select v;

            List<ShelterLocation> myData = query.ToList();

            return View(myData);
        }
        public IActionResult ShowInterest(int shelterID)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            ShelterLocationContext cv = new ShelterLocationContext(connStr);

            var query = from v in cv.ShelterLocations
                        orderby v.Shelter_Location_ID
                        select v;

            List<ShelterLocation> myData = query.ToList();

            return View(myData);
        }

        /*[HttpPost]
        public IActionResult ShowInterestButton()
        {
            var buttonNames = Request.Form.Select(x => x.Key).ToList();
            //now you can see clicked button name from form
            string buttonName = buttonNames.FirstOrDefault();
            int buttonId = int.Parse(buttonName);

            //do your logic...
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            ShelterLocationContext cv = new ShelterLocationContext(connStr);

            var query = from v in cv.ShelterLocations
                        orderby v.Shelter_Location_ID
                        select v;

            List<ShelterLocation> myData = query.ToList();
            List<ShelterLocation> returnData = [];
            for (int i = 0; i < myData.Count; i++)
            {
                if (myData[i].Shelter_Location_ID == buttonId) {
                    returnData[0] = myData[i];
                }
            }
            return View(returnData);
        }*/

        [HttpPost]
        public ActionResult ShowInterestButton(int shelterID)
        {

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            ShelterLocation s = null;


            using (ShelterLocationContext cv = new ShelterLocationContext(connStr))
            {
                s = cv.ShelterLocations.Find(shelterID);
                s.Shelter_Location_Available_Room = s.Shelter_Location_Available_Room - 1;
            }

            using (ShelterLocationContext cv = new ShelterLocationContext(connStr))
            {
                cv.Entry(s).State = System.Data.Entity.EntityState.Modified;
                cv.SaveChanges();
            }

            //Url.Action("ShowInterest", "ClientView");

            
            return RedirectToAction("ClientView");

        }
    }
}
