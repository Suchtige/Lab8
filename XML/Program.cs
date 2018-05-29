using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using ClassLibrary1;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bb = false;
            scroll scroll = new scroll(1, "Пиво", 12);
            product product = new product(1, "Балтика", scroll, 0.7, 70, "Балтика продакшн");

            List<product> listproduct = new List<product>();
            listproduct.Add(product);

            XmlSerializer ff = new XmlSerializer(typeof(List<product>));

            Stream writer = new FileStream("Xml.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            ff.Serialize(writer, listproduct);
            writer.Close();
            bb = true;
            if (bb == true)
                Console.WriteLine("Xml - готов");

            Stream reader = new FileStream("Xml.xml", FileMode.Open, FileAccess.Read, FileShare.None);
            List<product> DesertListWorker = ff.Deserialize(reader) as List<product>;
            reader.Close();

            foreach (product w in DesertListWorker)
            {
                if (w is product)
                {
                    (w as product).info();
                }
            }
            Console.ReadLine();
        }
    }
}
