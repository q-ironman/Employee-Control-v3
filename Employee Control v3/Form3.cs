using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Control_v3
{
    public partial class Form3 : Form
    {
        Door myDor = new Door();
        Door mydor2 = new Door();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            myDor.Opened += MyDor_Opened;
            mydor2.Opened += MyDor_Opened;
            myDor.Height = 50;
            mydor2.Height = 100;
        }

        private void MyDor_Opened(Door door)
        {
            MessageBox.Show("My Door is Opened");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDor.IsOpened = true;
            mydor2.IsOpened = true;
        }
        // && ,& | ,||  delegates events
    }
}
