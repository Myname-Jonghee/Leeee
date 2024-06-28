using System.Diagnostics.CodeAnalysis;

namespace average
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[3];
            double sum = 0;
            Console.Write("첫번째 과목 : ");
            score[0] = int.Parse(Console.ReadLine());
            Console.Write("두번째 과목 : ");
            score[1] = int.Parse(Console.ReadLine());
            Console.Write("세번째 과목 : ");
            score[2] = int.Parse(Console.ReadLine());

            for (int i = 0; i<score.Length; i++)
            {
                sum += score[i];
            }
            double ave = sum / score.Length;
            Console.WriteLine($"총점은 {sum} 이고 평균은 {ave}이다");
        }
    }
}
