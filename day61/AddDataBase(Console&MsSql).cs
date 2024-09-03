using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF8_Exam1
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        // 기본 생성자
        public Person() { }

        public Person(string name, string phoneNumber)
        {

            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (local)\\SQLEXPRESS; " +
                        "Database = SmartFactoryDb; " +
                        "Trusted_Connection = True;" +
                        "Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Person>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(30);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            using (var context = new PersonDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            List<Person> people = new List<Person>();
            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. 데이터 삽입");
                Console.WriteLine("2. 데이터 삭제");
                Console.WriteLine("3. 데이터 조회");
                Console.WriteLine("4. 데이터 수정");
                Console.WriteLine("5. 종료");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("--------------------");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("데이터 삽입");
                        InsertPersonData(people);
                        break;
                    case 2:
                        Console.WriteLine("데이터 삭제");
                        DeletePersonData(people);
                        break;
                    case 3:
                        Console.WriteLine("데이터 조회");
                         SearchPerson(people);
                        break;
                    case 4:
                        Console.WriteLine("데이터 수정");
                        UpdatePerson(people); // 구현 필요
                        break;
                }
            } while (choice != 5);
        }

        public static void InsertPersonData(List<Person> people)
        {
            using (var context = new PersonDbContext())
            {
                context.Database.EnsureCreated();



                Console.WriteLine("이름을 입력하세요:");
                string name = Console.ReadLine();

                Console.WriteLine("전화번호를 입력하세요 :");
                string phoneNumber = Console.ReadLine();

                var newPerson = new Person(name, phoneNumber);
                people.Add(newPerson);

                context.Person.Add(newPerson);
                context.SaveChanges();

                Console.WriteLine("데이터 저장 완료!");
            }
        }//데이터삽입
        public static void DeletePersonData(List<Person> people)
        {
            using (var context = new PersonDbContext())
            {
                Console.WriteLine("삭제 할 이름을 입력하세요:");
                string name = Console.ReadLine();

                Console.WriteLine("삭제 할 휴대폰 번호를 입력하세요 (- 필수)  :");
                string phoneNumber = Console.ReadLine();
                // 해당 이름을 가진 Person 찾기
                var personToDelete = context.Person.SingleOrDefault(p => p.Name == name && p.PhoneNumber == phoneNumber);

                if (personToDelete != null)
                {
                    context.Person.Remove(personToDelete);
                    context.SaveChanges();
                    Console.WriteLine("정보가 삭제 되었습니다.");
                }
                else
                {
                    Console.WriteLine("해당 이름의 데이터를 찾을 수 없습니다.");
                }
            }
        }//데이터 삭제 
        public static void SearchPerson(List<Person> people)
        {
            Console.WriteLine("이름을 입력하세요:");
            string name = Console.ReadLine();
            using (var context = new PersonDbContext())
            {
                // 이름으로 조회
                var persons = context.Person.Where(p => p.Name == name).ToList();

                if (persons.Any())
                {
                    foreach (var person in persons)
                    {
                        Console.WriteLine($"ID: |{person.ID}|, 이름: |{person.Name}|, 전화번호: |{person.PhoneNumber}|");
                    }
                }
                else
                {
                    Console.WriteLine("해당 이름을 가진 사람을 찾을 수 없습니다.");
                }
            }
        }//조회 
        public static void UpdatePerson(List<Person> people)
        {
            using (var context = new PersonDbContext())
            {
                Console.WriteLine("수정 할 이름을 입력하세요 :");
                string name = Console.ReadLine();

                var personToUpdate = context.Person.SingleOrDefault(p => p.Name == name);
                if (personToUpdate != null)
                {
                    Console.WriteLine("변경 할 이름을 입력하세요 (현재 데이터: " + personToUpdate.Name + "):");
                    string NewName  = Console.ReadLine();
                    Console.WriteLine("새로운 휴대폰 번호를 입력하세요 (현재 데이터: " + personToUpdate.PhoneNumber + "):");
                    string NewPhoneNumber = Console.ReadLine();
                    // 수정한 정보 변경
                    personToUpdate.Name = NewName;
                    personToUpdate.PhoneNumber = NewPhoneNumber;
                    //저장내용 저장
                    context.SaveChanges();
                    Console.WriteLine(" 정보가 수정되었습니다.");
                }
            }
        }
}
}

