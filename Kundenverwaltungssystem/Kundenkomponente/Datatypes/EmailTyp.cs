//using System;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Core.Metadata.Edm;
//using System.Text.RegularExpressions;

//namespace Kundenkomponente.DataAccessLayer.Datatypes
//{
//    [ComplexType]
//    public class EmailTyp
//    {
//        public string Email { get; }

//        public EmailTyp(string email)
//        {
//            if (EmailValid(email))
//                Email = email;
//            else
//                throw new ArgumentException($"Email {email} hat ein ungüliges Format.");
//        }

//        private static bool EmailValid(string mail)
//        {
//            return Regex.IsMatch(mail, @"^[\w\.\-]+@[\w\-]+\.(\w){2,3}$");
//        }
//    }
//}
