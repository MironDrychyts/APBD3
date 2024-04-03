using System;

namespace LegacyApp
{
    public class UserService : UserServiceMethods
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!CheckName(firstName,lastName) || !CheckEmail(email) || !CheckBirthDate(dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };


            user.HasCreditLimit = CreditLimitByStatus(client, user);

            
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
