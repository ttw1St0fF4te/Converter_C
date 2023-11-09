using Converter_C;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Converter_C
{
    class Program
    {
        Human human = new Human();

        static void Main()
        {
            Console.WriteLine("Введите путь к файлу, который хотите прочитать: ");
            Console.WriteLine("-----------------------------------------------");
            string path = Console.ReadLine();
            bool result = path.Contains(".txt");
            bool result1 = path.Contains(".json");
            bool result2 = path.Contains(".xml");

            if (result == true)
            {
                List<Human> txt_list = new List<Human>();
                string[] strings = File.ReadAllLines(path);
                for (int i = 0; i <= strings.Length; i += 3)
                {
                    Human human = new Human(strings[i], Convert.ToInt32(strings[i += 1]), strings[i += 2]);
                    txt_list.Add(human);
                }
                foreach (Human output_txt in txt_list) { Console.WriteLine(output_txt); }
            }

            if (result1 == true)
            {
                string text = File.ReadAllText(path);
                List<Human> humans = JsonConvert.DeserializeObject<List<Human>>(text);
                string _result = "";
                for (int i = 0; i < humans.Count; i++)
                    _result += $"{humans[i].m_strName}\n{humans[i].m_iAge}\n{humans[i].m_strColor}\n";
                Console.WriteLine(_result);
            }

            if (result2 == true)
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Human>));
                TextReader text_reader = new StreamReader(path);
                List<Human> xml_list;
                xml_list = (List<Human>)xmls.Deserialize(text_reader);
                text_reader.Close();
                foreach (Human i in xml_list)
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}