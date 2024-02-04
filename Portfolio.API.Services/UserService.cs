using AutoMapper;
using Portfolio.API.Data.Contracts;
using Portfolio.API.Data.Entities;
using Portfolio.API.Dto.User;
using Portfolio.API.Services.Contracts;
using Portfolio.API.Services.Exceptions;

namespace Portfolio.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Create(CreateUserRequest dto)
        {
            if (await _userRepository.FindByUsername(dto.UserName) != null)
            {
                throw new ConflictException("Username already taken");
            }
            if (await _userRepository.FindByEmail(dto.Email) != null)
            {
                throw new ConflictException("Email address already in use");
            }

            User user = _mapper.Map<User>(dto);
            //user.Password = HashPassword(user.Password);

            await _userRepository.Add(user);
            //await SendActivationEmail(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
