using AutoMapper;
using Entity.Models.Auth;
using Entity.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using WebAPI.Model.Dto.User;
using WebAPI.Model.Mapping;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; }
        private IMapper _mapper { get; }
        private UserManager<User> _userManager { get; }
        public UserService(UserManager<User> usermanager, IUserRepository userRepository, IMapper mapper)
        {
            _userManager = usermanager;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> GetUser(long id)
        {
            var user = await _userRepository.GetEntity(id);

            if (user == null)
                throw new Exception("No such user exist");

            var output = _mapper.Map<UserResponseDto>(user);
            return output;
        }
    }
}
