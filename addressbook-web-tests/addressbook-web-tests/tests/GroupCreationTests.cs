using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture] // attribute
    public class GroupCreationTests : AuthTestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("name", "header", "footer");
            
            app.Groups.CreateGroup(group);
         

        }
        
    }
}
