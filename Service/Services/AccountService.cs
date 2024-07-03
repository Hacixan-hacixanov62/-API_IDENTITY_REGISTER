using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Account;
using Service.Helpers.Account;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            
        }

        public async Task<UserDto> GetUserByUserNameAsync(string username)
        {
            var existUser = await _userManager.FindByNameAsync(username);

            return existUser is null ? throw new NotFoundException($"{username} - user notfound") : _mapper.Map<UserDto>(existUser);

        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
           return _mapper.Map<IEnumerable<UserDto>>(await _userManager.Users.ToListAsync());
        }

        public async Task<RegisterResponse> SignUpAsync(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            
            if(!result.Succeeded)
            {
                return new RegisterResponse()
                {
                    Success = false,
                    Errors = result.Errors.Select(m => m.Description)
                };
            }

            return new RegisterResponse()
            {
                Success = true,
                Errors = null
            };

        }
    }
}
