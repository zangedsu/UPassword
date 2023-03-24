using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPassword.Models
{
    internal class Password
    {
        public string Name { get; private set; }
        public string URL { get; private set; }
        public string Login { get; private set; }
        public string PasswordText { get; private set; }
        public string Additional { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public Password(string name,string url, string login, string password, string additional, string phone, string email)
        {
            Name = name;
            URL = url;
            Login = login;
            PasswordText = password;
            Additional = additional;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            // +"|" + InProcess + "|"
            return Name;
        }
    }
}
