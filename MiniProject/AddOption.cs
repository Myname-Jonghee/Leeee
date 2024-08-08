using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace MiniProjectBuycar
{
    public partial class AddOption : Form
    {
        public AddOption()
        {
            InitializeComponent();
            comboBox1.Items.Add("스탠다드");
            comboBox1.Items.Add("노블레스");
            comboBox1.Items.Add("시그니처");

            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            Optionbutton.Click += new EventHandler(Optionbutton_Click);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "스탠다드")
            {
                textBox1.Text = "스탠다드옵션 -> 버튼시동, 크루즈컨트롤, 17인치 휠 타이어, 전자식 파킹브레이크를 제공합니다.";
            }
            else if (comboBox1.SelectedItem.ToString() == "노블레스")
            {
                textBox1.Text = "노블레스옵션 -> 스탠다드 + 가죽시트 + 서라운드 뷰를 제공합니다.";
            }
            else if (comboBox1.SelectedItem.ToString() == "시그니처")
            {
                textBox1.Text = "시그니처옵션 -> 노블레스 + HUD + 파노라마 썬루프를 제공합니다.";
            }
        }

        private void Optionbutton_Click(object sender, EventArgs e)
        {
            // AddOption의 데이터 값 가져오기
            string selectOption = comboBox1.SelectedItem?.ToString() ?? "옵션 미선택";
            string optionDetail = textBox1.Text;

            // 데이터베이스 연결 문자열
            string connectionString = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=SCOTT;Password=TIGER;";

            // 데이터 저장 코드
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Customer (Options) VALUES (:options)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("options", selectOption));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("옵션 선택이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("선택된 주문 정보 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
