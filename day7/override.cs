namespace ConsoleApp14

{
class Student

{
    public void EnrollCoures()

    {
        Console.WriteLine(" 수강신청");
    }

    public void DropCourse()

    {
        Console.WriteLine("과목 수강신청 취소");
    }

    public void ViewGreade()

    {
        Console.WriteLine("과목 성적 확인");
    }
}



class Instructor

{
    public void AssignGrade()

    {
        Console.Write("성적을 입력하세요 :");
        int score = int.Parse(Console.ReadLine());
        Console.WriteLine($"입력한 성적은 {score}점 입니다.");
    }


    public void CreatCourse()

    {
        Console.Write("등록 과정을 입력하세요 :");

        string obj = Console.ReadLine();

        Console.WriteLine($"등록된 과정은 {obj}");
    }

    public void UpdateCourse(string s)

    {
        Console.WriteLine($"{s} 수정 완료하였습니다.");
    }
}

internal class Program

{
    static void Main(string[] args)
    {
        Student stu = new Student();

        Instructor ins = new Instructor();

        stu.EnrollCoures();

        stu.DropCourse();

        stu.ViewGreade();

        ins.AssignGrade();

        ins.CreatCourse();

        ins.UpdateCourse("영어");

    }

}

}
