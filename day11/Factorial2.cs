namespace Recursive01

{

    internal class Program

    {

        static long[] arr;

        static void Main(string[] args)

        {

            Console.Write("나열 할 숫자: ");

            int n = int.Parse(Console.ReadLine());

            arr = new long[n+1];

            arr[0] = 1;



            for (int i = 1; i <= n; i++)



            {

                arr[i] = i*arr[i-1];

            }

            Console.WriteLine(arr[n]);

        }

    }

}
