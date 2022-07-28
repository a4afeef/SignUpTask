using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignUpTask.Models.Account;
using SignUpTask.Repositories.Account;

namespace SignUpTask.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository objAccountRepo = new AccountRepository();

        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult IsEmailExists(string Email)
        {
            bool EmailExists = objAccountRepo.IsEmailExists(Email);

            return Json(!EmailExists);

        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            bool EmailExists, SignUpSuccess;
            if (ModelState.IsValid)
            {
                EmailExists = objAccountRepo.IsEmailExists(model.Email);
                if (EmailExists)
                {
                    TempData["ErrorMessage"] = "Email is already registered!";
                    return View(model);
                }
                else
                {
                    SignUpSuccess = objAccountRepo.SignUp(model);
                    if (SignUpSuccess)
                    {
                        TempData["SuccessMessage"] = model.FirstName + " " + model.LastName + " signed up!";
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error signing up user.";
                        return View(model);
                    }
                }
                
                
            }
            else
            {
                TempData["ErrorMessage"] = "Sign up failed because of missing/invalid data!";
                return View(model);
            }
            
        }
    }
}