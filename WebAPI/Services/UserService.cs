using AutoMapper;
using Common.Exceptions;
using Entity.Models;
using Entity.Models.Auth;
using Entity.Repository;
using Microsoft.AspNetCore.Identity;
using WebAPI.Model.Dto.Project;
using WebAPI.Model.Dto.Report;
using WebAPI.Model.Dto.User;
using WebAPI.Model.Mapping;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private IMapper _mapper { get; }
        private UserManager<User> _userManager { get; }
        public UserService(UserManager<User> usermanager, IRepository<User> userRepository, IMapper mapper)
        {
            _userManager = usermanager;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> GetUser(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new NotFoundException("No such user exist");

            var output = _mapper.Map<UserResponseDto>(user);
            return output;
        }

        public async Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var res = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());

            if (res == null)
                throw new NotFoundException("No such User Exist");

            await _userRepository.Update(res);

            return null;
        }

        public async Task DeleteUser(long id)
        {
            var res = await _userRepository.GetByIdAsync(id);
            if (res == null)
                throw new NotFoundException("No such User Exist");

            await _userRepository.Delete(id);
        }

        public async Task<UserWithProjectsDto> GetUserWithProjects(long id)
        {
            var project = await _userRepository.GetByIdWithIncludeAsync(id, u => u.Projects);
            var res = _mapper.Map<UserWithProjectsDto>(project);
            return res;
        }
    }
}
