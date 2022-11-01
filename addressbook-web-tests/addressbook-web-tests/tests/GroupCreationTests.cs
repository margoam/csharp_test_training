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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(15))
                {
                    Header = GenerateRandomString(50),
                    Footer = GenerateRandomString(50)
                });
            }
            return groups;
        }

       

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
        
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetCountGroups());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
        
    }
}
