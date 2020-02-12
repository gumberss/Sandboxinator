using System;
using System.IO;
using System.Xml.Serialization;

namespace Learning.Serialization
{
    public class MyXmlSerializer
    {
        public String Serialize<T>(T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            TextWriter writer = new StringWriter();

            serializer.Serialize(writer, data);

            string xml = writer.ToString();

            return xml;
        }

        public T Desserialize<T>(String xml)
        {
            TextReader reader = new StringReader(xml);

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            return (T)serializer.Deserialize(reader);
        }
    }
}
