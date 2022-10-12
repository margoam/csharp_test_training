using System;
namespace addressbook_web_tests
{
    public class AccountData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountData(string username, string password) // constructor
        {
            this.Username = username;
            this.Password = password;
        }

    }
}

