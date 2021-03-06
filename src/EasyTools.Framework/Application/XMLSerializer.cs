using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EasyTools.Framework.Application
{
    public class XMLSerializer
    {
        public static void WriteDataContractToFile<T>(T source, string file)
        {
            if (source == null || string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException("El objeto a serializar o el path del archivo a guardar no pueden ser nulo");
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            using (var writer = XmlWriter.Create(file, new XmlWriterSettings { Indent = true, NamespaceHandling = NamespaceHandling.OmitDuplicates }))
            {
                serializer.WriteObject(writer, source);
            }
        }

        public static T ReadFileToDataContract<T>(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException("El path del archivo a leer no pueden ser nulo");
            T instance;
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            using (var writer = XmlReader.Create(file))
            {
                instance = (T)serializer.ReadObject(writer);
            }
            return instance;
        }

        public static string SerializeToString<T>(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException("El objeto a serializar no pueden ser nulo");

            StringBuilder builder = new StringBuilder();

            using (XmlWriter xmlWriter = XmlTextWriter.Create(builder))
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(writer, instance);
                }
            }

            return builder.ToString();
        }

        public static T DeserializeFromString<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentNullException("xml");

            T instance;

            using (XmlReader xmlReader = XmlReader.Create(new StringReader(xml)))

            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader(xmlReader))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                instance = (T)serializer.ReadObject(reader);
            }

            return instance;
        }

    }
}