using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace SerialisationTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("--- XML ---");
            string filePathXml = "test.xml";

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Daten daten = new Daten(input);

            SerializeXml(daten, filePathXml);
            daten = DeserializeXml(filePathXml);

            Console.WriteLine("Deserialisiert: " + daten.text);



            Console.WriteLine("--- Binär ---");
            string filePathBin = "test.bin";

            Console.Write("Input: ");
            string inputBin = Console.ReadLine();
            Daten datenBin = new Daten(inputBin);

            SerializeBinary(datenBin, filePathBin);
            datenBin = DeserializeBinary(filePathBin);

            Console.WriteLine("Deserialisiert: " + datenBin.text);



            Console.WriteLine("Any key to close.");
            Console.ReadLine();
        }

        private static void SerializeXml(Daten daten, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            XmlSerializer xmlf = new XmlSerializer(typeof(Daten));
            //TODO: probleme wenn datei bereits existiert, manchmal
            xmlf.Serialize(fileStream, daten);
            Console.WriteLine("Serialisiert als XML: " + filePath);
            fileStream.Close();
        }

        private static Daten DeserializeXml(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            XmlSerializer xmlf = new XmlSerializer(typeof(Daten));
            Daten daten = (Daten)xmlf.Deserialize(fileStream);
            fileStream.Close();

            return daten;
        }

        private static void SerializeBinary(Daten daten, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStream, daten);
            Console.WriteLine("Serialisiert als Binärdatei: " + filePath);
            fileStream.Close();
        }

        private static Daten DeserializeBinary(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Daten daten = (Daten)bf.Deserialize(fileStream);
            fileStream.Close();

            return daten;
        }
    }
}
