using BookStore;

public interface IUserService
{
    UserModel Authenticate(string username, string password);
    void SaveRefreshToken(int userId, string refreshToken);
    string GetRefreshToken(int userId);
    UserModel GetUserById(int userId);
}
