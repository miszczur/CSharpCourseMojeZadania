namespace CSharpCourseMojeZadania
{ 
  class Program
   {
        private static void DisplayInformation()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Display Contact by Number");
            Console.WriteLine("3. Display All Contacts");
            Console.WriteLine("4. Search Contacts by Name");
            Console.WriteLine("To exit, press x. ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("This is a simple phone book application to manage contacts.");

            DisplayInformation();

            var choice = Console.ReadLine();
            var phoneBook = new PhoneBook();
            while (true)
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter contact name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter contact phone number: ");
                        var number = Console.ReadLine();
                        var newContact = new Contact(name, number);
                        phoneBook.AddContact(newContact);
                        break;

                    case "2":
                        Console.WriteLine("Enter number to search:");
                        var numberToSearch = Console.ReadLine();
                        phoneBook.DisplayContact(numberToSearch);
                        break;

                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;

                    case "4":
                        Console.WriteLine("Give name to search:");
                        var nameSearch = Console.ReadLine();
                        phoneBook.DisplayMatchingContacts(nameSearch);
                        break;

                    case "x":
                        Console.WriteLine("Exiting the application.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Select new operation:");
                DisplayInformation();
                choice = Console.ReadLine();
            }
        }
   }
}