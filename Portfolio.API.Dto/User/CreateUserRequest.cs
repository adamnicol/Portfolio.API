namespace Portfolio.API.Dto.User
{
    public class CreateUserRequest
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
