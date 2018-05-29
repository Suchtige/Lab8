using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary1;

namespace Binnary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bb = false;
            scroll scroll = new scroll(1, "Пиво", 12);
            product product = new product(1,"Балтика",scroll,0.7,70,"Балтика продакшн");

            List<product> listproduct = new List<product>();
            listproduct.Add(product);

            BinaryFormatter ff = new BinaryFormatter();
            Stream writer = new FileStream("Binary.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            ff.Serialize(writer, listproduct);
            writer.Close();
            bb = true;
            if (bb == true)
                Console.WriteLine("Поток байтов сделан");

            Stream reader = new FileStream("Binary.bin", FileMode.Open, FileAccess.Read, FileShare.None);
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
