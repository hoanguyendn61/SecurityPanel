using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string line;
            // System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Download\Study\hoc\YEAR 2\HOCKY II\dotNet\WinForm\SecurityPanel\bin\Debug\accesslog.txt");
            string filePath = System.IO.Path.GetFullPath("accesslog.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                lbAccessLog.Items.Add(line);
            }
            file.Close();
        }
       
        private void button_Click(object sender, MouseEventArgs e)
        {
            txtCode.Text += ((Button)sender).Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
        }

        private void key_Press(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar));
            if (e.Handled == true)
            {
                txtCode.Text += e.KeyChar.ToString();
            }
            if (e.KeyChar == (char)13)
            {
                btnEnter_Click(sender, e);
            }

        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string accesslog;
            switch (txtCode.Text)
            {
                case "1645":
                    accesslog = DateTime.Now.ToString() + "     Technicians";
                    lbAccessLog.Items.Add(accesslog);
                    break;
                case "1689":
                    accesslog = DateTime.Now.ToString() + "     Technicians";
                    lbAccessLog.Items.Add(accesslog);
                    break;
                case "8345":
                    accesslog = DateTime.Now.ToString() + "     Custodians";
                    lbAccessLog.Items.Add(accesslog);
                    break;
                case "9998":
                    accesslog = DateTime.Now.ToString() + "     Scientists";
                    lbAccessLog.Items.Add(accesslog);
                    break;
                case "1006":
                    accesslog = DateTime.Now.ToString() + "     Scientists";
                    lbAccessLog.Items.Add(accesslog);
                    break;
                case "1008":
                    accesslog = DateTime.Now.ToString() + "     Scientists";
                    lbAccessLog.Items.Add(accesslog);
                    break;
                default:
                    accesslog = DateTime.Now.ToString() + "     Restricted Access!";
                    lbAccessLog.Items.Add(accesslog);
                    break;
            }
            txtCode.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("accesslog.txt");
            foreach (var item in lbAccessLog.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.Close();
        }
    }
}
