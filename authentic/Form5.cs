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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Users = new List<string>();
            buttonLogIn.Enabled = false;
        }
        public List<string> Users { get; set; }
        public string RemoteUser { get;set; }

        private void Form5_Load(object sender, EventArgs e)
        {
            listBoxUsers.Items.Clear();
            foreach (string item in Users)
            {
                listBoxUsers.Items.Add(item);
            }
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string a = listBoxUsers.Items[listBoxUsers.SelectedIndex].ToString();
            }
            catch (Exception) { }
            if (!(listBoxUsers.Items[listBoxUsers.SelectedIndex].ToString() == "Admin") && !(listBoxUsers.SelectedIndex == -1))
            {
                RemoteUser = listBoxUsers.SelectedItem.ToString();
                buttonLogIn.Enabled = true;
            }
            else
            {
                RemoteUser = null;
                buttonLogIn.Enabled = false;
            }
                
        }


    }
}
