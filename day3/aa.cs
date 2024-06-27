# Leeee
using System.Diagnostics.CodeAnalysis;

namespace examapp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 100; i >=0; i--)
            {
                if (i % 2 == 0)//짝수
                {
                    Console.Write($"{i}");
                }

            }
            Console.WriteLine(); //줄 바꿈

            int j = 100;
            
            while (j<=100 )
            {
                j--; //-1증가
                if (j % 2 == 1 )//홀수
                {
                   
                    Console.Write($"{j}");
                    
                }
                
            }
           
        }
    }
}
