using System.Net.Cache;

namespace ListPractice2
{
    class Team
    {
        public string Name { get; set; }
        public int Age {  get; set; }
        public string Position { get; set; }
        public string BeforeClub { get; set; }
        public string ContactFee { get; set; }
        
        public Team(string name,int age,string position,string beforeClub,string contactfee)
        {
            Name = name;
            Age = age;
            Position = position;
            BeforeClub = beforeClub;
            ContactFee = contactfee;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> team = new List<Team>();

            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. 선수 삽입");
                Console.WriteLine("2. 선수 방출");
                Console.WriteLine("3. 선수 조회");
                Console.WriteLine("4. 선수 수정");
                Console.WriteLine("5. 종료");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("--------------------");

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("선수 영입");
                        AddPlayer(team);
                        break;
                    case 2:
                        Console.WriteLine("선수 방출");
                        RemovePlayer(team);
                        break;
                    case 3:
                        Console.WriteLine("선수 조회");
                        SearchPlayer(team);
                        break;
                    case 4:
                        Console.WriteLine("선수 정보 변경");
                        RewritePlayer(team);
                        break;
                }

            } while (choice != 5);
        }
        public static void AddPlayer(List<Team> team)
        {
            Console.Write("선수의 이름을 입력하세요:");
            string name = Console.ReadLine();
            Console.Write("선수의 나이를 입력하세요:");
            int age = int.Parse(Console.ReadLine());
            Console.Write("선수의 포지션을 입력하세요:");
            string position = Console.ReadLine();
            Console.Write("선수의 전 클럽을 입력하세요 :");
            string beforeClub = Console.ReadLine();
            Console.Write("선수의 이적료를 입력하세요:");
            string contactfee = Console.ReadLine();
            Team Makingteam = new Team(name, age, position, beforeClub, contactfee);  
            team.Add(Makingteam);
        }
        static void RemovePlayer(List<Team> team)
        {
            Console.Write("방출할 선수 이름을 입력하세요 :");
            string OutPlayer = Console.ReadLine();
            for (int i = 0; i < team.Count; i++)
            {
                if (team.Count == 0)
                {
                    Console.WriteLine("방출 할 선수가 없습니다.");
                    return;
                }
                if (team[i].Name == OutPlayer)
                {
                    team.RemoveAt(i);
                    Console.Write($"{OutPlayer}를 방출하였습니다.");
                }
            }
        }
        static void SearchPlayer(List<Team> team)
        {
            Console.WriteLine();

            if (team.Count == 0)
            {
                Console.WriteLine("이런.. 선수가 없네요");
            }
            else
            {
                Console.Write("조회 할 선수 이름을 입력하세요");
                string ViewPlayer = Console.ReadLine();

                foreach (Team ViePwlayer in team)
                {
                    Console.WriteLine($"선수의이름 :{ViePwlayer.Name}, 선수의 나이 :{ViePwlayer.Age}, 선수의 포지션 {ViePwlayer.Position},선수의 전 클럽 :{ViePwlayer.BeforeClub},선수의 이적료 :{ViePwlayer.ContactFee}");
                }
            }
        }
        static void RewritePlayer(List<Team> team)
        {
            
            if (team.Count == 0)
            {
                Console.Write("변경할 수 있는 선수가 없습니다");
            }
            else
            {
                Console.Write("정보를 변경할 선수 이름을 입력하세요");
                string playername = Console.ReadLine();
                Console.Write($"{playername}선수를 수정합니다");

                for (int i = 0; i < team.Count; i++)
                {
                    if (team[i].Name == playername)
                    {
                        Console.Write("수정 할 이름을 입력하세요:");
                        string name = Console.ReadLine();
                        Console.Write("수정 할 나이를 입력하세요:");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("수정 할  포지션을 입력하세요:");
                        string position = Console.ReadLine();
                        Console.Write("수정 할  클럽을 입력하세요 :");
                        string beforeClub = Console.ReadLine();
                        Console.Write("수정 할 이적료를 입력하세요:");
                        int contactfee = int.Parse(Console.ReadLine());
                    }
                }
            }
        }
    }
}
