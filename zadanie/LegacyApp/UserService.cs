using System;

namespace LegacyApp
{
    public class UserService
    {

        private IClientRepository _clientRepository;

        private IUserCreditService _userCreditService;

        private IUserDataAccess _userDataAccess;

        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _userDataAccess = new AdapterUserDataAccess();
        }

        public UserService(IClientRepository clientRep, IUserCreditService userCreditService, IUserDataAccess userDataAccess)
        {
            _clientRepository = clientRep;   
            _userCreditService = userCreditService;
            _userDataAccess = userDataAccess;
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {            
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            
            if (now.Month < dateOfBirth.Month || 
                (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            if (age < 21)
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if(!user.Validate()) return false;

            switch (client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                {
    
                    var creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit *= 2;
                    user.CreditLimit = creditLimit;

                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    var creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;

                    break;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            _userDataAccess.AddUser(user);
            return true;
        }
    }
}
