using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Converter_C
{
    public class Converter
    {
        public void TextToJson(string path)
        {
            List<Human> humans = new List<Human>();

            string[] FileInternals = File.ReadAllLines(path);

            Human human1 = new Human(FileInternals[0], int.Parse(FileInternals[1]), FileInternals[2]);
            Human human2 = new Human(FileInternals[3], int.Parse(FileInternals[4]), FileInternals[5]);

            humans.Add(human1);
            humans.Add(human2);

            string json = JsonConvert.SerializeObject(humans);
            File.WriteAllText(path, json);

            Console.WriteLine("Completed.");
        }

        public void TextToXml(string path)
        {
            List<Human> humans = new List<Human>();

            string[] FileInternals = File.ReadAllLines(path);

            Human human1 = new Human(FileInternals[0], int.Parse(FileInternals[1]), FileInternals[2]);
            Human human2 = new Human(FileInternals[3], int.Parse(FileInternals[4]), FileInternals[5]);

            humans.Add(human1);
            humans.Add(human2);

            File.WriteAllText(path, File.ReadAllText(path));

            XmlSerializer xml = new XmlSerializer(typeof(List<Human>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) { xml.Serialize(fs, humans); }

            Console.WriteLine("Completed.");
        }

        public void JsonToText(string path)
        {
            string txt = File.ReadAllText(path);
            List<Human> humans = JsonConvert.DeserializeObject<List<Human>>(txt);

            string result = $"{humans[0].m_strName}\n{humans[0].m_iAge}\n{humans[0].m_strColor}\n" +
                $"{humans[1].m_strName}\n{humans[1].m_iAge}\n{humans[1].m_strColor}\n";

            File.WriteAllText(path, result);

            Console.WriteLine("Completed.");
        }

        public void XmlToText(string path)
        {
            List<Human> humans = new List<Human>();

            XmlSerializer xml = new XmlSerializer(typeof(List<Human>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
                humans = (List<Human>)xml.Deserialize(fs);

            string result = $"{humans[0].m_strName}\n{humans[0].m_iAge}\n{humans[0].m_strColor}\n" +
                $"{humans[1].m_strName}\n{humans[1].m_iAge}\n{humans[1].m_strColor}\n";

            File.WriteAllText(path, result);

            Console.WriteLine("Completed.");
        }
    }
}
