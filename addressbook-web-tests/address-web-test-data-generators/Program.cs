using addressbook_web_tests;

namespace addressbook_web_tests_data_generator
{
    public class Program
    {
        public static void Main()
        {
            int countgroups = Convert.ToInt32(Console.ReadLine());
            string filename = Console.ReadLine();
            int count = Convert.ToInt32(countgroups);
            StreamWriter writer = new StreamWriter(filename);
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(50),
                    TestBase.GenerateRandomString(50)
                    ));
            }
          writer.Close();
        }
    }
}