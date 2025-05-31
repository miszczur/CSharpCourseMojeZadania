

public class TemperatureConverter
{
    public static void ConvertCelsiusToFahrenheit(double celsius, out double fahrenheit)
    {
       fahrenheit = celsius * 1.8 + 32;
    }

    public static void ConvertFahrenheitToCelsius(double fahrenheit, ref double celsius)
    {
        celsius = (fahrenheit - 32) / 1.8;
    }
}
class Program
{
    static void Main(string[] args)
    {
    }
}


/*ref i out
Zadanie praktyczne: Konwersja temperatury

Opis: Twoim zadaniem jest napisanie programu, który będzie konwertować temperaturę z jednej skali (np. Celsiusza) na inną skalę (np. Fahrenheit). Użyj parametrów ref i out do przekazywania wyników z funkcji.

Wymagania:

Zaimplementuj klasę TemperatureConverter zawierającą dwie metody: ConvertCelsiusToFahrenheit i ConvertFahrenheitToCelsius.

Wykorzystaj formuły konwersji odpowiednie dla każdej skali.*/