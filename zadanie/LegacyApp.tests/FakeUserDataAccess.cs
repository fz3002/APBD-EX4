namespace LegacyApp.tests
{
    public class FakeUserDataAccess : IUserDataAccess
    {
        public void AddUser(User user)
        {
            System.Console.WriteLine("Adding user " + user);
        }
    }
}