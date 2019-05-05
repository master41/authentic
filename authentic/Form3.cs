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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string EnteredLogin { get; set; }
        public string EnteredPassword { get; set; }
        public string SelectedUser
        {
            get { return textBoxLogin.Text; }
            set { textBoxLogin.Text = value; }
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            textBoxLogin.Text = SelectedUser;
        }

        internal void buttonLogIn_Click(object sender, EventArgs e)
        {
            EnteredLogin = textBoxLogin.Text;
            EnteredPassword = textBoxPassword.Text;
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                ActiveControl = textBoxPassword;
        }

    }
}
