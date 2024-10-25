using Microsoft.AspNetCore.Mvc;

namespace MYmvc_Core.Controllers
{
    public class HelloController1 : Controller
    {
        public string Index()
        {
            throw new DivideByZeroException();
        }
        public IActionResult MyPage()
        {
            return View();
        }

        public IActionResult Display()
        {
            return View();
        }
        public IActionResult Login(Employee e)
        {
            var res = from t in Emplist.Getlist
                      where t.username == e.username && t.pwd == e.pwd
                      select t;
            if (res.Count() > 0) { }
            else
            {
                ViewData["v"] = "Invalid username or password";
            }
            return View();

        }
    }



    public class Employee
    {
        public string username { get; set; }
        public string pwd { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
    public static class Emplist
    {
        public static List<Employee> Getlist = new List<Employee>()
            {
                 new Employee(){ username="vijay" , pwd="123" , Age=33, Country="india", Role="hr" },
                 new Employee(){ username="raj" , pwd="123" , Age=29, Country="india", Role="manager" },
                 new Employee(){ username="jay" , pwd="123" , Age=30, Country="canada", Role="admin" },
                 new Employee(){ username="sujay" , pwd="123" , Age=25, Country="us", Role="manager" },
                 new Employee(){ username="anil" , pwd="123" , Age=24, Country="us", Role="teamlead" },

                };
    }
}

