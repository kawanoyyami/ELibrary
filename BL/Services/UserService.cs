using AutoMapper;
using BL.Interfaces;
using Common.Dto.User;
using Common.Exceptions;
using DataAccess.Repository.Interfaces;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace BL.Services
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

            if (user is null)
                throw new NotFoundException("No such user exist");

            var output = _mapper.Map<UserResponseDto>(user);
            return output;
        }

        public async Task<UserResponseDto> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());

            if (user == null)
                throw new ValueOutOfRangeException($"User could not be updated because user with id: {userUpdateDto.Id} not exist in database!");

            _mapper.Map(userUpdateDto, user);

            await _userRepository.Update(user);

            return null;
        }

        public async Task DeleteUser(long id)
        {
            var res = await _userRepository.GetByIdAsync(id);

            if (res == null)
                throw new ValueOutOfRangeException($"User could not be deleted because user with id: {id} not exist in database!");

            await _userRepository.Delete(id);
        }

        public async Task<UserWithProjectsDto> GetUserWithProjects(long id)
        {
            var project = await _userRepository.GetByIdWithIncludeAsync(id, u => u.Projects);

            if (project is null)
                throw new NotFoundException("No such user exist");

            var res = _mapper.Map<UserWithProjectsDto>(project);
            return res;
        }
    }
}
