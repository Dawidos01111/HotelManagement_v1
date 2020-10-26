using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class LoginAndRegisterController : Controller
    {
        //Tworzenie uzytkownikow, usuwanie użytkowników, 
        private readonly UserManager<ApplicationUser> _userManager;

        //Możliwość zalogowania się, zarejestrowania się, wylogowanie się
        private readonly SignInManager<ApplicationUser> _signInManager;


        public LoginAndRegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Login
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel signInUserModel)
        {
            if (ModelState.IsValid)
            {



                //Wyszukanie użytkownika 
                var user = await _userManager.FindByNameAsync(signInUserModel.Email);

                //Jeśli mamy tego użytkownika..
                if (user != null)
                {
                    //To próbujemy się zalogować
                    var signInResult = await _signInManager.PasswordSignInAsync(user, signInUserModel.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Niepoprawne dane logowania");

            }  
          
            return View(signInUserModel);
        }


        //Register
        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpUserModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signUpUserModel)
        {

            if (ModelState.IsValid)
            {
                //Tworzenie nowego użytkownika
                var user= new ApplicationUser()
                {
                    FirstName = signUpUserModel.FirstName,
                    LastName = signUpUserModel.LastName,
                    Address = signUpUserModel.Address,
                    City = signUpUserModel.City,
                    Email = signUpUserModel.Email,
                    UserName = signUpUserModel.Email
                    
                };
                var identityResult = await _userManager.CreateAsync(user, signUpUserModel.Password);

               

                if (identityResult.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(signUpUserModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
