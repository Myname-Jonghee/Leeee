  using System;

namespace lotto
{
class Program
{
static void Main(string[] args)
{
int[] lotto = new int[6];
int i, cnt ,bonus= 0;
Random random = new Random();
     
     
        cnt = 0;
        while (cnt < 6)
        {
            int lottery = random.Next(1, 46);   
            for (i = 0; i < cnt; i++) 
                if (lotto[i] == lottery) break;
            if (cnt == i) lotto[cnt++] = lottery;
        }
        Array.Sort(lotto);
        for (i = 0; i < 6; i++)
            Console.WriteLine($"추첨 번호 : {lotto[i]}");
        Console.WriteLine();
        bonus = random.Next(1, 46);
        Console.WriteLine($"보너스 번호 : {bonus}");
    }
}
}
