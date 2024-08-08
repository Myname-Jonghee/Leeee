using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
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
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "스탠다드")
            {
                textBox1.Text = "스탠다드옵션 ->버튼시동,크루즈컨트롤,17인치 휠 타이어,전자식 파킹브레이크를 제공합니다.";
            }
            else if (comboBox1.SelectedItem.ToString() == "노블레스")
            {
                textBox1.Text = "노블레스옵션 -> 스탠다드 + 가죽시트 + 서라운드 뷰을 제공합니다.";
            }
            else if (comboBox1.SelectedItem.ToString() == "시그니처")
            {
                textBox1.Text = "시그니처옵션 -> 노블레스 + HUD + 파노라마 썬루프를 제공합니다.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AddOption의 데이터 값 가져오기
            string selectOption = comboBox1.SelectedItem?.ToString() ?? "옵신 미선택";
            string optionDetail = textBox1.Text;
            //파일 경로
            string filePath = @"C:\Temp\OrderPageData.txt";
            //데이터 저장 코드
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("선택된 옵션 " + selectOption);
                    writer.WriteLine("선택된 옵션의 사양 " + optionDetail);
                       
                }
                MessageBox.Show("주문 정보가 저장 되었습니다.","저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("선택된 주문 정보 저장 중 오류가 발생했습니다" + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }
}
