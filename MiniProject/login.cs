using Microsoft.VisualBasic.ApplicationServices;
using MiniProjectBuycar;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace Miniproject1
{
    public partial class login : Form
    {
        private DatabaseUtil Util = new DatabaseUtil();
        private int imageIndex = 0;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int slideSpeed = 3;
        private int totalImages = 6;
        private string[] imageFiles;

        public login()
        {
            InitializeComponent();
            Display_setting();
        }
        private void login_Load(object sender, EventArgs e)
        {
            Util.SetTableData(dataGridView5, "LoginTable");
            Display_load();
        }
        private void Sign_up_Click(object sender, EventArgs e)
        {
            Sign_Up signUpForm = new Sign_Up();
            signUpForm.Show();
        }
        private void Sign_in_Click(object sender, EventArgs e)
        {
            bool loginSuccess = false;
            bool isAdmin = false;
            int userId = -1;

            string resetLogin = "UPDATE LoginTable SET NOW_LOGIN = 0";
            Util.ExecuteNonQuery(resetLogin);
            Util.SetTableData(dataGridView5, "LoginTable");

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
                {
                    string id = row.Cells[2].Value.ToString();
                    string password = row.Cells[3].Value.ToString();
                    string admin = row.Cells[4].Value.ToString();
                    string currentId = row.Cells[0].Value.ToString();

                    if (textBox_id.Text == id && textBox_pwd.Text == password)
                    {
                        loginSuccess = true;
                        isAdmin = admin == "1";
                        userId = int.Parse(currentId);
                        break;
                    }
                }
            }

            if (loginSuccess)
            {
                if (isAdmin && checkBox1.Checked)
                {
                    // 관리자 페이지 접속
                    //MessageBox.Show("관리자 로그인");
                    Admin admin = new Admin();
                    admin.Show();
                    loginCheck(userId.ToString());
                }
                else
                {
                    // 사용자 페이지 접속
                    //MessageBox.Show("사용자 로그인 성공");
                    OrderPage orderPage = new OrderPage();
                    orderPage.Show();
                    loginCheck(userId.ToString());
                }
            }
            else
            {
                // 로그인 실패
                MessageBox.Show("로그인 실패");
            }
        }
        private void FindID_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_Up_FIndID FIndIDForm = new Sign_Up_FIndID();
            FIndIDForm.Show();
        }
        private void FindPWD_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_Up_FIndPWD FIndPWDForm = new Sign_Up_FIndPWD();
            FIndPWDForm.Show();
        }
        public void loginCheck(string str)
        {
            string adminLogin = $"UPDATE LoginTable " +
                                $"SET NOW_LOGIN = 1 " +
                                $"WHERE id = :{str}";
            Util.declare_Parameter(str, adminLogin);
        }

        //////여기부터 디스플레이 관련
        private void Display_setting()
        {
            imageFiles = new string[]
            {
                System.Environment.CurrentDirectory + "/The2024K9.png",
                System.Environment.CurrentDirectory + "/ThenewK5.png",
                System.Environment.CurrentDirectory + "/ThenewK8.png",
                System.Environment.CurrentDirectory + "/Carnival.png",
                System.Environment.CurrentDirectory + "/TheKiaEV3.png",
                System.Environment.CurrentDirectory + "/ThenewEV6.png"
            };
            timer.Interval = 50; // 타이머 간격 (ms)
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Display_load()
        {
            CarPB1.Image = Image.FromFile(imageFiles[0]);
            CarPB2.Image = Image.FromFile(imageFiles[1]);
            CarPB3.Image = Image.FromFile(imageFiles[2]);

            // 초기 위치 설정
            CarPB1.Left = 0;
            CarPB2.Left = CarPB1.Width;
            CarPB3.Left = CarPB2.Left + CarPB2.Width;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 세 PictureBox를 왼쪽으로 이동
            CarPB1.Left -= slideSpeed;
            CarPB2.Left -= slideSpeed;
            CarPB3.Left -= slideSpeed;

            // 첫 번째 PictureBox가 화면 밖으로 나갔을 때
            if (CarPB1.Left <= -CarPB1.Width)
            {
                CarPB1.Left = CarPB3.Left + CarPB3.Width; // 첫 번째 PictureBox를 세 번째 뒤로 이동
                imageIndex = (imageIndex + 1) % totalImages;
                CarPB1.Image = Image.FromFile(imageFiles[imageIndex]); // 다음 이미지로 교체
            }

            // 두 번째 PictureBox가 화면 밖으로 나갔을 때
            if (CarPB2.Left <= -CarPB2.Width)
            {
                CarPB2.Left = CarPB1.Left + CarPB1.Width; // 두 번째 PictureBox를 첫 번째 뒤로 이동
                imageIndex = (imageIndex + 1) % totalImages;
                CarPB2.Image = Image.FromFile(imageFiles[imageIndex]); // 다음 이미지로 교체
            }

            // 세 번째 PictureBox가 화면 밖으로 나갔을 때
            if (CarPB3.Left <= -CarPB3.Width)
            {
                CarPB3.Left = CarPB2.Left + CarPB2.Width; // 세 번째 PictureBox를 두 번째 뒤로 이동
                imageIndex = (imageIndex + 1) % totalImages;
                CarPB3.Image = Image.FromFile(imageFiles[imageIndex]); // 다음 이미지로 교체
            }
        }
    }
}
