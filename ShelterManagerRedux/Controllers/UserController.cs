using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using ShelterManagerRedux.DataAccess;
using ShelterManagerRedux.Models;
using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace ShelterManagerRedux.Controllers
{
    public class UserController : Controller
    {
        /*
        private readonly ManagerContext _context;
        public UserController(IConfiguration config)
        {
            string connectionString = config.GetSection("ConnectionStrings:MyConnection").Value;
            _context = new ManagerContext(connectionString);
        }
        */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager m)
        {


            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connectionString = config.GetSection("Connnectionstrings:MyConnection").Value;
            ViewBag.ErrorMessage = "";
            /*
            ManagerContext mm = new ManagerContext(connectionString);
            Manager theManager = mm.Managers.Find(ManagerID);

            var query = from m in mm.Managers
                        orderby m.ManagerID
                        select m;


            List<Manager> myData = query.ToList();

            */


            if (m.ManagerID == 0)
            {
                //no client id, therefore insert
                using (ManagerContext mm = new ManagerContext(connectionString))
                {
                    mm.Managers.Add(m);
                    mm.SaveChanges();
                }
                /*
                var manager = new Manager
                {
                    
                    ManagerID = 0,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Assigned_Shelter = model.Assigned_Shelter,
                    Password = model.Password,
                    Username = model.Username,
                    Email = model.Email,
                    Phone_Number = model.Phone_Number
                    

                };
                
                _context.Manager.Add(manager);
                _context.SaveChanges();
               

                return RedirectToAction("Create", "Account");
                 */
            }



            return View("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginView(Manager model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

    }
}