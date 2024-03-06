using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using ShelterManagerRedux.DataAccess;
using ShelterManagerRedux.Models;
using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace ShelterManagerRedux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public int Shelter1Cots = 25, Shelter2Cots = 30, Shelter3Cots = 19;

        //self note
        private ManagerContext _context;

        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            //self note 
          

            _context = new ManagerContext();


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }


        public ActionResult ClientView()
        {
            return this.RedirectToAction("ClientView", "ClientView");
        }
        public ActionResult ShowInterest()
        {
            return this.RedirectToAction("ShowInterest", "ClientView");
        }




        public IActionResult Help()
        {

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            FAQContext ff = new FAQContext(connStr);


            var query = from f in ff.FrequentlyAskedQuestions
                        orderby f.QuestionID
                        select f;

            List<FrequentlyAskedQuestions> myData = query.ToList();
            return View(myData);

        }

        public IActionResult ContactPage()
        {
            return View();
        }

        public IActionResult ShelterProfile()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            ShelterProfileContext dw = new ShelterProfileContext(connStr);

            var query = from w in dw.ShelterProfile
                        orderby w.ShelterID
                        select w;

            List<ShelterProfile> myData = query.ToList();

            return View(myData);
        }

        public IActionResult EditShelterProfile()
        {
            return View();
        }

        [Route("ClientManager")]
        public IActionResult ClientManager()
        {
            return ClientManagerMaster("", "");
        }
        [Route("ClientManager/{FilterType}/{Filter}")]
        public IActionResult ClientManager(string Filtertype, string Filter)
        {
            return ClientManagerMaster(Filtertype, Filter);
        }


        public IActionResult ClientManagerMaster(string Filtertype, string Filter)
        {

            List<Client> Clients = new List<Client>();

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;

            ClientContext cc = new ClientContext(connStr);


            ShelterLocationContext slc = new ShelterLocationContext(connStr);
            var shelterLocations = from c in slc.ShelterLocations orderby c.Shelter_Location_Description select c;
            SelectList sl = new SelectList(shelterLocations, "Shelter_Location_ID", "Shelter_Location_Description");
            ViewBag.ShelterLocations = shelterLocations;
            ViewBag.ShelterLocationsFilters = sl;



            List<Client> myData = null;
            
            if (Filter.Length > 0)
            {
                if (Filtertype == "FirstName")
                {
                    var query = from c in cc.Clients
                                join s in cc.ShelterLocations on c.Shelter_Location_ID equals s.Shelter_Location_ID
                                where c.F_Name == Filter
                                orderby c.L_Name
                                select c;
                    myData = query.ToList();
                }
                else if (Filtertype == "LastName")
                {
                    var query = from c in cc.Clients
                                join s in cc.ShelterLocations on c.Shelter_Location_ID equals s.Shelter_Location_ID
                                where c.L_Name == Filter
                                orderby c.L_Name
                                select c;
                    myData = query.ToList();
                }
                else if (Filtertype == "ShelterLocation")
                {
                    int selectedID = int.Parse(Filter);
                    var query = from c in cc.Clients
                                join s in cc.ShelterLocations on c.Shelter_Location_ID equals s.Shelter_Location_ID
                                where c.Shelter_Location_ID == selectedID
                                orderby c.L_Name
                                select c;
                    myData = query.ToList();
                }
            }
            else
            {
                var query = from c in cc.Clients
                        join s in cc.ShelterLocations on c.Shelter_Location_ID equals s.Shelter_Location_ID
                        orderby c.L_Name
                        select c;
                myData = query.ToList();
            }
            return View(myData);
        }


        [Route("ClientDetailManager/{client_ID}")]
        public IActionResult ClientDetailManager(int Client_ID)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;
            ClientContext cc = new ClientContext(connStr);
            ShelterLocationContext slc = new ShelterLocationContext(connStr);
            var shelterLocations = from c in slc.ShelterLocations orderby c.Shelter_Location_Description select c;
            ViewBag.ShelterLocations = shelterLocations;
            Client theClient = cc.Clients.Find(Client_ID);

            if (theClient == null)
            {
                theClient = new Client();
            }

            return View(theClient);
        }

        [HttpPost]
        [Route("ClientDetailManager/{client_ID}")]
        public IActionResult ClientDetailManager([FromForm] Client c)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;
            ViewBag.ErrorMessage = "";

            //if (ModelState.IsValid)
            //{


            if (c.ClientID == 0)
            {
                //no client id, therefore insert
                using (ClientContext cc = new ClientContext(connStr))
                {
                    cc.Clients.Add(c);
                    cc.SaveChanges();
                }
            }
            else
            {
                //have client id, so update
                using (ClientContext db = new ClientContext(connStr))
                {
                    db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return View(null);
            //}
            //else
            //{
            //    ViewBag.ErrorMessage = "First Name and Last Name are required!";
            //    return View(c);
            //}


        }

        [HttpPost]
        [Route("DeleteClient")]
        public JsonResult DeleteClient(int clientIDVal)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string connStr = config.GetSection("Connnectionstrings:MyConnection").Value;
            Client c = null;

            using (ClientContext cc = new ClientContext(connStr))
            {
                c = cc.Clients.Find(clientIDVal);
            }

            using (ClientContext cc = new ClientContext(connStr))
            {
                cc.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                cc.SaveChanges();
            }

            return Json(new { Success = false, Message = "Delete failed." });

        }
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
            if (m.ManagerID == 0)
            {
                using (ManagerContext mm = new ManagerContext(connectionString))
                {
                    mm.Managers.Add(m);
                    mm.SaveChanges();
                }
            }



            return View("Index");

        }
        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginView(LoginViewModel model)
        {
            /*
            // authenticate manager in context
            Manager authenticatedManager = _context.AuthenticateManager(m.Username, m.Password);

            if (authenticatedManager != null)
                {
                    // successful login, store session
                    SetManagerInSession(authenticatedManager.ManagerID);
                return View("Index");
                }
                else
                {
                    // fail login
                    ModelState.AddModelError(string.Empty, "Invalid username or password");

                return View("Index");
                }
            //if program gives error, there is nothing returned right here  
            */
            _logger.LogInformation($"Attempting to authenticate user: {model.Username}");

            try
            {
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
                string connectionString = config.GetSection("Connnectionstrings:MyConnection").Value;

                // Use the connection string to create a ManagerContext
                using (var context = new ManagerContext(connectionString))
                {
                    var manager = context.AuthenticateManager(model.Username, model.Password);

                    if (manager != null)
                    {
                        _logger.LogInformation($"User {model.Username} authenticated successfully.");

                        // Successful login, store session or cookie if needed
                        SetManagerInSession(manager.ManagerID);

                        // Redirect to the DisplaySuccessMessage action
                        return RedirectToAction("DisplaySuccessMessage");
                    }
                }

                // Invalid login, show an error message
                _logger.LogWarning($"Invalid login attempt for user {model.Username}");
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log them, or return an error view
                _logger.LogError($"Error during login: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred during login");
                return View(model);
            }
        }
        private void SetManagerInSession(int managerId)
        {
            HttpContext.Session.SetInt32("ManagerID", managerId);
        }
        public IActionResult DisplaySuccessMessage()
        {
            // Retrieve the login message from the session
            string loginMessage = HttpContext.Session.GetString("LoginMessage");

            // Clear the login message from the session to display it only once
            HttpContext.Session.Remove("LoginMessage");

            // Pass the message to the view
            ViewBag.LoginMessage = loginMessage;

            // Render a specific view for displaying the success message
            return View("Index");
        }


        public IActionResult Success()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }







    }
}