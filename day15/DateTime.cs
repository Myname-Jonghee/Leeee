using System.Globalization;

namespace DayTime
{
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("년도 : ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("월 :");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("일 : ");
        int day = int.Parse(Console.ReadLine());
        
        DateTime time = new DateTime(year, month,day);
        Console.WriteLine(time.ToString());
        
        Console.Write("현재시간 :");
        string Time =  DateTime.Now.ToString("yyyy - MM -dd  HH:mm:dd");
        Console.WriteLine(Time);
        }
}
