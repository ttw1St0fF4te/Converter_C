namespace Converter_C
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь к файлу, который хотите прочитать: "); //C:\Users\User\Desktop\lalala.txt
            Console.WriteLine("-----------------------------------------------");
            string path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите операцию: ");
            Console.WriteLine("1 - Text to Json");
            Console.WriteLine("2 - Text to Xml");
            Console.WriteLine("3 - Json to Text");
            Console.WriteLine("4 - Xml to Text");
            int answer = int.Parse(Console.ReadLine());

            Converter converter = new Converter();

            switch (answer)
            {
                case 1:
                    converter.TextToJson(path);
                    break;
                case 2:
                    converter.TextToXml(path);
                    break;
                case 3:
                    converter.JsonToText(path);
                    break;
                case 4:
                    converter.XmlToText(path);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }     
        }
    }
}
