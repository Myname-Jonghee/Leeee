using System.Diagnostics;

namespace culcu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("첫 번째 숫자:");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("연산자 선택 : ");
            char b = char.Parse(Console.ReadLine());

            Console.Write("두 번째 숫자:");
            double num2 = double.Parse(Console.ReadLine());


            switch (b)
            {
                case '+':
                    double sum = 0;
                    sum = num1 + num2;
                    Console.Write(sum);
                    break;

                case '-':
                    double minor = 0;
                    minor = num1 - num2;
                    Console.Write(minor);
                    break;
                case '*':
                    double mutil = 0;
                    mutil = num1 * num2;
                    Console.Write(mutil);
                    break;
                case '/':
                    double sutil = 0;
                    sutil = num1 / num2;
                    Console.Write(sutil);
                    break;
                default:
                    Console.Write("잘못된 식입니다");
                    break;

            }
                    
        }
    }
}
