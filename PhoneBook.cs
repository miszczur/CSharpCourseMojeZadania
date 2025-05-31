using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSharpCourseMojeZadania
{
    
    public class PhoneBook
    {
        public List<Contact> Contacts { get; set; } = new();
        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
        }
        private void DisplayContactDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }
        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void DisplayAllContacts()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }
            Console.WriteLine("Contacts in Phone Book:");
            DisplayContactDetails(Contacts);
        }
        public void DisplayContact(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.PhoneNumber == number);
            if (contact != null)
            {
                DisplayContactDetails(contact);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        public void DisplayMatchingContacts(string pattern)
        {
            var matchingContacts = Contacts.Where(c => c.Name.Contains(pattern)).ToList();
            DisplayContactDetails(matchingContacts);
        }
    }
}
