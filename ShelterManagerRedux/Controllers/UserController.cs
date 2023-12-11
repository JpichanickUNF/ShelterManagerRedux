using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using ShelterManagerRedux.DataAccess;
using ShelterManagerRedux.Models;
using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class UserController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    private readonly ManagerContext _context;

    public UserController(ManagerContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User model)
    {
        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        string connStr = config.GetSection("ConnectionStrings:MyConnection").Value; 

        using (var context = new ManagerContext(connStr))
        {
            if (ModelState.IsValid)
            {
                context.Manager.Add(model);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        return View(model);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginView(User model)
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

