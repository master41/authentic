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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public string CurrentUserInfo{ get; set; }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBoxCurrentUserInfo.Clear();
            textBoxCurrentUserInfo.Text = CurrentUserInfo;
        }
    }
}
