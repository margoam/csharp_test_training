using System;
namespace addressbook_web_tests
{
    public class GroupTestBase : AuthTestBase
    {
       [TearDown]
       public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS_GROUPS)
            {
                List<GroupData> fromUI = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
            
        }
    }
}

