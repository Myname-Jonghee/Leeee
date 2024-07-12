using System.Security.Cryptography.X509Certificates;

namespace oop07
{
class Emergency
{
    public void Police()
    {
        Console.WriteLine("경찰서에 신고하다");
    }
    public void Firestation()
    {
        Console.WriteLine("소방서에 신고하다");
    }
    public void HomeTax()
    {
        Console.WriteLine("국세청에 신고하다");
    }
}
internal class Program
{
    delegate void Call();

    static void Main(string[] args)
    {
        Emergency emg = new Emergency();
        Call call = emg.Police;
        call();
        Call call2 = emg.Firestation;
        Console.WriteLine(call2);
        Call call3 = emg.HomeTax;
        Console.WriteLine(call3);
    }
}
}
