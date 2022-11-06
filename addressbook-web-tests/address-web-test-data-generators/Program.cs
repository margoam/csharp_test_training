using System.Xml;
using System.Xml.Serialization;
using addressbook_web_tests;

namespace addressbook_web_tests_data_generator
{
    public class Program
    {
        public static void Main()
        {
            //string dataType = Console.ReadLine();
            Console.WriteLine("Enter the number of generated data");
            int countGeneratedObjects = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the file name");
            string filename = Console.ReadLine();

            Console.WriteLine("Enter the file format (csv or xml)");
            string fileformat = Console.ReadLine();

            int count = Convert.ToInt32(countGeneratedObjects);
            StreamWriter writer = new StreamWriter(filename);

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {

                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(15),
                    Footer = TestBase.GenerateRandomString(15),
                });
            }
            if (fileformat == "csv")
            {
                writeToCsvFile(groups, writer);
            }
            else if (fileformat == "xml")
            {
                writeToXmlFile(groups, writer);
            }
            else
            {
                Console.WriteLine("Wrong format");
            }
         
          writer.Close();
        }

        static void writeToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); 
        }
    }
}