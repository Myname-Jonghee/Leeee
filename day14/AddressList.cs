using System.Data;
using System.Diagnostics;

namespace Listpractice
{

    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int Hp { get; set; }
        
        public Person(string name ,int id, int hp)
        {
            Name = name;
            Id = id;
            Hp = hp;
        }

    }

        internal class Program
        {
            static void Main(string[] args)
            {
                List<Person> addressbook = new List<Person>(); //리스트 만들기
               
                int respond;
                do
                {
                    Console.WriteLine("1. 데이터 삽입");
                    Console.WriteLine("2. 데이터 삭제");
                    Console.WriteLine("3. 데이터 조회");
                    Console.WriteLine("4. 데이터 수정"); //포기..
                    Console.WriteLine("--------------------");
                    respond = int.Parse(Console.ReadLine());
                    switch (respond)
                    {
                        case 1:
                        Console.WriteLine("데이터를 입력합니다");
                        Console.WriteLine();
                        AddPerson(addressbook);
                            break;
                        case 2:
                            Console.WriteLine("데이터를 삭제합니다");
                        RemovePerson(addressbook);
                            break;
                        case 3:
                        Console.WriteLine("데이터를 조회합니다");
                        ViewPerson(addressbook);

                            break;
                        case 4:
                            Console.WriteLine("4. 데이터 수정");
                            break;
                        default:
                            Console.WriteLine("종료");
                            break;
                    }
            } while(respond != 5);
            static void AddPerson(List<Person> addressbook)
            {
                Console.WriteLine("이름을 입력하세요");
                string name = Console.ReadLine();
                Console.WriteLine("아이디를 입력하세요");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("전화번호를 입력하세요");
                int hp = int.Parse(Console.ReadLine()); 
                Person newPerson = new Person(name, id, hp);    
                addressbook.Add(newPerson);
            }
           static void RemovePerson(List<Person> addressbook)
            {
                Console.WriteLine("삭제할 아이디를 입력하세요");
                int delete = int.Parse(Console.ReadLine());
                for(int i = 0; i < addressbook.Count; i++)
                {
                    if(addressbook[i].Id == delete)
                    {
                        addressbook.RemoveAt(i);
                        Console.WriteLine($"{delete}삭제완료하였습니다");
                    }
                }
                
            }
            static void ViewPerson(List<Person> addressbook)
            {
                Console.WriteLine("주소록:");

                if (addressbook.Count == 0)
                {
                    Console.WriteLine("저장된 연락처가 없습니다.");
                    return;
                }

                foreach (Person person in addressbook)
                {
                    Console.WriteLine($"이름: {person.Name}, 아이디: {person.Id}, 전화번호: {person.Hp}");
                }
            }
            static void EditPerson(List<Person> addressbook)
            {
               Console.Write("수정할 ID를 입력해주세요");
int update = int.Parse(Console.ReadLine());
for(int i = 0; i < addressbook.Count;i++)
{
    Console.WriteLine("수정 ID를 입력하세요 :");
    addressbook[i].Id = int.Parse(Console.ReadLine());
    Console.WriteLine("수정 이름을 입력하세요 :");
    addressbook[i].Name = Console.ReadLine();
    Console.WriteLine("수정 번호를 입력하세요 :");
    addressbook[i].Hp = int.Parse(Console.ReadLine());
}


            }
            }
        }
    }
