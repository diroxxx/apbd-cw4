using System;

namespace LegacyApp
{
    public class User
    {
        public Client Client { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public string EmailAddress { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public bool HasCreditLimit { get;  set; }
        public int CreditLimit { get;  set; }

        public User(Client client, DateTime dateOfBirth, string emailAddress, string firstName, string lastName)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            
            SetLimits();
            
        }

        private void SetLimits()
        {
            if (Client.Type == "VeryImportantClient")
            {
                HasCreditLimit = false;
            }
            else if (Client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    creditLimit = creditLimit * 2;
                    CreditLimit = creditLimit;
                }
            }
            else
            {
                HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    CreditLimit = creditLimit;
                }
            }
        }

        public bool CheckCreditLimitIsUnder500()
        {
            if (HasCreditLimit && CreditLimit < 500)
            {
                return false;
            }

            return true;
        }
    }
    
    
    
}