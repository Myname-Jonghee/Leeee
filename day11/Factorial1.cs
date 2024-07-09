namespace Factorial1
{
    internal class Program
    {
        static int Factorial (int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int n = 4;
            Console.WriteLine(Factorial (n));
        }
    }
}
