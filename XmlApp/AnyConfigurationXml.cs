using System;
using System.Xml.Serialization;

namespace Test
{
    [Serializable]
    [XmlRoot(ElementName = "AnyConfigurationXml", Namespace = "")]
    public partial class AnyConfigurationXml
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "CustomParameter")]
        public object CustomParameter { get; set; }

        [XmlElement(ElementName = "Booking")]
        public bool Booking { get; set; }

        [XmlElement(ElementName = "Logging")]
        public AnyConfigurationXmlLogging Logging { get; set; }
    }

    [Serializable]
    public partial class AnyConfigurationXmlLogging
    {
        [XmlElement(ElementName = "Enabled")]
        public bool Enabled { get; set; }

        [XmlElement(ElementName = "Default")]
        public AnyConfigurationXmlLoggingDefault Default { get; set; }

        [XmlElement(ElementName = "Queue")]
        public AnyConfigurationXmlLoggingQueue Queue { get; set; }

        [XmlElement(ElementName = "UseDailyLog")]
        public bool UseDailyLog { get; set; }

        [XmlElement(ElementName = "DataChecker")]
        public bool DataChecker { get; set; }
    }

    [Serializable]
    public partial class AnyConfigurationXmlLoggingDefault
    {
        [XmlElement(ElementName = "LogLevel")]
        public string LogLevel { get; set; }

        [XmlElement(ElementName = "Path")]
        public string Path { get; set; }

        [XmlElement(ElementName = "NamePostfix")]
        public string NamePostfix { get; set; }

        [XmlElement(ElementName = "NumOfFiles")]
        public byte NumOfFiles { get; set; }

        [XmlElement(ElementName = "FileSizeInMb")]
        public byte FileSizeInMb { get; set; }
    }

    [Serializable]
    public partial class AnyConfigurationXmlLoggingQueue
    {
        [XmlElement(ElementName = "StanadardLogQueueName")]
        public string StanadardLogQueueName { get; set; }

        [XmlElement(ElementName = "BatchSize")]
        public byte BatchSize { get; set; }

        [XmlElement(ElementName = "BatchTimeout")]
        public ushort BatchTimeout { get; set; }
    }
}