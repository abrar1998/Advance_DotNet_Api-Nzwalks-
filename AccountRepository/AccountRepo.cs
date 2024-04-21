using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using NZZwalks.Models.Domain;
using NZZwalks.TokenRepository;

namespace NZZwalks.AccountRepository
{
    public class AccountRepo:IAccountRepo
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenRepo tokenRepo;

        public AccountRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenRepo tokenRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenRepo = tokenRepo;
        }


        public async Task<IdentityResult> RegisterUser(Register register)
        {
            var user = new IdentityUser
            {
                UserName = register.Email,
                Email = register.Email,
            };

            var result = await userManager.CreateAsync(user, register.Password);
           
            if(register.Roles !=null && register.Roles.Any())
            {
                await userManager.AddToRoleAsync(user, register.Roles!);
            }

            return result;

        }

        public async Task<string> LoginUser(Login login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if(user !=null)
            {
                var res= await userManager.CheckPasswordAsync(user,login.Password);
                if(res)
                {
                    var role = await userManager.GetRolesAsync(user);
                    //create  token
                    var token = tokenRepo.CreateToken(user, role.ToString());
                    return token;
                }
                else
                {
                    return "Invaid Password";
                }

            }
            else
            {
                return null;
            }
         
        }

    }
}
