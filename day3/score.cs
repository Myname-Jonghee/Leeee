namespace score1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("점수를 입력하세요 : ");
            int score = int.Parse(Console.ReadLine());
            
            {
                if(score >= 90)
                {
                    Console.WriteLine("A학점입니다");
                }
                else if (score >= 80)
                {
                    Console.WriteLine("B학점입니다");
                }
                else if(score >= 70)
                {
                    Console.WriteLine("C학점입니다");
                }
                else if(score >= 60)
                {
                    Console.WriteLine("D학점입니다");
                }
                else
                {
                    Console.WriteLine("F학점입니다");
                }
            }
        }
    }
}
