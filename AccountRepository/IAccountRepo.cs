using Microsoft.AspNetCore.Identity;
using NZZwalks.Models.Domain;

namespace NZZwalks.AccountRepository
{
    public interface IAccountRepo
    {
        Task<IdentityResult> RegisterUser(Register register);
        Task<string> LoginUser(Login login);

    }
}
