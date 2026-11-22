using System;
using System.Windows.Forms;
using BLL;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        private readonly UserService userService;

        public Form1()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool result = userService.Login(
                txtUsername.Text,
                txtPassword.Text
            );

            if (result)
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}