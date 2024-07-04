using System;

class Program
{
static void Main()
{
Console.WriteLine("1에서 100까지의 소수:");
    for (int num = 2; num <= 100; num++)
    {
        if (IsPrime(num))
        {
            Console.Write(num + " ");
        }
    }
}

static bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;

    for (int i = 2; i * i <= number; i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }

    return true;
}

}
