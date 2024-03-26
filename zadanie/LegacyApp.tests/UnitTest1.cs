namespace LegacyApp.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        UserService us = new UserService();
        us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(1982, 2,2), 1);
        Client client = new Client();
        var name = client.Name;
        var id = client.ClientId;
        var email = client.Email;
        var address = client.Address;
        ClientRepository cr = new ClientRepository();
        User user = new User();
    }
    [Fact]
    public void Test2()
    {
        UserService us = new UserService();
        us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2048, 2,2), 1);
        us.AddUser("Jan", "Kowalski", "kowalskiwppl", new DateTime(1982, 2,2), 1);
        us.AddUser(null, "Kowalski", "kowalski@wp.pl", new DateTime(1982, 2,2), 1);
        us.AddUser("Jan", null, "kowalski@wp.pl", new DateTime(1982, 2,2), 1);
        us.AddUser("Jan", "Kowalski", "kowalskiwp.pl", new DateTime(1982, 2,2), 1);
        us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2010, 4,2), 1);
        us.AddUser("Jan", "Kowalski", "kowalski@wp.pl", new DateTime(2010, 3,30), 1);
    }
        
    [Fact]
    public void Test3()
    {
        UserService us = new UserService();
        us.AddUser("Mariusz", "Malewski", "malewski@gmail.pl", new DateTime(1974, 2,2), 2);
        us.AddUser("John", "Smith", "smith@gmail.pl", new DateTime(1974, 2,2), 3);
    }
}