using AutoMapper;
using BL.Auth;
using BL.Interfaces;
using Common.Dto.User;
using Common.Exceptions;
using DataAccess.Repository.Interfaces;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BL.Services
{
    public class AuthService : IAuthService
    {
        private IRepository<User> _userRepository { get; }
        private IMapper _mapper { get; }
        private SignInManager<User> _signInManager { get; }
        private UserManager<User> _userManager { get; }
        private IOptions<AuthOptions> _authOptions { get; }
        public AuthService(IRepository<User> userRepository, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager, IOptions<AuthOptions> options)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _authOptions = options;
        }

        public async Task<LoginUserResponseDto> Login(LoginUserQueryDto loginUserQueryDto)
        {
            var checkPass = await _signInManager.PasswordSignInAsync(loginUserQueryDto.UserName, loginUserQueryDto.Password, false, false);
            if (!checkPass.Succeeded)
            {
                throw new NotFoundException("No such user exist");
            }
            var user = await _userRepository.FindEntity(x => x.UserName == loginUserQueryDto.UserName);

            var token = await GenerateToken(user);

            return new LoginUserResponseDto { Token = token };
        }
        private async Task<string> GenerateToken(User user)
        {
            var authParams = _authOptions.Value;

            var roles = await _userManager.GetRolesAsync(user);

            var securityKey = authParams.GetSymmetricSecurityKey();

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken
            (
                authParams.Issuer,
                authParams.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                //expires: DateTime.Now.AddMinutes(authParams.TokenLifeTimeInSeconds),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserResponseDto> RegisterUser(RegisterUserQueryDto registerUserQueryDto)
        {
            var check = await _userManager.FindByNameAsync(registerUserQueryDto.UserName);
            if (check != null)
            {
                throw new NotFoundException("User with same Username already exist!");
            }

            var user = _mapper.Map<User>(registerUserQueryDto);
            //@TO-DO Refactor this
            var result = await RegisterNewUser(user, registerUserQueryDto.Password);
            if (!result.Succeeded)
            {
                throw new ValueOutOfRangeException("Wrong characteristic(password) type!");
            }

            await _userManager.AddToRoleAsync(user, "FreeUser");


            return _mapper.Map<UserResponseDto>(registerUserQueryDto);
        }
        private async Task<IdentityResult> RegisterNewUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userRepository.SaveChangesAsync();
            }

            return result;
        }

        public async Task<string> RefreshToken(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.FindByIdAsync(userClaims.FindFirstValue(ClaimTypes.NameIdentifier));

            var token = await GenerateToken(user);

            return token;
        }
    }
}
