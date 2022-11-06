using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using addressbook_web_tests;
using Newtonsoft.Json;

namespace addressbook_web_tests_data_generator
{
    public class Program 
    {
        public static void Main()
        {
            Console.WriteLine("Enter the type of generated data (groups or contacts)");
            string dataType = Console.ReadLine();
            Console.WriteLine("Enter the number of generated data");
            int countGeneratedObjects = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the file name");
            string filename = Console.ReadLine();

            Console.WriteLine("Enter the file format (csv, xml or json)");
            string fileformat = Console.ReadLine();

            int count = Convert.ToInt32(countGeneratedObjects);
            StreamWriter writer = new StreamWriter(filename);

            //Cases

            if (dataType == "groups")
            {
                //Groups 

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

                else if (fileformat == "json")
                {
                    writeToJsonFile(groups, writer);
                }
                else
                {
                    Console.WriteLine("Wrong format");
                }
            }

            else if (dataType == "contacts")
            {

                //Contacts

                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Middlename = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10)
                    });
                }

                if (fileformat == "csv")
                {
                    writeToCsvFile(contacts, writer);
                }
                else if (fileformat == "xml")
                {
                    writeToXmlFile(contacts, writer);
                }

                else if (fileformat == "json")
                {
                    writeToJsonFile(contacts, writer);
                }
                else
                {
                    Console.WriteLine("Wrong format");
                }
            }

            else
            {
                Console.WriteLine("Wrong datatype");
            }
         
          writer.Close();
        }

        //Groups methods

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

        static void writeToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        //Contacts methods

        static void writeToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine($"{contact.Firstname}," +
                             $"{contact.Lastname}," +
                             $"{contact.Middlename}," +
                             $"{contact.Nickname}," +
                             $"{contact.Company}," +
                             $"{contact.Address}," +
                             $"{contact.Hometel}," +
                             $"{contact.MobTel}," +
                             $"{contact.WorkTel}," +
                             $"{contact.Fax}," +
                             $"{contact.Email}," +
                             $"{contact.Email2}," +
                             $"{contact.Email3}," +
                             $"{contact.Notes}"
                             );
            }
        }

        static void writeToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}