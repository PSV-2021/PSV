using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using Integration.Shared_Model;
using Microsoft.EntityFrameworkCore;

namespace Integration.Drugstore_Interaction.Model.ValueObjects
{
    [Owned]
    public class Email : ValueObject
    {
        public string EmailValue { get; private set; }

        public Email(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                EmailValue = email;
            else
                throw new ArgumentException("Email is not valid.");
        }

        public Email()
        {

        }

        public Email ChangeEmail(string email)
        {
            try
            {
                return new Email(email);
            }
            catch
            {
                throw new ArgumentException("Entered email is not valid.");
            }
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailValue;
        }
    }
}
