namespace Portfolio.API.Dto.User
{
    public class UpdateUserRequest
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}
