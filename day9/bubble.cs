namespace bubble
{
internal class Program
{
static void Main(string[] args)
{
int[] list = { 4, 5, 7, 3, 2, 1, 9, 8 };
int tmp;  for(int i = 8-1; i >0; i--)
        {
            for(int k = 0; k < i; k++)
            {
                if (list[k] > list[k + 1])
                {
                    tmp = list[k];
                    list[k] = list[k + 1];
                    list[k + 1] = tmp;

                }
            }
        }
        foreach(int i in list)
        {
            Console.WriteLine(i);
        }
    }
}
}
