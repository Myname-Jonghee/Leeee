namespace override_teran
{
    abstract class Teran
    {
        public virtual void Attack()
        {
            Console.WriteLine("테란 생성");
        }
    }
    class Marin : Teran
    {
        public override void Attack()
        {
            Console.WriteLine("Rock and roll");
        }
    }
    class Tank : Teran
    {
        public override void Attack()
        {
            Console.WriteLine("Brusie");
        }
    }
    class Firebat : Teran
    {
        public override void Attack()
        {
            Console.WriteLine("Lets burn");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
           
            Marin marin = new Marin();
            marin.Attack();
            Firebat firebat = new Firebat();
            firebat.Attack();
            Tank tank = new Tank();
            tank.Attack();
            //부모 클래스 활용 
            Teran unit1 = new Marin();
            Teran unit2 = new Firebat();
            Teran unit3 = new Tank();
            unit1.Attack();
            unit2.Attack();
            unit3.Attack();
        }
    }
}
