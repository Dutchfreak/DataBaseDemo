using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataBaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //creating test data
            DataBase dataBase = new DataBase();

            dataBase.entries.Add(new Entry() { url = "YOOO", groupid = 1, userID = 1, PostDate = DateTime.Now });
            dataBase.entries.Add(new Entry() { url = "asd", groupid = 1, userID = 2, PostDate = DateTime.Now });
            dataBase.entries.Add(new Entry() { url = "aaaa", groupid = 2, userID = 3, PostDate = DateTime.Now });

            Console.WriteLine(dataBase.entries.Count); //should be 3




            //this part saves the stuff back to file. this is done when u did ur shit(searching/adding/whatever) just did it here first cause this is a demo
            XmlSerializer ser = new XmlSerializer(typeof(DataBase));
            FileStream file = File.Create("Database.XML");
            ser.Serialize(file, dataBase);
            file.Close();




            //now for demo shit ima yeet ma memory data
            dataBase = new DataBase();

            Console.WriteLine(dataBase.entries.Count); //should be 0







            //Now we reading or data back into memory
            XmlSerializer dser = new XmlSerializer(typeof(DataBase));
            file = File.Open("Database.XML",FileMode.Open);
            dataBase = (DataBase)dser.Deserialize(file);
            file.Close();
            Console.WriteLine(dataBase.entries.Count); //should be 3


            //Now if we wanted to find the entry with url "YOOO" we couldd use linQ

            Entry FoundEntry = dataBase.entries.FirstOrDefault(e => e.url == "YOOO");
            //we used firstordefault here. this is nice, if it doesnt find any match FoundEntry is null
            if(FoundEntry!=null)
            {
                Console.WriteLine(FoundEntry.userID); // should be 1
            }
            else
            {
                Console.WriteLine("No entry found");
            }


            Console.ReadKey();

        }
    }
}
