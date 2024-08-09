using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
namespace MiniProjectBuycar
{
    public partial class OrderPage : Form
    {
        private int CustomerID;
        private string selectedModel;
        private string selectedEngine;
        private string selectedColor;
        public int NewCustomerID { get; private set; }
        public OrderPage()
        {
            InitializeComponent();
            comboBox1.Items.Add("K3");
            comboBox1.Items.Add("K5");
            comboBox1.Items.Add("K8");

            // comboBox1의 SelectedIndexChanged 이벤트 핸들러 추가
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
            comboBox3.SelectedIndexChanged += new EventHandler(comboBox3_SelectedIndexChanged);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // comboBox2의 항목을 초기화
            comboBox2.Items.Clear();

            // comboBox1에서 선택한 항목에 따라 comboBox2의 항목 추가
            if (comboBox1.SelectedItem.ToString() == "K3")
            {
                comboBox2.Items.Add("1.6 가솔린");
            }
            else if (comboBox1.SelectedItem.ToString() == "K5")
            {
                comboBox2.Items.Add("2.0 가솔린");
                comboBox2.Items.Add("2.0 LPi");
            }
            else if (comboBox1.SelectedItem.ToString() == "K8")
            {
                comboBox2.Items.Add("3.5 가솔린");
                comboBox2.Items.Add("3.5 LPi");
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combobox2의 항목에 따라 comboBox3의 항목 설정
            comboBox3.Items.Clear();
            comboBox3.Items.Add("검정");
            comboBox3.Items.Add("흰색");
            comboBox3.Items.Add("회색");
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // comboBox1과 comboBox3의 선택된 항목을 가져옴
            string selectedModel = comboBox1.SelectedItem?.ToString();
            string selectedColor = comboBox3.SelectedItem?.ToString();
            string imagePath = "";

            // 두 ComboBox의 선택된 항목에 따라 조건 검사
            if (selectedModel == "K3" && selectedColor == "회색")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K3\\K3_GRAY.png"; // K3 쥐색 이미지 파일 경로
            }
            else if (selectedModel == "K3" && selectedColor == "검정")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K3\\K3_BLACK.png"; // K3 검정색 이미지 파일 경로
            }
            else if (selectedModel == "K3" && selectedColor == "흰색")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K3\\K3_WHITE.png"; // K3 흰색 이미지 파일 경로
            }
            else if (selectedModel == "K5" && selectedColor == "검정")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K5\\K5_BLACK.png"; // K5 검정색 이미지 파일 경로
            }
            else if (selectedModel == "K5" && selectedColor == "회색")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K5\\K5_GRAY.png"; // K5 쥐색 이미지 파일 경로
            }
            else if (selectedModel == "K5" && selectedColor == "흰색")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K5\\K5_WHITE.png"; // K5 흰색 이미지 파일 경로
            }
            else if (selectedModel == "K8" && selectedColor == "검정")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K8\\K8_BLACK.png"; // K8 검정색 이미지 파일 경로
            }
            else if (selectedModel == "K8" && selectedColor == "회색")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K8\\K8_GRAY.png"; // K8 쥐색 이미지 파일 경로
            }
            else if (selectedModel == "K8" && selectedColor == "흰색")
            {
                imagePath = "C:\\Users\\Admin\\source\\repos\\MiniProjectBuycar\\K8\\K8_WHITE.png";// K8 흰색 이미지 파일 경로
            }
            else
            {
                pictureBox1.Image = null; // 선택된 항목이 없을 경우 이미지를 초기화
                return;
            }

            // pictureBox1에 이미지 로드
            if (!string.IsNullOrEmpty(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }
        private void Orderbutton_Click(object sender, EventArgs e)
        {
            // 선택된 모델, 엔진, 색상 가져오기
            selectedModel = comboBox1.SelectedItem?.ToString() ?? "모델 미선택";
            selectedEngine = comboBox2.SelectedItem?.ToString() ?? "엔진 미선택";
            selectedColor = comboBox3.SelectedItem?.ToString() ?? "색상 미선택";

            // PLSQL 데이터 저장 scott 계정 접속
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

                    // CustomerTemp 테이블 생성
                    string createTemp = "CREATE TABLE CustomerTemp(Model VARCHAR2(20), Engine VARCHAR2(20), Color VARCHAR2(20), Options VARCHAR2(20))";
                    using (OracleCommand createCmd = new OracleCommand(createTemp, conn))
                    {
                        try
                        {
                            createCmd.ExecuteNonQuery(); // 테이블 생성 명령 실행
                        }
                        catch (OracleException ex) when (ex.Number == 955)
                        {
                            // 테이블이 이미 존재하는 경우 발생할 수 있는 오류 955를 무시하고 진행
                        }
                    }

                    // 정보 저장
                    string insertQuery = "INSERT INTO CustomerTemp (Model, Engine, Color) VALUES (:model, :engine, :color)";
                    using (OracleCommand insertCmd = new OracleCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.Add(new OracleParameter("model", selectedModel));
                        insertCmd.Parameters.Add(new OracleParameter("engine", selectedEngine));
                        insertCmd.Parameters.Add(new OracleParameter("color", selectedColor));

                        insertCmd.ExecuteNonQuery(); // 데이터 삽입 명령 실행

                        MessageBox.Show($"차량 정보가 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // AddOption 폼을 열고 현재 저장된 정보를 전달
                    AddOption addOptionForm = new AddOption();
                    addOptionForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터를 저장하는 동안 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
    }//orderpage:form END
}
