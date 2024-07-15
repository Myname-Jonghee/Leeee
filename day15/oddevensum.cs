namespace winformoddeven
{
public partial class Form1 : Form
{
public Form1()
{
InitializeComponent();
}
    private void button1_Click(object sender, EventArgs e)
    {
        int insert = int.Parse(InsertBox.Text);
        double oddsum =0, evensum = 0;

        for (int i = 1; i<=insert; i++)
        {
            if (i % 2 == 0)
            {
                evensum = evensum + i;
                EvenBox.Text = EvenBox.Text + i + "+";
            }
            else
            {
                oddsum = oddsum + i;
                OddBox.Text = OddBox.Text + i + "+";
                evensum = evensum + i;
                EvenBox.Text = EvenBox.Text + i + "+";
            }
        }
        OddBox.Text = OddBox.Text +"=" + oddsum;
        EvenBox.Text = EvenBox.Text + "=" + evensum;
    }
}
}
