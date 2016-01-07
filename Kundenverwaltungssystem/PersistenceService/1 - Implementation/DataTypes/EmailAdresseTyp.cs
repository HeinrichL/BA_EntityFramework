using System;
using System.Text.RegularExpressions;

namespace PersistenceService._1___Implementation
{
    public partial class EmailAdresseTyp
    {
        public EmailAdresseTyp(string email)
        {
            if (EmailValid(email))
                Email = email;
            else
                throw new ArgumentException($"Email {email} hat ein ungüliges Format.");
        }

        public EmailAdresseTyp() { }

        private static bool EmailValid(string mail)
        {
            return Regex.IsMatch(mail, @"^[\w\.\-]+@[\w\-]+\.(\w){2,3}$");
        }
    }
}