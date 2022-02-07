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
    public partial class Form2 : Form
    {
        public int Operation { get; set; }
        public string EmployeeID { get; set; }
        EmployeeExcelService frm2Service = ServiceActivator.CreateService<EmployeeExcelService>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(this.Operation == 0)
            {
                button_Save.Text = "Save New";
            }
            //if(this.Operation == 1)
            //{
            //    button_Save.Text = "Save Changes";
            //    Employee upd = frm2Service.RtrnUpdEmp(EmployeeID);
            //    textBox_Name.Text = upd.Name;
            //    textBox_Lastname.Text = upd.LastName;
            //    Picker_BrthDate.Value = upd.BirthDate;
            //    Picker_StrtDate.Value = upd.StartDate;
            //    if (!upd.EndDate.HasValue)
            //    {
            //        Picker_EndDate.Format = DateTimePickerFormat.Custom;
            //        Picker_EndDate.CustomFormat = " ";
            //    }

            //    else
            //    {
            //        Picker_EndDate.Format = DateTimePickerFormat.Short;
            //        Picker_EndDate.Value = Convert.ToDateTime(upd.EndDate);
            //    }
            //    textBox_City.Text = upd.City;
            //    textBox_Country.Text = upd.Country;
            //    textBox_Adress.Text = upd.Adress;
            //    textBox_Reason.Text = upd.Reason;
            //    textBox_MoPhone.Text = upd.MoPhone;
            //    textBox_Phone.Text = upd.Phone;
            //    textBox_PostalCode.Text = upd.PostalCode;
            //    checkBox_IsWorking.Checked = upd.IsWorking.Value;
                              
                
            //}
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(Operation == 0)
            {
                Employee newEmp = new Employee();
                newEmp.Name = textBox_Name.Text;
                newEmp.LastName = textBox_Lastname.Text;
                newEmp.BirthDate = Picker_BrthDate.Value;
                newEmp.StartDate = Picker_StrtDate.Value;
                if(Picker_EndDate.Format == DateTimePickerFormat.Custom)
                {
                    newEmp.EndDate = null;
                }
                if(Picker_EndDate.Format == DateTimePickerFormat.Short)
                {
                    newEmp.EndDate = Picker_EndDate.Value;
                }
                newEmp.City = textBox_City.Text;
                newEmp.Country = textBox_Country.Text;
                newEmp.Adress = textBox_Adress.Text;
                newEmp.Reason = textBox_Reason.Text;
                newEmp.MoPhone = textBox_MoPhone.Text;
                newEmp.Phone = textBox_Phone.Text;
                newEmp.PostalCode = textBox_PostalCode.Text;
                newEmp.IsWorking = checkBox_IsWorking.Checked;
                frm2Service.Insert(newEmp);
                //this.Close();
            }
            //if(Operation == 1)
            //{
            //    Employee upd = new Employee();
            //    upd.Name = textBox_Name.Text;
            //    upd.LastName = textBox_Lastname.Text;
            //    upd.BirthDate = Picker_BrthDate.Value;
            //    upd.StartDate = Picker_StrtDate.Value;
            //    if (Picker_EndDate.Format == DateTimePickerFormat.Custom)
            //        upd.EndDate = null;
            //    if (Picker_EndDate.Format == DateTimePickerFormat.Short)
            //        upd.EndDate = Picker_EndDate.Value;
            //    upd.City = textBox_City.Text;
            //    upd.Country = textBox_Country.Text;
            //    upd.Adress = textBox_Adress.Text;
            //    upd.Reason = textBox_Reason.Text;
            //    upd.MoPhone = textBox_MoPhone.Text;
            //    upd.Phone = textBox_Phone.Text;
            //    upd.PostalCode = textBox_PostalCode.Text;
            //    upd.IsWorking = checkBox_IsWorking.Checked;
            //    frm2Service.Update(upd);
                
            //}
            this.Close();
        }

        private void Picker_EndDate_ValueChanged(object sender, EventArgs e)
        {
            Picker_EndDate.Format = DateTimePickerFormat.Short;
        }
    }
}
