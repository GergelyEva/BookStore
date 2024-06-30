using BookStore;
using System.Collections.Generic;
using System.Linq;

public class UserService: IUserService
{
    private readonly List<UserModel> users = new List<UserModel>
    {
        new UserModel { Id = 0, Username = "admin1", Password = "admin1" }
    };

    private readonly Dictionary<int, string> refreshTokens = new Dictionary<int, string>();

    public UserModel Authenticate(string username, string password)
    {
        return users.SingleOrDefault(x => x.Username == username && x.Password == password);
    }

    public void SaveRefreshToken(int userId, string refreshToken)
    {
        refreshTokens[userId] = refreshToken;
    }

    public string GetRefreshToken(int userId)
    {
        refreshTokens.TryGetValue(userId, out var refreshToken);
        return refreshToken;
    }

    public UserModel GetUserById(int userId)
    {
        return users.SingleOrDefault(x => x.Id == userId);
    }
}
