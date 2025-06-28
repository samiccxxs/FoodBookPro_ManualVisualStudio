public interface IUserService
{
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    Task DeleteUserAsync(int id);
    Task<bool> ValidateUserCredentialsAsync(string email, string password);
}