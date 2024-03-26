namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsWhenFirstNameIsEmpty()
    {
        var userService = new UserService();

        var result = userService.AddUser(null,
            "Kowalski", 
            "kowalski@wp.pl", 
            DateTime.Parse("2000-01-01"),
            1);
        
        Assert.False(result);
        
    }

    [Fact]
    public void AddUser_ThrowExceptionWhenClientDoesNotExist()
    {
        var userService = new UserService();

        Action action = () =>
        {
            userService.AddUser("Jan",
                "Kowalski",
                "kowalski@wp.pl",
                DateTime.Parse("2000-01-01"),
                100);
        };
        
        Assert.Throws<ArgumentException>(action);
        
    }

}