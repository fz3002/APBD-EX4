namespace LegacyApp.tests
{
    public class FakeClientRepository : IClientRepository
    {
        public Client GetById(int IdClient)
        {
            return new Client();
        }
    }
}