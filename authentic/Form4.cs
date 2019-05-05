using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace authentic
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string Login { get; set; }
        public string Password { get; set; }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            Login = textBoxLogin.Text;
            Password = textBoxPassword.Text;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
