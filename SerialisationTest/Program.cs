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
            Console.Write("Input: ");
            string input = Console.ReadLine();

            Daten daten = new Daten(input);

            FileStream fileStreamBin = new FileStream("test.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStreamBin, daten);
            fileStreamBin.Close();

            FileStream fileStreamXml = new FileStream("test.xml", FileMode.OpenOrCreate);
            XmlSerializer xmlf = new XmlSerializer(typeof(Daten));
            xmlf.Serialize(fileStreamXml, daten);
            fileStreamXml.Close();

            FileStream fileStreamXmlRead = new FileStream("test.xml", FileMode.Open);
            Daten datenRead = (Daten)xmlf.Deserialize(fileStreamXmlRead);
            fileStreamXmlRead.Close();
        }
    }
}
