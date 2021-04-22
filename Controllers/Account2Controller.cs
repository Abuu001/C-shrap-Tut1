using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesWebApp.Models;
using JokesWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JokesWebApp.Controllers
{
    public class Account2Controller : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public Account2Controller(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);

                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);

                    }
                    return View(userModel);
                }
                ModelState.Clear();
            }
            return View();
        }
    }
}
