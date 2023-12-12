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
    //public class ShelterProfileController : Controller
    //{
    //    public IActionResult ShelterProfile()
    //    {
    //        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
    //        string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

    //        ShelterProfileContext dw = new ShelterProfileContext(connStr);

    //        var query = from w in dw.ShelterProfile
    //                    orderby w.ShelterID
    //                    select w;

    //        List<ShelterProfile> myData = query.ToList();

    //        return View(myData);
    //    }
    //}
}
