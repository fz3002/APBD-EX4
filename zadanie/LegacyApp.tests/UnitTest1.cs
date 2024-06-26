namespace LegacyApp.tests;

public class UnitTest1
{
    private UserService us = new UserService();
    

    [Fact]
    public void UserServiceConstructor_WhenGivenProperDataBases_ShouldCreateUserService()
    {
        UserService us2 = new(new FakeClientRepository(), new FakeUserCreditService(), new FakeUserDataAccess());
    }

    [Fact]
    public void AddUser_WhenUserIsNormalClientAndCreditUnder500_ShouldNotAddUserAndReturnFalse()
    {
        //Arrange
        string name = "Jan";
        string surname = "Kowalski";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(1982, 2,2);
        int clientID = 1;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenBirthDateBiggerThenToday_ShouldReturnFalseAndNotAddUser()
    {
        //Arrange
        string name = "Jan";
        string surname = "Kowalski";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(2048, 2,2);
        int clientID = 1;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenEmailWronglyFormated_ShouldReturnFalseAndNotAddUser()
    {
        //Arrange
        string name = "Jan";
        string surname = "Kowalski";
        string email = "kowalskiwppl";
        DateTime dateOfBirth = new DateTime(1980, 2,2);
        int clientID = 1;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenNameNotGiven_ShouldReturnFalseAndNotAddUser()
    {
        //Arrange
        string surname = "Kowalski";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(1980, 2,2);
        int clientID = 1;

        //Act
        bool result = us.AddUser(null, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenSurnameNotGiven_ShouldReturnFalseAndNotAddUser()
    {
        //Arrange
        string name = "Jan";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(1980, 2,2);
        int clientID = 1;

        //Act
        bool result = us.AddUser(name, null, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenAgeUnder21_ShouldReturnFalseAndNotAddUser()
    {
        //Arrange
        string name = "Jan";
        string surname = "Kowalski";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(2010, 2,2);
        int clientID = 1;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_WhenUserDidntHaveBirthdayYet_ShouldDecreaseAgeByOneReturnFalseAndNotAddUser()
    { //Arrange
        string name = "Jan";
        string surname = "Kowalski";
        string email = "kowalski@wp.pl";
        DateTime dateOfBirth = new DateTime(2000, 4,30);
        int clientID = 1;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.False(result);
    }
        
    [Fact]
    public void AddUser_WhenUserIsVeryImportantClient_ShouldAddUserEvenWithCreditLimitUnder500()
    {
        //Arrange
        string name = "Mariusz";
        string surname = "Malewski";
        string email = "malewski@gmail.pl";
        DateTime dateOfBirth = new DateTime(1974, 2,2);
        int clientID = 2;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_WhenUserIsImportantClient_ShouldDoubleCreditCardLimit()
    {
        //Arrange
        string name = "John";
        string surname = "Smith";
        string email = "smith@gmail.pl";
        DateTime dateOfBirth = new DateTime(1974, 2,2);
        int clientID = 3;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_WhenClientDoesntExist_ShouldThrowException()
    {
        try{
        //Arrange
        string name = "John";
        string surname = "Smith";
        string email = "smith@gmail.pl";
        DateTime dateOfBirth = new DateTime(1974, 2,2);
        int clientID = 123123;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.Fail();
        } catch(ArgumentException){

        }
    }

    [Fact]
    public void AddUser_WhenClientDoesntHaveCreditLimit_ShouldThrowException()
    {
        try{
        //Arrange
        string name = "John";
        string surname = "Brzeczyszczykiewicz";
        string email = "smith@gmail.pl";
        DateTime dateOfBirth = new DateTime(1974, 2,2);
        int clientID = 3;

        //Act
        bool result = us.AddUser(name, surname, email, dateOfBirth, clientID);

        //Assert
        Assert.Fail();
        } catch(ArgumentException){

        }
    }
}