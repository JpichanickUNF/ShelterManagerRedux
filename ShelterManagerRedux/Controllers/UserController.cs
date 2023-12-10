using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        if (ModelState.IsValid)
        {
            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home"); 
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

