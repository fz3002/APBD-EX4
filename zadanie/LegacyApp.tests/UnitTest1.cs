namespace LegacyApp.tests;

public class UnitTest1
{
    private readonly UserService _us = new();

    [Fact]
    public void AddUser_WhenUserIsNormalClientAndCreditUnder500_ShouldNotAddUserAndReturnFalse()
    {
        _us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(1982, 2,2), 1);
    }

    [Fact]
    public void AddUser_WhenBirthDateBiggerThenToday_ShouldReturnFalseAndNotAddUser()
    {
        _us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2048, 2,2), 1);
    }

    [Fact]
    public void AddUser_WhenEmailWronglyFormated_ShouldReturnFalseAndNotAddUser()
    {
        _us.AddUser("Jan", "Kowalski", "kowalskiwppl", new DateTime(1982, 2,2), 1);
    }

    [Fact]
    public void AddUser_WhenNameNotGiven_ShouldReturnFalseAndNotAddUser()
    {
        _us.AddUser(null, "Kowalski", "kowalski@wp.pl", new DateTime(1982, 2,2), 1);
    }

    [Fact]
    public void AddUser_WhenSurnameNotGiven_ShouldReturnFalseAndNotAddUser()
    {
        _us.AddUser("Jan", null, "kowalski@wp.pl", new DateTime(1982, 2,2), 1);
    }

    [Fact]
    public void AddUser_WhenAgeUnder21_ShouldReturnFalseAndNotAddUser()
    {
        _us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2010, 4,2), 1);
    }

    [Fact]
    public void AddUser_WhenUserDidntHaveBirhtdayYet_ShouldDecreaseAgeByOneReturnFalseAndNotAddUser()
    {
        _us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2000, 3,30), 1);
    }
        
    [Fact]
    public void AddUser_WhenUserIsVeryImportantClient_ShouldAddUserEvenWithCreditLimitUnder500()
    {
        _us.AddUser("Mariusz", "Malewski", "malewski@gmail.pl", new DateTime(1974, 2,2), 2);
    }

    [Fact]
    public void AddUser_WhenUserIsImportantClient_ShouldDoubleCreditCardLimit()
    {
        _us.AddUser("John", "Smith", "smith@gmail.pl", new DateTime(1974, 2,2), 3);
    }
}