using Portfolio.API.Dto.User;

namespace Portfolio.API.Services.Contracts
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto?> GetById(int userId);
        Task<UserDto> Create(CreateUserRequest user);
    }
}
