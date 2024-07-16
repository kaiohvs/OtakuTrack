using OtakuTrack.Domain.DTOs;

namespace OtakuTrack.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> AddUserAsync(CreateUserDTO createUserDto);
        Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO updateUserDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
