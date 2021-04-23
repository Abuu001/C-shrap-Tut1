using JokesWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email =userModel.Email,
                UserName = userModel.Email,
        
            };
           var result = await _userManager.CreateAsync(user,userModel.Password);
            return result;
        }


        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
         
            return await  _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe,false);
        }

        public async Task SignoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
