namespace method_02
{
    internal class Program
    {
        static int[] Inscore()
        {
            int[] score = new int [3];
            for(int i = 0; i<score.Length; i++)
            {
                score[i] = int.Parse(Console.ReadLine());
            }
            return score;
        }
        static int Getsum(int[] score)
        {
            int sum = 0;

            for(int i = 0; i<3; i++)
            {
                sum+= score[i];
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[] score =  Inscore();

            int sum = Getsum(score);

            Console.WriteLine($"총점 {sum}");
        }
    }
}
