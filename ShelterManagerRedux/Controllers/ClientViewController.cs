using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult ShowInterest()
        {
            return View();
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
    }
}
