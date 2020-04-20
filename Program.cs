using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Refelection1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("hat", 2, 7.99m, 23);
            Product p2 = new Product("shoes", 4, 99, new DateTime(2020, 10, 23), "Good shoes all seasons");
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine();

            GetAllProperties(p1);
            GetAllFields(p1);
            GetAllMethods(p1);
            GetAllConstructors(p1);
        }
        private static void GetAllProperties(object reflectionType)
        {
            Type objectType = reflectionType.GetType();
            var propertyInfo = objectType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("Properties");
            propertyInfo.ToList().ForEach(i => Console.Write(i +"\t"));
            Console.WriteLine();
        }

        private static void GetAllFields(object reflectionType)
        {
            Type objectType = reflectionType.GetType();
            var fieldInfo = objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("Fields");
            fieldInfo.ToList().ForEach(i => Console.Write(i + "\t"));
            Console.WriteLine();
        }
        private static void GetAllMethods(object reflectionType)
        {
            Type objectType = reflectionType.GetType();
            var methodInfo = objectType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("Methods");
            methodInfo.ToList().ForEach(i => Console.Write(i + "\t"));
            Console.WriteLine();
        }

        private static void GetAllConstructors(object reflectionType)
        {
            Type objectType = reflectionType.GetType();
            var constructorInfo = objectType.GetConstructors();

            Console.WriteLine("Constructors");
            constructorInfo.ToList().ForEach(i => Console.Write(i + "\t"));
            Console.WriteLine();
        }
    }
    
    class Product
    {
        private string Name { get; set; }
        private decimal Price { get; set; }
        private string Description { get; set; }
        private Int32 Id { get; set; }
        private DateTime Valability { get; set; }
        private bool InStock { get; set; }
        private Int16 Quatity { get; set; } = 20;

        public Product(string name, int id, decimal price, Int16 quantity)
        {
            Name = name;
            Price = price;
            Description = "no details on product";
            Id = id;
            Valability = DateTime.Today + TimeSpan.FromDays(365);
            InStock = true;
            Quatity = quantity;
        }

        public Product(string name, int id, decimal price, DateTime valability, string description = null)
        {
            Name = name;
            Price = price;
            Description = description;
            Id = id;
            Valability = valability;
            InStock = false;
        }
        public override string ToString()
        {
            return $" Product [INFO] : { Id} \t {Name} \t {Price} \t {Description} \t {Valability} \t {InStock} \t {Quatity}";  
        }
    }
}