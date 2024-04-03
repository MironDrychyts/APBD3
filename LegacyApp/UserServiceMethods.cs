using System;


namespace LegacyApp;

public class UserServiceMethods
{
    public static bool CheckName(string firstName, string lastName)
    {
        
        return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);

    }

    public static bool CheckEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public static bool CheckBirthDate(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age >= 21;
    }

    

    public static bool CreditLimitByStatus(Client client, User user)
    {
        if (client.Type == "VeryImportantClient")
            return false;
        using (var userCreditService = new UserCreditService())
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            if (client.Type == "ImportantClient")
                creditLimit *= 2;
            user.CreditLimit = creditLimit;
        }
        return true;
    }

  
    
}