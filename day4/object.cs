using System.Data;

namespace culcu2
{

    class Calculator
    {
      
        public int mul (int a , int b)
        {
            return a * b;
        }
        public double div(int a , int b)
        {
             return a / b; 
         }
        public int sum(int a, int b)
        {
            return a + b;
        }
        public int min(int a, int b)
        {
            return a -b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //real world 
            Calculator cal = new Calculator();
            Console.WriteLine(cal.mul(5, 6));
            Console.WriteLine(cal.div(100, 5));

        }
    }
}
