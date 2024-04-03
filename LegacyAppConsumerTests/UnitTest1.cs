using LegacyApp;

namespace LegacyAppConsumerTests;

public class UnitTest1
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {

        var result = UserServiceMethods.CheckName(null, "Kowalski");
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenLastNameIsNull()
    {
        
       
        var result = UserServiceMethods.CheckName("Jan", null);
        
        Assert.False(result);
    }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenDataIsCorrect()
    {

        var result = UserServiceMethods.CheckBirthDate(DateTime.Parse("2000-01-01"));
        
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenDataIsUnCorrect()
    {
        
        var result = UserServiceMethods.CheckBirthDate(DateTime.Parse("2015-01-01"));
        
        Assert.False(result);
    }
    
    
    [Fact]
    public void AddUser_ReturnsFalseWhenEmailIsUnCorrect()
    {
        
        var result = UserServiceMethods.CheckEmail("kowalski@kowalskipl");
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenEmailIsCorrect()
    {
        
        var result = UserServiceMethods.CheckEmail("kowalski@kowalski.pl");
        
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenInfoIsCorrect()
    {
        
       
        var userService = new UserService();

        var result = userService.AddUser(
            "Malewski", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );
        
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseCreditLimitLessThan500()
    {
        
       
        var userService = new UserService();

        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        Assert.False(result);
    }
    
    
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1000
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
        
    }
    
}