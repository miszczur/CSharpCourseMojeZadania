class EvenNumberGenerator
{
    public IEnumerable<int> GenerateEvenNumbers()
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            if (i % 2 == 0) yield return i;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {

        //Zadania będą na oddzielnych branchach
    }
}


/*
 * Opis: Twoim zadaniem jest napisanie programu, który będzie generował kolejne liczby parzyste.
 * Użyj konstrukcji yield do generowania tych liczb.

Wymagania:

Zaimplemenuj klasę EvenNumberGenerator zawierającą metodę GenerateEvenNumbers, która będzie generować kolejne liczby parzyste.

Użyj konstrukcji yield w metodzie GenerateEvenNumbers do generowania liczb parzystych.
*/