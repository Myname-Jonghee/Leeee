using System;
using System.ComponentModel.Design;
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
                    Console.WriteLine(sum);
                    break;

                case '-':
                    double minor = 0;
                    minor = num1 - num2;
                    Console.WriteLine(minor);
                    break;
                case '*':
                    double mutil = 0;
                    mutil = num1 * num2;
                    Console.WriteLine(mutil);
                    break;
                case '/':
                    double sutil = 0;
                    sutil = num1 / num2;
                    Console.WriteLine($"{ sutil:F2}");
                    break;
                default:
                    Console.Write("잘못된 식입니다");
                    break;

            }

            Console.Write("계속 계산하시겠습니까? y/n : ");
            char ask = char.Parse(Console.ReadLine());

            

            Console.Write("첫 번째 숫자:");
            double num3 = double.Parse(Console.ReadLine());

            Console.Write("연산자 선택 : ");
            char c = char.Parse(Console.ReadLine());

            Console.Write("두 번째 숫자:");
            double num4 = double.Parse(Console.ReadLine());

            if (ask == 'y')
            {
                switch (b)
                {
                    case '+':
                        double sum1 = 0;
                        sum1 = num1 + num2;
                        Console.Write(sum1);
                        break;

                    case '-':
                        double minor1 = 0;
                        minor1 = num1 - num2;
                        Console.Write(minor1);
                        break;
                    case '*':
                        double mutil1 = 0;
                        mutil1 = num1 * num2;
                        Console.Write(mutil1);
                        break;
                    case '/':
                        double sutil1 = 0;
                        sutil1 = num1 / num2;
                        Console.Write($"{sutil1:F2}");
                        break;
                    default:
                        Console.Write("잘못된 식입니다");
                        break;

                }
            }
            else if (ask == 'n')
            {
                Console.Write("계산을 종료합니다");

            }
            }
           
        }
    }
