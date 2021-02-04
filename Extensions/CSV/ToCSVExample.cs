using System;
using System.Collections.Generic
using System.ComponentModel;
using HTH.Extensions;

namespace HTH.Extensions.Examples.GetDescription
{
    /// 
    /// Examples of using the ToCSV extension
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            var MyContacts = new List<Contact>();
            var contact = new Contact(
                "Edward Ries",
                "800 West Main St",
                "New Albany",
                "IN",
                "47150-4340");
            
            MyContacts.Add(contact);

            var csvContactString = MyList.ToCSV("Name, Street", true, "MM/dd/yy");

            Console.Write(csvContactString);
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
}
