namespace page52
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            str = $"당신의 연령은 : \n";
            if (radioButton1.Checked == true) str = str + radioButton1.Text;
            if (radioButton2.Checked == true) str = str + radioButton2.Text;
            if (radioButton3.Checked == true) str = str + radioButton3.Text;
            if (radioButton4.Checked == true) str = str + radioButton4.Text;
            if (radioButton5.Checked == true) str = str + radioButton5.Text;
            if (radioButton6.Checked == true) str = str + radioButton6.Text;
            str = $"{str} \n \n 좋아하는색은 : \n";

            if (checkBox1.Checked == true) str = str + checkBox1.Text;
            if (checkBox2.Checked == true) str = str + checkBox2.Text;
            if (checkBox3.Checked == true) str = str + checkBox3.Text;
            if (checkBox4.Checked == true) str = str + checkBox4.Text;
            if (checkBox5.Checked == true) str = str + checkBox5.Text;
            if (checkBox6.Checked == true) str = str + checkBox6.Text;
            str = $" {str} 입니다";
            label1.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
