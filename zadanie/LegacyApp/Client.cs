namespace LegacyApp
{
    public class Client
    {
        public string Name { get;  set; }
        public int ClientId { get;  set; }
        public string Email { get;  set; }
        public string Address { get;  set; }
        public string Type { get; set; }
        
        
        // public void checkTypeOfClient(User user)
        // {
        //     if (Type == "VeryImportantClient")
        //     {
        //         user.HasCreditLimit = false;
        //     }
        //     else if (Type == "ImportantClient")
        //     {
        //         using (var userCreditService = new UserCreditService())
        //         {
        //             int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        //             creditLimit = creditLimit * 2;
        //             user.CreditLimit = creditLimit;
        //         }
        //     }
        //     else
        //     {
        //         user.HasCreditLimit = true;
        //         using (var userCreditService = new UserCreditService())
        //         {
        //             int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        //             user.CreditLimit = creditLimit;
        //         }
        //     }
        // }
    }
}