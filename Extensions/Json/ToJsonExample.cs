using System;
using HTH.Extensions;

namespace HTH.Extensions.Examples.ToJson
{
   
    /// 
    /// Serializes an object itno a Json string. See FromJson 
    /// for deserializing Json objects to a class.
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            var contact = new Contact(
                "Edward Ries",
                "800 West Main St",
                "New Albany",
                "IN",
                "47150-4340");
            var contactAsJson = contact.ToJson();
            Console.WriteLine(contactAsJson);
        }
    }

    /// 
    /// Example Contact class
    /// 
    public class Contact
    {
        public Contact(string name, string street, string city, string state, string zipCode)
        {
            Name = name;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}