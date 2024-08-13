namespace Miniproject1
{
    public partial class Sign_Up_FIndID : System.Windows.Forms.Form
    {
        private DatabaseUtil Util = new DatabaseUtil();

        public Sign_Up_FIndID()
        {
            InitializeComponent();
        }

        private void Sign_Up_FIndID_Load(object sender, EventArgs e)
        {

        }

        //////
        //실수
        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox_birth_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void FindIdBtn_Click(object sender, EventArgs e)
        {
            bool findSuccess = false;
            string foundUserId = "";

            Util.SetTableData(dataGridView5, "LoginTable");

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[5].Value != null)
                {
                    string name = row.Cells[1].Value.ToString();
                    string birth = row.Cells[5].Value.ToString();

                    if (textBox_name.Text == name && textBox_birth.Text == birth)
                    {
                        findSuccess = true;
                        foundUserId = row.Cells[2].Value.ToString();
                        break;
                    }
                }
            }

            if (findSuccess)
            {
                MessageBox.Show($"당신의 아이디는 {foundUserId}입니다.");
            }
            else
            {
                MessageBox.Show("잘못된 정보를 입력하였습니다.");
            }
        }
    }
}
