﻿using Microsoft.AspNetCore.Mvc;
using ShelterManagerRedux.Models;
using ShelterManagerRedux.DataAccess;
using System.Threading.Tasks;

public class UserController : Controller
{
    private readonly ManagerContext _context;
    public UserController(IConfiguration config)
    {
        string connectionString = config.GetSection("ConnectionStrings:MyConnection").Value;
        _context = new ManagerContext(connectionString);
    }

    //[HttpGet]
    //public IActionResult Create()
    //{
    //    return View();
    //}



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Manager model)
    {




        if (ModelState.IsValid)
        {
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


            return RedirectToAction("Login", "Account");
        }


        return View(model);
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
