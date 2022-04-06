using AutoMapper;
using Common.Exceptions;
using Entity.Models.Auth;
using Entity.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Model.Auth;
using WebAPI.Model.Dto.User;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository { get; }
        private IMapper _mapper { get; }
        private SignInManager<User> _signInManager { get; }
        private UserManager<User> _userManager { get; }
        private IOptions<AuthOptions> _authOptions { get; }
        public AuthService(IUserRepository userRepository, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager, IOptions<AuthOptions> options)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _authOptions = options;
        }

        public async Task<LoginUserResponseDto> Login(LoginUserQueryDto loginUserQueryDto)
        {
            var checkUsername = _userRepository.GetByUserName(loginUserQueryDto.UserName);

            var checkPass = await _signInManager.PasswordSignInAsync(loginUserQueryDto.UserName, loginUserQueryDto.Password, false, false);
            if (!checkPass.Succeeded || checkUsername == null)
            {
                throw new InvalidFormException($"", "wrong username or password", StatusCodes.Status401Unauthorized);
            }
            var user = await _userRepository.GetByUserName(loginUserQueryDto.UserName);

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
                    new Claim(ClaimTypes.Email, user.Email)
                };

            roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken
            (
                authParams.Issuer,
                authParams.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
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
            var check = await _userRepository.SingleUserNameAndEmail(userName: registerUserQueryDto.UserName, email: registerUserQueryDto.Email);

            if (check != null)
            {
                // @TO-DO refactor
                //var email = registerUserQueryDto.Email == check.Email ? "Email - " : $"{registerUserQueryDto.Email}";
                //var username = registerUserQueryDto.UserName == check.UserName ? "UserName :" : $"{registerUserQueryDto.UserName}";

                throw new EntryAlreadyExistsException($"User with similar Email already exist or UserName already taken!");
            }

            var user = _mapper.Map<User>(registerUserQueryDto);
            //@TO-DO Refactor this
            var result = await RegisterNewUser(user, registerUserQueryDto.Password);
            if (!result.Succeeded)
            {
                throw new InvalidFormException("", result.Errors
                                                            .Select(e => e.Description)
                                                            .Aggregate((x, res) => res += x + "\n"));
            }

            return _mapper.Map<UserResponseDto>(registerUserQueryDto);
        }
        private async Task<IdentityResult> RegisterNewUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userRepository.Save();
            }

            return result;
        }
    }
}
