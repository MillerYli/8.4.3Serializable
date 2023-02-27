using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Serialization
{

    // Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }

        public string Email { get; set; }
        public Person(string name, long phonenumber, string email)
        {
            Name = name;
            PhoneNumber= phonenumber;
            Email = email;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            var person = new Person("Rex", 98767899, "hytdjj.mail");
            Console.WriteLine("Объект создан");

            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
            }
            
        }
    }
}