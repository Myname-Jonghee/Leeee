using System;

class PerfectNumber
{
    static void Main()
    {
        Console.WriteLine("정수를 입력해주세요 (<1000) :");
        int number = int.Parse(Console.ReadLine());


        if (Perfect(number))
        {
            Console.WriteLine("Y");
        }
        else
        {
            Console.WriteLine("N");
        }
    }

    static bool Perfect(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        int sum = 0;

        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }

        return sum == number;
    }
}
