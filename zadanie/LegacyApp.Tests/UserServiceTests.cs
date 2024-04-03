namespace LegacyApp.Tests;


public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        var userService = new UserService();

        var result = userService.AddUser(null,
            "Kowalski", 
            "kowalski@wp.pl", 
            DateTime.Parse("2000-01-01"),
            1);
        
        Assert.False(result);
        
    }
    
    
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail
    
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var userService = new UserService();

        var result = userService.AddUser("Jan",
            "Kowalski", 
            "kowalskiwppl", 
            DateTime.Parse("2000-01-01"),
            1);
        
        Assert.False(result);
        
    }
    
    
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();
        var now = DateTime.Now;
       
        var result = userService.AddUser("Jan",
            "Kowalski", 
            "kowalskiwppl", 
            DateTime.Parse("2004-01-01"),
            1);
            Assert.False(result);
        
    }
    // AddUser_ReturnsTrueWhenVeryImportantClient
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan",
            "Malewski", 
            "malewski@gmail.pl", 
            DateTime.Parse("2000-01-01"),
            2);
        
        Assert.True(result);
        
    }
    
    // AddUser_ReturnsTrueWhenImportantClient
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("Jan",
            "Smith", 
            "smith@gmail.pl", 
            DateTime.Parse("2000-01-01"),
            3);
        
        Assert.True(result);
        
    }

    // AddUser_ReturnsTrueWhenNormalClient
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();
        
        
        var result = userService.AddUser("Tom",
            "Kowalski", 
            "kowalski@wp.pl", 
            DateTime.Parse("2000-01-01"),
            1);
        // nie mozna dodac normalnego uzytkownika bo jest blad
        Assert.False(result);
        
    }
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();
        
        Action action  = () =>
        {
            
            userService.AddUser("Tom",
                "alal",
                "kowalski@wp.pl",
                DateTime.Parse("2000-01-01"),
                6);
        };
        
        var exception = Assert.ThrowsAny<ArgumentException>(action);
        Assert.IsType<ArgumentException>(exception);
    }
    // AddUser_ThrowsExceptionWhenUserDoesNotExist
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        var userService = new UserService();
        
        Action action  = () =>
        {
            userService.AddUser("Tom",
                "alal",
                "kowalski@wp.pl",
                DateTime.Parse("2000-01-01"),
                100);
        };
        
        Assert.Throws<ArgumentException>(action);
    }
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        var userCreditService = new UserCreditService();
        
        
        Action action  = () =>
        {
            userService.AddUser("Tom",
                "Andrzejewicz",
                "kowalski@wp.pl",
                DateTime.Parse("2000-01-01"),
                6);
            
            
        };
        
        Assert.Throws<ArgumentException>(action);
    }

}