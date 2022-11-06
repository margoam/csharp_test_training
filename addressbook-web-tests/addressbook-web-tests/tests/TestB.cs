using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture] // attribute
    public class TestBase
    {

        protected ApplicationManager app;


        [SetUp]
        public void Setuptest()
        {

            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%%'&*()^:".ToCharArray();
            string word = "";
            for (int i = 0; i < max; i++)
            {
                int letter_num = rnd.Next(0, chars.Length - 1);

               
                word += chars[letter_num];
            }
            return word.ToString();
        }
    }

}


