using System.Globalization;

namespace Game1
{
    internal class Program
    {



        static void Main(string[] args)
        {
            
            Console.WriteLine("용사의 서막에 오신 것을 환영합니다");
            Thread.Sleep(1000);
            Console.Write("사용자의 이름을 정해주세요 :");
            string name = Console.ReadLine();

            Console.WriteLine($"축하합니다! 용감한 탐험가 {name} 님");
            Console.WriteLine("앞으로의 여정을 응원합니다");

            Console.WriteLine();
            int choice;
            do
            {
                Console.WriteLine("1 낡은 마을 탐험");
                Console.WriteLine("2.숲 속 오두막 방문");
                Console.WriteLine("3.돌아가기");
                Console.WriteLine("선택 :");
                
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("낡은 마을 탐험");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{name}이 마을에 도착합니다. 마을 주민과의 대화를 하고 마을의 숨겨진 비밀을 파헤치세요!");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("숲 속 오두막");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{name}이 오두막에 도착합니다 은둔하는 마법사에게 기술을 배우고 아이템을 구매하세요!.");
                        Console.WriteLine();
                        
                        break;
                    case 3:
                        Console.WriteLine("게임을 종료합니다");
                        Console.WriteLine();
                        break;

                } 

            } while (choice != 3);
        }
        }
}
