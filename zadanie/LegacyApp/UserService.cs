using System;

namespace LegacyApp
{
    public class UserService
    {
        
        private bool CheckIfFirstNameOrLastNameIsNull(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }

        private bool CheckIfEmailIsValid(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }

        private bool IsEnoughtOld(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;

        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            
            if (!CheckIfFirstNameOrLastNameIsNull(firstName, lastName) || 
                !CheckIfEmailIsValid(email) || 
                !IsEnoughtOld(dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User(client, dateOfBirth, email, firstName, lastName);
            
            if (!user.CheckCreditLimitIsUnder500())
            {
                return false;
            }
            
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
