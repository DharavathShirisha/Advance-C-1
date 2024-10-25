using Microsoft.AspNetCore.Mvc;
using MycoreApp.Models;
namespace MycoreApp.Controllers
{
    public class HelloController : Controller
    {
        onlineshoppingdbContext dc = new onlineshoppingdbContext();
        public IActionResult Index()
        {
            var res = from t in dc.Products select t;
            return View(res.ToList());
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        // ActionResult: method can return anything like
        // content ,via, 
        [HttpPost]
        public ActionResult Login(string t1, string t2)
        {
            var res = (from t in dc.Registertbls
                       where t.Uname == t1 && t.Password == t2
                       select t).Count();
            if (res > 0)
            {
                HttpContext.Session.SetString("uid", t1);
                // code to navigate
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["err"] = "Invalid Usernamr or password";
            }
            return View();
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Register(Registertbl r)
        {
            if (ModelState.IsValid)
            {
                dc.Registertbls.Add(r);
                int i = dc.SaveChanges();
                if (i > 0)
                {
                    ViewData["a"] = "User created Sucessfully";
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Buy(string pid)
        {
            var res = from t in dc.Products
                      where t.Pid == pid
                      select t;


            if (HttpContext.Session.GetString("uid") != null)
            {
                return View(res.ToList());

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult Buy(IFormCollection f)
        {
            Userorder u = new Userorder();

            u.Username = HttpContext.Session.GetString("uid");
            u.Pid = Request.Query["pid"].ToString();
            u.Transdate = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.MinValue);
            u.Qty = int.Parse(f["Qty"]);

            dc.Userorders.Add(u);
            int i = dc.SaveChanges();

            if (i > 0)
            {
                ViewData["r"] = "Your order is placed.";
            }

            return View();
        
        }
    }
}
