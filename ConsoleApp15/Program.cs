using System;
class Program
{
    static void Main()
    {
        try
        {
            Money money1 = new Money(10, 50);
            Money money2 = new Money(5, 75);
            Money result;

            result = money1 + money2;
            Console.WriteLine($"Сумма: {result}");

            result = money1 - money2;
            Console.WriteLine($"Разность: {result}");

            result = money1 / 2;
            Console.WriteLine($"Деление: {result}");

            result = money1 * 2;
            Console.WriteLine($"Умножение: {result}");

            result = ++money1;
            Console.WriteLine($"Увеличение на 1 копейку: {result}");

            result = --money1;
            Console.WriteLine($"Уменьшение на 1 копейку: {result}");

            Console.WriteLine($"money1 меньше money2: {money1 < money2}");
            Console.WriteLine($"money1 больше money2: {money1 > money2}");
            Console.WriteLine($"money1 равно money2: {money1 == money2}");
        }
        catch (BankruptException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
