using Service.DTOs.Account;
using Service.Helpers.Account;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
    }
}
