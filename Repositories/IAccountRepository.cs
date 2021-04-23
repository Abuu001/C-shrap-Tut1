using JokesWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace JokesWebApp.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignoutAsync();
    }
}