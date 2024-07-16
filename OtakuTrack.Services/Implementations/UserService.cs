using AutoMapper;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Domain.Entities;
using OtakuTrack.Repositories.Interfaces;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IErrorLogService _logService;

        public UserService(IUserRepository repository, IMapper mapper, IErrorLogService logService)
        {
            _repository = repository;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> AddUserAsync(CreateUserDTO userCreateDto)
        {
            try
            {
                var user = _mapper.Map<User>(userCreateDto);
                await _repository.AddAsync(user);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO userUpdateDto)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);

                if (user == null) { return null; }

                _mapper.Map(userUpdateDto, user);
                await _repository.UpdateAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                if (user == null) { return false; }

                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync(ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}
