namespace Quiz1
{

abstract class Mammal

{

    public abstract void Eat();

}



class Lion : Mammal

{

    public override void Eat()

    {

        Console.WriteLine("사자가 먹습니다");

    }

}



class Tiger : Mammal

{

    public override void Eat()

    {

        Console.WriteLine("호랑이가 먹습니다");

    }

}



class Dog : Mammal

{

    public override void Eat()

    {

        Console.WriteLine("개가 먹습니다");

    }

}





internal class Program

{

    static void Main(string[] args)

    {

        Mammal[] mammals = { new Lion(), new Tiger(), new Dog() };



        for (int i = 0; i < mammals.Length; i++)

        {

            mammals[i].Eat();

        }

    }

}

}
