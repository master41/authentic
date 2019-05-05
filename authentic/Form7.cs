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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public string NewPassword { get; set; }
        public string OldPassword { get; set; }

        private void Form7_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                ActiveControl = textBoxNewPassword;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            OldPassword = textBoxOldPassword.Text;
            NewPassword = textBoxNewPassword.Text;
        }
    }
}
