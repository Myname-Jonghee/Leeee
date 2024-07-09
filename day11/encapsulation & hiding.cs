
namespace code68
{
    class BankAccount
    {
        private double balance = 0;//지역변수

        public void Deposit(int money)
        {
            Console.WriteLine($"예금 금액 :{money}");
            balance += money;
        }

        public void Withdraw(int money)
        {
            Console.WriteLine($"인출 금액:{money}");
            balance -= money;
        }

        public double GetBalance()
        {
            Console.WriteLine($"잔고 : {balance}");
            return balance;
        }

        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.Deposit(50000);
            account.Withdraw(20000);
            account.GetBalance();
        }
    }
}
