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

            FileStream fileStreamXml = new FileStream(filePathXml, FileMode.OpenOrCreate);
            XmlSerializer xmlf = new XmlSerializer(typeof(Daten));
            //TODO: probleme wenn datei bereits existiert, manchmal
            xmlf.Serialize(fileStreamXml, daten);
            Console.WriteLine("Serialisiert als XML: " + filePathXml);
            fileStreamXml.Close();

            FileStream fileStreamXmlRead = new FileStream(filePathXml, FileMode.Open);
            Daten datenRead = (Daten)xmlf.Deserialize(fileStreamXmlRead);
            fileStreamXmlRead.Close();

            Console.WriteLine("Deserialisiert: " + datenRead.text);


            Console.WriteLine("--- Binär ---");
            string filePathBin = "test.bin";
            Console.Write("Input: ");
            string inputBin = Console.ReadLine();

            Daten datenBin = new Daten(inputBin);

            FileStream fileStreamBin = new FileStream(filePathBin, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fileStreamBin, datenBin);
            Console.WriteLine("Serialisiert als Binärdatei: " + filePathBin);
            fileStreamBin.Close();

            FileStream fileStreamBinRead = new FileStream(filePathBin, FileMode.Open);
            Daten datenBinRead = (Daten)bf.Deserialize(fileStreamBinRead);
            Console.WriteLine("Deserialisiert: " + datenBinRead.text);

            Console.WriteLine("Any key to close.");
            Console.ReadLine();
        }
    }
}
