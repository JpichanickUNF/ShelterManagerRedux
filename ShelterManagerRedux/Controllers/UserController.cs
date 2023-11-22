using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class UserController : Controller
{
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

