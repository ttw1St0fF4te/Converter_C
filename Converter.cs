using Converter_C;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Converter_C
{
    public class Files
    {
        public string m_strFormat;
        private bool m_bResult;
        private bool m_bResult1;
        private bool m_bResult2;

        public void ChoiceFormat(List<Human> humans)
        {
            Console.WriteLine("\nВведите путь до файла: ");
            Console.WriteLine("------------------------");

            m_strFormat = Console.ReadLine();
            m_bResult = m_strFormat.Contains(".txt");
            m_bResult1 = m_strFormat.Contains(".json");
            m_bResult2 = m_strFormat.Contains(".xml");

            if (m_bResult == true)
                Text(humans);
            if (m_bResult1 == true) 
                Json(humans);
            if (m_bResult2 == true) 
                Xml(humans);
        }

        public void Text(List<Human> humans)
        {
            Human human = new Human();
            foreach (Human vivod in humans)
                File.AppendAllText(m_strFormat, human.m_strName + "\n" + human.m_iAge + "\n" + human.m_strColor);
        }

        public void Json(List<Human> humans)
        {
            string json = JsonConvert.SerializeObject(humans);
            File.WriteAllText(m_strFormat, json);
        }

        public void Xml(List<Human> humans)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(List<Human>));
            using (FileStream fs = new FileStream(m_strFormat, FileMode.OpenOrCreate))
                xmls.Serialize(fs, humans);
        }
    }
}