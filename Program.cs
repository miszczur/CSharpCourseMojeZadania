
class Program
{
    static void Main(string[] args)
    {

        double highestResult = 0;
        double sum = 0;
        Console.WriteLine("Podaj wartości liczbowe: (0 kończy program).");
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double res))
            {
                if (res == 0.0)
                {
                    Console.WriteLine("Suma: " + sum);
                    Console.WriteLine("Największa liczba: " + highestResult);
                    break;
                }
                else
                {
                    sum += res;
                    if (res > highestResult) highestResult = res;
                }

            }

            else
            {
                Console.WriteLine("Nie podałeś liczby, przerywam program");
                break;
            }
        }
    }
}


