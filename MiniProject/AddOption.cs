using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MiniProjectBuycar
{
    public partial class AddOption : Form
    {
        private int customerID;
        private string selectedModel;
        private string selectedEngine;
        private string selectedColor;

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

                    string updateQuery = "UPDATE CustomerTemp SET Options = :options "; //temp 테이블에 옵션 넣기
                    using (OracleCommand updateCmd = new OracleCommand(updateQuery, conn))
                    {

                        updateCmd.Parameters.Add(new OracleParameter("options", selectOption));
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("옵션 선택이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FetchPrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("선택된 주문 정보 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchPrice()//Pricetextbox에 가격 알려주는 코드
        {
            string selectedOption = comboBox1.SelectedItem?.ToString() ?? "";

            string connectionString = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=SCOTT;Password=TIGER;";

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Price FROM CARPRICE WHERE CARMODEL = (SELECT model FROM CUSTOMERTEMP) AND CARENGINE = (SELECT engine FROM CUSTOMERTEMP) AND CAROPTIONS = (SELECT Options FROM CUSTOMERTEMP)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {


                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string price = reader["price"].ToString();
                                PriceTextBox.Text = ($"{price}원");
                            }
                            else
                            {
                                MessageBox.Show("해당 차량 조합에 대한 가격을 찾을 수 없습니다.", "가격 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("가격 정보를 가져오는 동안 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Optionbutton_Click_1(object sender, EventArgs e)//잘못클릭
        {

        }

         private void LastConfirmbutton_Click(object sender, EventArgs e)
 {
     string connectString =  "Data Source=(DESCRIPTION=" +
                             "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                             "(HOST=localhost)(PORT=1521)))" +
                             "(CONNECT_DATA=(SERVER=DEDICATED)" +
                             "(SERVICE_NAME=xe)));" +
                             "User Id=SCOTT;Password=TIGER;";

     using (OracleConnection conn = new OracleConnection(connectString))
     {
         conn.Open();

         using (OracleTransaction transaction = conn.BeginTransaction()) // 트랜잭션 시작
         {
             try
             {
                 string orderQuery = "INSERT INTO CUSTOMER (CustomerID, Model, Engine, Color, Options) " +
                                     "SELECT SEQ_CUSTOMERID.NEXTVAL, Model, Engine, Color, Options FROM CUSTOMERTEMP";

                 using (OracleCommand cmd = new OracleCommand(orderQuery, conn))
                 {
                     cmd.Transaction = transaction; // 트랜잭션을 명령에 할당
                     int rowsAffected = cmd.ExecuteNonQuery();

                     if (rowsAffected > 0)
                     {
                         transaction.Commit(); // 트랜잭션 커밋
                         MessageBox.Show("주문이 완료되어 출고처리 됩니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                         transaction.Rollback(); // 트랜잭션 롤백
                         MessageBox.Show("CUSTOMERTEMP 테이블에 데이터가 없습니다.", "정보 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"주문 처리 중 에러가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }
     }
 }

         private void Cancelbutton_Click(object sender, EventArgs e)
            {

                string connectionString = "Data Source=(DESCRIPTION=" +
                   "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                   "(HOST=localhost)(PORT=1521)))" +
                   "(CONNECT_DATA=(SERVER=DEDICATED)" +
                   "(SERVICE_NAME=xe)));" +
                   "User Id=SCOTT;Password=TIGER;";

                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string cancelQuery = "DROP TABLE CUSTOMERTEMP";
                    using (OracleCommand cmd = new OracleCommand(cancelQuery, conn))
                    {

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("주문정보가 취소되었습니다");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("주문 정보 취소 처리 중 에러가 발생했습니다!");
                        }
                    }
                }
            }

        
    }
}//form END
    

