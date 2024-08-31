using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MVCTASK2ITI.Models;

namespace MVCTASK2ITI.Controllers
{
    public class UserController : Controller
    {

        private readonly USERContext context;
        public UserController()
        {
            this.context = new();
        }
        
    public IActionResult Index()
        {
        List<User> users =context.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            User? user = context.Users.Where(u => u.Email == model.Email).SingleOrDefault();

            if (user == null)
            {
                ModelState.AddModelError("", "Email does not exist.");
            }
            else
            {
                if (user.Password != model.Password)
                {
                    ModelState.AddModelError("", "Incorrect password.");
                }
                else
                {
                    return RedirectToAction("Details", "User", new { id = user.Id });
                }
            }

            return View(model);
        }


        public IActionResult Details(int Id)
        {
            User? user=context.Users.Where(x => x.Id == Id).SingleOrDefault();
            if (user == null) 
            { return Content("This Id is Invalid"); }
            return View(user);
        }
        public IActionResult Delete(int Id)
        {
            User? user = context.Users.Where(x => x.Id == Id).SingleOrDefault();

            if (user == null)
            { return Content("This Id is Invalid"); }
            else
            {
                context.Users.Remove(user);
                context.SaveChanges();
                List<User> users = context.Users.ToList();
                return View(users);
            }
        }

        public IActionResult Update(int id)
        {
            
                return View();
            
        }
        [HttpPost]
        public IActionResult Update(User model)
        {
            User? user = context.Users.SingleOrDefault(x => x.Id == model.Id);

            if (user != null)
            {
                user.Name = model.Name;
                user.Age = model.Age;
                user.Email = model.Email;
                user.Password = model.Password;

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
               context.Users.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

       

    }
}
