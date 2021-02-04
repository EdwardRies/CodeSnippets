using System;
using HTH.Extensions;

namespace HTH.Extensions.Examples.FromJson
{
    /// 
    /// Maps properties from the Json object to the object type specified 
    /// by the FromJson extension. Missing properties are null or default 
    /// while additional properties are ignored. See ToJson  for details 
    /// on creating Json objects.
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            var contactAsJson = "{ name: 'Edward Ries' }";
            var contact = contactAsJson.FromJson();
            Console.Write(contact.Name);
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