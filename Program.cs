namespace CSharpCourseMojeZadania
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a simple phone book application to manage contacts.");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Display Contact by Number");
            Console.WriteLine("3. Display All Contacts");
            Console.WriteLine("4. Search Contacts by Name");
            var choice = Console.ReadLine();
            var phoneBook = new PhoneBook();
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


                    break;
                case "3":

                    break;
                case "4":

                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
                }
            }
        } 
    }
}