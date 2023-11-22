namespace Converter_C
{
    public class Human
    {
        public string m_strName;
        public int m_iAge;
        public string m_strColor;
        public List<Human> m_lHuman;

        public Human() { }

        public Human(string name, int age, string color)
        {
            m_strName = name;
            m_iAge = age;
            m_strColor = color;
        }
    }
}
