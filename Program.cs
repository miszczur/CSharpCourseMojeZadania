
class Program
{
    static void Main(string[] args)
    { 

        DateTime currentDate = DateTime.Now;        

        Console.WriteLine("Podaj datę swoich urodzin w formacie dd.mm.yyyy:");
        string userInput = Console.ReadLine();

        DateTime userDateTime = DateTime.Parse(userInput);
        TimeSpan ts = currentDate - userDateTime;
        Console.WriteLine($"Minęło: {ts.TotalDays} dni");
    }
}


