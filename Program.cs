/*
 * Zadanie praktyczne: Dziedziczenie w hierarchii pojazdów

Opis: Twoim zadaniem jest stworzenie hierarchii klas reprezentujących różne rodzaje pojazdów. Klasa nadrzędna powinna zawierać podstawowe metody i właściwości, a klasy pochodne powinny dziedziczyć te cechy i dodatkowo implementować swoje.

Wymagania:

Program powinien być napisany w języku C#.

Utwórz klasę nadrzędną Vehicle zawierającą właściwość Model (nazwa pojazdu) oraz abstrakcyjne metody Start i Stop.

Utwórz co najmniej dwie klasy dziedziczące po klasie Vehicle (np. Car i Motorcycle), które implementują metody Start i Stop w sposób odpowiedni dla każdego pojazdu.

Metoda Start powinna wypisać do konsoli "Starting the car: {Model}" i analogicznie "Starting the motorcycle: {Model}", dla odpowiedniej klasy

Metoda Stop powinna wypisać do konsoli "Stopping the car: {Model}" i analogicznie "Stopping the motorcycle: {Model}", dla odpowiedniej klasy
 * 
 */
class Program
{

    public abstract class Vehicle
    {
        // TODO: zdefiniuj wspólne części klas pochodnych
        public string Model { get; set; }
        abstract public void Start();
        abstract public void Stop();

    }

    public class Car : Vehicle
    {
        // TODO: Uzupełnij implementację klasy Car, aby dziedziczyła po klasie Vehicle,
        // posiadała implementacje metod Start i Stop, oraz dodatkowe metody związane z samochodem.
        public override void Start()
        {
            Console.WriteLine($"Starting the car: {Model}");
        }
        public override void Stop()
        {
            Console.WriteLine($"Stopping the car: {Model}");
        }
    }

    public class Motorcycle : Vehicle
    {
        // TODO: Uzupełnij implementację klasy Motorcycle, aby dziedziczyła po klasie Vehicle,
        // posiadała implementacje metod Start i Stop, oraz dodatkowe metody związane z motocyklem.
        public override void Start()
        {
            Console.WriteLine($"Starting the motorcycle: {Model}");
        }
        public override void Stop()
        {
            Console.WriteLine($"Stopping the motorcycle: {Model}");
        }
    }
    static void Main(string[] args)
    {

        //Zadania będą na oddzielnych branchach
    }
}


