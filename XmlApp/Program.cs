using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Test;

namespace XmlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathXmlFile=@"I:\C#\Тесты\Xml\XmlApp\AnyConfigurationXml.xml";
            string pathForSerialization = @"test.xml";

            AnyConfigurationXml anyConfigurationXml = new AnyConfigurationXml
            {
                Name = "Toni",
                Booking = true,
                CustomParameter = new object(),

                Logging = new AnyConfigurationXmlLogging
                {
                    DataChecker = true,
                    Enabled = true,
                    UseDailyLog = true,

                    Default = new AnyConfigurationXmlLoggingDefault
                    {
                        LogLevel = "first",
                        Path = @"I\C#\Test",
                        NamePostfix = "Test",
                        NumOfFiles = 200,
                        FileSizeInMb = 2
                    },

                    Queue = new AnyConfigurationXmlLoggingQueue
                    {
                        StanadardLogQueueName = "Test",
                        BatchSize = 10,
                        BatchTimeout = 60
                    }
                }
            };
            SerializationClass(anyConfigurationXml,pathForSerialization);

            List<string> сlassStructure = new List<string>();
            List<string> xmlStructure = new List<string>();
            List<string> listDifferences = new List<string>();


            xmlStructure = GetStructure(pathXmlFile);
            сlassStructure = GetStructure(pathForSerialization);

            for (int i = 0; i < xmlStructure.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < сlassStructure.Count; j++)
                {
                    
                    if (xmlStructure[i]== сlassStructure[j])
                    {
                        count++;
                    }
                }
                if (count==0)
                {
                    listDifferences.Add(xmlStructure[i]);
                }
            }

            foreach (var item in listDifferences)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static void SerializationClass(object ob, string pathForSerialization)
        {
            XmlSerializer formatter = new XmlSerializer(ob.GetType());
            using (FileStream fs = new FileStream(pathForSerialization, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ob);
            }
        }

        private static List<string> GetStructure(string path)
        {
            List<string> result = new List<string>();
            using (XmlReader xmlReader = XmlReader.Create(path))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        result.Add(xmlReader.Name);
                    }
                }
            }

            result.Sort();
            return result;
        }
    }
}
