using System;
namespace addressbook_web_tests
{
    public class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string password) // constructor
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}

