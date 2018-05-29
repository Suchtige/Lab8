using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using ClassLibrary1;

namespace JSON
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

            DataContractJsonSerializer ff = new DataContractJsonSerializer(typeof(List<product>));
            Stream writer = new FileStream("Json.json", FileMode.Create, FileAccess.Write, FileShare.None);
            ff.WriteObject(writer, listproduct);
            writer.Close();
            bb = true;
            if (bb == true)
                Console.WriteLine("Json - готов");

            Stream reader = new FileStream("Json.json", FileMode.Open, FileAccess.Read, FileShare.None);
            List<product> DesertListWorker = ff.ReadObject(reader) as List<product>;
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
