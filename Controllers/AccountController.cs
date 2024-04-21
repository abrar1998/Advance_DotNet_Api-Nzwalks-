using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZZwalks.AccountRepository;
using NZZwalks.CustomActionFilters;
using NZZwalks.Models.Domain;
using NZZwalks.Models.DTO;
using NZZwalks.TokenRepository;

namespace NZZwalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountRepo accountRepo;
        private readonly ITokenRepo tokenRepo;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(IMapper mapper, IAccountRepo accountRepo, ITokenRepo tokenRepo, UserManager<IdentityUser> userManager)
        {
            this.mapper = mapper;
            this.accountRepo = accountRepo;
            this.tokenRepo = tokenRepo;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        [ValidateModel] //custom model validation
        public async Task<IActionResult> Register([FromBody]RegisterDTO registerDTO)
        {
            var registerDomain = mapper.Map<Register>(registerDTO);
            var result = await accountRepo.RegisterUser(registerDomain);
            if(result.Succeeded)
            {
                return Ok("Registration successfully");
            }
            else
            {
                return BadRequest("Registration Failed");
            }   
        }

        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loginDomain = mapper.Map<Login>(loginDTO);
            var result = await accountRepo.LoginUser(loginDomain);
            if(result !=null)
            {
                //get user role
                /*
                var user = await userManager.FindByEmailAsync(loginDomain.Email);
                var role = await userManager.GetRolesAsync(user);
                //create  token
                var token = tokenRepo.CreateToken(user, role.ToString());
                return Ok(token);
                */
                var token = new ResponseTokenDTO
                {
                    JwtToken = result,
                };
                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}
