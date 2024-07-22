using Oracle.ManagedDataAccess.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;
using System.Numerics;

namespace addresswithOracle
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //SELECT 데이터 조회
            string strConn = "Data Source=(DESCRIPTION=" +

                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +

                "(HOST=localhost)(PORT=1521)))" +

                "(CONNECT_DATA=(SERVER=DEDICATED)" +

                "(SERVICE_NAME=xe)));" +

                "User Id=scott;Password=TIGER;";
       


            string name;
            string hp;
            string email;
            string company;
            string address;
            

            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);
            //2.데이터베이스 접속을 위한 연결
            conn.Open();
            //명령객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
           
            int chocie; 

            do
            {
                Console.WriteLine();
                Console.WriteLine("0. 테이블 생성");
                Console.WriteLine("1. 명함 추가");
                Console.WriteLine("2. 명함 검색");
                Console.WriteLine("3. 명함 수정");
                Console.WriteLine("4. 명함 삭제");
                Console.WriteLine("5. 명함 조회");
                Console.WriteLine("6. 프로그램 종료");
                Console.WriteLine("--------------------");
                chocie = int.Parse(Console.ReadLine());
                switch (chocie)
                {
                    case 0:
                        //테이블
                        cmd.CommandText = "CREATE TABLE namecard (" +
                         "CardID NUMBER PRIMARY KEY," +
                        "Name VARCHAR2(50) NOT NULL, " +
                        "HP VARCHAR2(20) NOT NULL, " +
                        "Email VARCHAR2(50), " +
                        "Company VARCHAR2(100), " +
                        "Address VARCHAR2(200))";
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("테이블이 생성되었습니다.");
                        break;

                    case 1:
                        Console.WriteLine("이름을 입력하세요");
                        name = Console.ReadLine();
                        Console.WriteLine("전화번호를 입력하세요");
                        hp = Console.ReadLine();
                        Console.WriteLine("이메일을 입력하세요");
                        email = Console.ReadLine();
                        Console.WriteLine("회사를 입력하세요");
                        company = Console.ReadLine();
                        Console.WriteLine("주소를 입력하세요");
                        address = Console.ReadLine();
                        cmd.CommandText = $"INSERT INTO namecard(CardId,name,hp,email,company,address) VALUES ( SEQ_BUSINESSCARDS.NEXTVAL,'{name}','{hp}','{email}','{company}','{address}')";
                        cmd.ExecuteNonQuery();
                        break;

                    case 2:
                        Console.WriteLine("데이터를 확인 할 ID를 입력하세요");
                        int id = int.Parse(Console.ReadLine());
                        cmd.CommandText = "SELECT * FROM NameCard WHERE CardId = " + id;
                        OracleDataReader odr = cmd.ExecuteReader();

                        while (odr.Read())
                        {
                            id = odr.GetInt32(0);
                            name = odr["NAME"] as string;
                            hp = odr["HP"] as string;
                            email = odr["Email"] as string;
                            company = odr["COMPANY"] as string;
                            address = odr["ADDRESS"] as string;

                            Console.Write($"아이디: {id},이름: {name},전화번호: {hp} 이메일: {email},회사: {company},주소: {address}");
                        }
                        cmd.ExecuteNonQuery();
                        break;

                    case 3:
                        Console.WriteLine("수정할 ID를 입력하세요");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("수정 할 이름을 입력하세요 :");
                        name = Console.ReadLine();
                        Console.WriteLine("수정 할 전화번호를 입력하세요 :");
                        hp = Console.ReadLine();
                        Console.WriteLine("수정 할 이메일을 입력하세요 :");
                        email = Console.ReadLine();
                        Console.WriteLine("수정 할 회사를 입력하세요 :");
                        company = Console.ReadLine();
                        Console.WriteLine("수정 할 주소를 입력하세요 :");
                        address = Console.ReadLine();
                        cmd.CommandText = "UPDATE adressbook SET " + "id = @id, " + "name = @name, " + "hp = @hp, " + "email = @Email, " + "company = @company, " + "address = @address " +
                        "WHERE id = @id"; // 적절한 WHERE 조건 추가
                        break;
                    case 4:
                        Console.WriteLine("삭제할 ID를 입력하세요.");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("정말 삭제 하시겠습니까? Y/N ");
                        string sure = Console.ReadLine();
                        switch (sure) //삭제 다시 물어보기
                        {
                            case "y":
                            cmd.CommandText = "Delete from namecard where Id = " + id;
                             cmd.ExecuteNonQuery();
                            Console.WriteLine($"{id}삭제완료");
                             break;
                          }
                            break;//case 4 break
                    case 5:
                        cmd.CommandText = "select*from namecard";
                        OracleDataReader rdr = cmd.ExecuteReader();



                        while (rdr.Read())

                        {

                             id = int.Parse(rdr["ID"].ToString());
                             name = rdr["NAME"] as string;
                             hp = rdr["HP"] as string;
                             email = rdr["EMAIL"] as string;
                             company = rdr["COMPANY"] as string;
                             address = rdr["ADDRESS"] as string;
                            Console.WriteLine($"{id} | {name} | {hp} | {email} | {company} | {address} ");
                        }
                        break;
                    case 6:
                        Console.WriteLine("종료합니다");
                        break;
                        
                }//switch end
            } while (chocie != 6);
           
            }
        }
    }
