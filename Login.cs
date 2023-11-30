using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace test
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string fixedUsername = "Admin";
            string fixedPassword = "Admin";

            // Get user input from TextBoxes
            string enteredUsername = tb_user.Text;
            string enteredPassword = tb_password.Text;

            // Check if the entered values match the hardcoded values
            if (enteredUsername == fixedUsername && enteredPassword == fixedPassword)
            {
                MessageBox.Show("Đăng nhập thành công!");


                FrMain frMain = new FrMain (fixedUsername);
                frMain.Show();  

                this.Hide();


            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng. Vui lòng thử lại.");
            }
        }
    }
}
