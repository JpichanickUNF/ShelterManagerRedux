using Microsoft.AspNetCore.Mvc;
using ShelterManagerRedux.Models;
using ShelterManagerRedux.DataAccess;
using System.Threading.Tasks;

public class UserController : Controller
{
    private readonly ManagerContext _context;

    public UserController(ManagerContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User model)
    {
        if (ModelState.IsValid)
        {
            var manager = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                Phone_Number = model.Phone_Number,
                Assigned_Shelter = model.Assigned_Shelter
            };

            _context.Manager.Add(manager);

            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
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
