using Microsoft.AspNetCore.Identity;

namespace NZZwalks.TokenRepository
{
    public interface ITokenRepo
    {
        string CreateToken(IdentityUser user, string role);
    }
}
