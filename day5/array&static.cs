using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace getscore
{

    internal class Program

    {

        //성적 입력 함수를 만들어 주세요. 3과목

        public static int[] InputThreeSocre()

        {
            int[] score = new int[3];
            for(int i = 0; i < score.Length; i++)
            {
                Console.Write("과목을 입력하세요 :");
                  score[i] = Int32.Parse(Console.ReadLine());
            }
            return score;

        }

        static int TotalScoer(int[] arr)

        {

            int totalScore = 0;

            for (int i = 0; i < arr.Length; i++)

            {
                totalScore += arr[i];
            }

            return totalScore;

        }

        static double GetAvg(int totalScore)

        {
           
            double avg = 0.0;
            avg = totalScore / 3.0;

            return avg;

        }



        static void Main(string[] args)

        {
            int[] score = InputThreeSocre();
            int totalscore = TotalScoer(score);
            double avg = GetAvg(totalscore);


          
            Console.WriteLine($"최종 점수는 {totalscore}");
            Console.WriteLine($"과목 평균은 {avg}");

        }

    }

}
