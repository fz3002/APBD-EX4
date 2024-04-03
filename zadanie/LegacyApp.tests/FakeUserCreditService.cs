namespace LegacyApp.tests
{
    public class FakeUserCreditService : IUserCreditService
    {
        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            return 500;
        }
    }
}