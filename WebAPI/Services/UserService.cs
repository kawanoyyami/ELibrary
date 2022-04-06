using AutoMapper;
using Common.Exceptions;
using Entity.Models.Auth;
using Entity.Repository.Interfaces;
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
        private IUserRepository _userRepository { get; }
        private IProjectRepository _projectRepository { get; }
        private IMapper _mapper { get; }
        private UserManager<User> _userManager { get; }
        public UserService(UserManager<User> usermanager, IUserRepository userRepository, IMapper mapper, IProjectRepository projectRepository)
        {
            _userManager = usermanager;
            _userRepository = userRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        public async Task<UserResponseDto> GetUser(long id)
        {
            var user = await _userRepository.GetEntity(id);

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
            var res = await _userRepository.GetEntity(id);
            if (res == null)
                throw new NotFoundException("No such User Exist");

            await _userRepository.DeleteUser(id);
        }

        public async Task<ICollection<ProjectResponseDto>> GetUserProject(long id)
        {
            var res = await _userRepository.GetProjects(id);

            var output = _mapper.Map<ICollection<ProjectResponseDto>>(res);

            return output;
        }

        public async Task<ICollection<ReportResponseDto>> GetUserReport(long id)
        {
            var allUserReports = await _projectRepository.GetAllUserReports(id);

            var output = _mapper.Map<ICollection<ReportResponseDto>>(allUserReports);

            return output;
        }
    }
}
