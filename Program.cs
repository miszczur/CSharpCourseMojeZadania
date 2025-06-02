using Newtonsoft.Json;
namespace CSharpCourseMojeZadania
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = LoadPeople();
            var addresses = LoadAddresses();

            //JOIN
            //         var data = people.Join()

            //var nullAddr = addresses.FirstOrDefault(a => a.Id != a.PersonId);
            //var joinedData = people.Join(addresses,
            //    p => p.Id,
            //    a => a.PersonId,
            //    (person, address) => new { person.Name, address.City  });

            //foreach (var person in joinedData)
            //{
            //    Console.WriteLine($"Person Name: {person.Name}, City: {person.City}");
            //}

            //GROUPJOIN
            //var groupJoinedData = people.GroupJoin(addresses,
            //    p => p.Id,
            //    a => a.PersonId,
            //    (person, addresses) => new { person.Name, Addresses = addresses });

            //foreach (var element in groupJoinedData)
            //{
            //    Console.WriteLine($"Name : {element.Name}");
            //    foreach (var address in element.Addresses)
            //    {
            //        Console.WriteLine($"\t City: {address.City}, street: {address.Street}");
            //    }
            //}

            var joinedData = people.GroupJoin(
                addresses,
                person => person.Id,
                address => address.PersonId,
                (person, addressGroup) => new { person, addressGroup })
                .SelectMany(
                    temp => temp.addressGroup.DefaultIfEmpty(), // zapewnia LEFT JOIN
                    (temp, address) => new
                    {
                        Name = temp.person.Name,
                        City = address?.City ?? "Brak adresu" // obsługa nulli
                    });

            foreach (var person in joinedData)
            {
                Console.WriteLine($"Person Name: {person.Name}, City: {person.City}");
            }
            Console.WriteLine();
        }

        private static List<Person> LoadPeople()
        {
            var currentDir = @"C:\Users\jfmys\source\repos\CSharpCourseMojeZadania\Person\Person.json";
            var jsonFullPath = @"C:\Users\jfmys\source\repos\CSharpCourseMojeZadania\Person\People.json";

            var json = File.ReadAllText(jsonFullPath);

            return JsonConvert.DeserializeObject<List<Person>>(json);
        }
        private static List<Address> LoadAddresses()
        {
            var currentDir = @"C:\Users\jfmys\source\repos\CSharpCourseMojeZadania";
            var jsonFullPath = @"C:\Users\jfmys\source\repos\CSharpCourseMojeZadania\Person\Addresses.json";

            var json = File.ReadAllText(jsonFullPath);

            return JsonConvert.DeserializeObject<List<Address>>(json);
        }
    }
}