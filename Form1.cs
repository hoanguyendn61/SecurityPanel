using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT01_102190014_NguyenHuyHoa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string line;
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
            if(txtCode.Text.Length < txtCode.MaxLength)
            {
                txtCode.Text += ((Button)sender).Text;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if(txtCode.Text.Length > 0)
            {
                txtCode.Text = txtCode.Text.Remove(txtCode.Text.Length - 1);
            }
        }
        private void key_Press(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar));
            if (e.Handled == true)
            {
                if(txtCode.Text.Length < txtCode.MaxLength)
                {
                    txtCode.Text += e.KeyChar.ToString();
                }
            }
            if (e.KeyChar == (char)13)
            {
                btnEnter_Click(sender, e);
            }
            if (e.KeyChar == (char)8)
            {
                btnClear_Click(sender, e); 
            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string accesslog;
            if (txtCode.Text.Length == 1)
            {
                accesslog = DateTime.Now.ToString() + "     Restricted Access";
                lbAccessLog.Items.Add(accesslog);
            } else
            {
                switch (txtCode.Text)
                {
                    case "2001":
                        accesslog = DateTime.Now.ToString() + "     Access Granted!";
                        lbAccessLog.Items.Add(accesslog);
                        break;
                    case "3005":
                        accesslog = DateTime.Now.ToString() + "     Access Granted!";
                        lbAccessLog.Items.Add(accesslog);
                        break;
                    case "2077":
                        accesslog = DateTime.Now.ToString() + "     Access Granted!";
                        lbAccessLog.Items.Add(accesslog);
                        break;
                    case "3000":
                        accesslog = DateTime.Now.ToString() + "     Access Granted!";
                        lbAccessLog.Items.Add(accesslog);
                        break;
                    default:
                        accesslog = DateTime.Now.ToString() + "     Access Denied!";
                        lbAccessLog.Items.Add(accesslog);
                        break;
                }
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
