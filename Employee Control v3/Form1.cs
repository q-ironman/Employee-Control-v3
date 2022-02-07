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
    public partial class Form1 : Form
    {
        
        EmployeeExcelService frm1EmployeeService = ServiceActivator.CreateService<EmployeeExcelService>();

        Form2 myfrm2;
        bool? isWorkingValue = null; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox_IsWorking.SelectedIndex = 0;

        }

        private void button_AddNew_Click(object sender, EventArgs e)
        {
            myfrm2 = new Form2();
            myfrm2.Operation = 0;
            myfrm2.ShowDialog();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            SearchingEmployee srchEmp = new SearchingEmployee();
            List<Employee> resultList = new List<Employee>();
            srchEmp.SearchingName = textBox_Name.Text;
            srchEmp.SearchingLastName = textBox_Lastname.Text;
            srchEmp.SearchingIsWorking = isWorkingValue;
            
            resultList = frm1EmployeeService.Search(srchEmp);
            dataGridView1.DataSource = resultList;
        }

        private void comboBox_IsWorking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_IsWorking.SelectedIndex == 0)
                isWorkingValue = null;
            if (comboBox_IsWorking.SelectedIndex == 1)
                isWorkingValue = true;
            if (comboBox_IsWorking.SelectedIndex == 2)
                isWorkingValue = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            string _id = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                frm1EmployeeService.Delete(_id);
                
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form2 updForm = new Form2();
                updForm.EmployeeID = _id;
                updForm.Operation = 1;
                updForm.Show();
            }
        }
    }
}
