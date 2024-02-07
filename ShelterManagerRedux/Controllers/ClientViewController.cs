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
    }
}
