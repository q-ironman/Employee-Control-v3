using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using LinqToExcel;

namespace Employee_Control_v3
{
    class EmployeeExcelService : IEmployeeService
    {
        string _path;
        FileInfo fileInfo;
        public EmployeeExcelService(): this(@"C:\Users\osman\Desktop\Lectures\C#\Employee Control v3\Employees.xlsx")
        {

        }
        public EmployeeExcelService(string path)
        {
            this._path = path;
            fileInfo = new FileInfo(_path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!File.Exists(_path))
            {
                var package = new ExcelPackage(fileInfo);
                var empWs = package.Workbook.Worksheets.Add("Employees");
                empWs.Cells["A1"].Value = "Employee ID";
                empWs.Cells["B1"].Value = "Name";
                empWs.Cells["C1"].Value = "Lastname";
                empWs.Cells["D1"].Value = "Birth Date";
                empWs.Cells["E1"].Value = "Start Date";
                empWs.Cells["F1"].Value = "End Date";
                empWs.Cells["G1"].Value = "City";
                empWs.Cells["H1"].Value = "Country";
                empWs.Cells["I1"].Value = "Adress";
                empWs.Cells["J1"].Value = "Postal Code";
                empWs.Cells["K1"].Value = "Reason";
                empWs.Cells["L1"].Value = "Mobile Phone";
                empWs.Cells["M1"].Value = "Phone";
                empWs.Cells["N1"].Value = "Is Working";
                empWs.Cells.AutoFitColumns();
                package.Save();
                empWs.Dispose();
                package.Dispose();

            }
            


        }
        public void Delete(string _id)
        {
            ExcelQueryFactory myFactory = new ExcelQueryFactory(_path);


        }

        public void Insert(Employee newEmployee)
        {
            int i = 1;
            fileInfo = new FileInfo(this._path);
            var package = new ExcelPackage(fileInfo);
            var empWs = package.Workbook.Worksheets["Employees"];
            var end = empWs.Dimension.End;
            var row = end.Row + 1;
            empWs.Cells[row, i].Value = newEmployee.EmployeeID;i++;
            empWs.Cells[row, i].Value = newEmployee.Name;i++;
            empWs.Cells[row, i].Value = newEmployee.LastName; i++;
            empWs.Cells[row, i].Value = newEmployee.BirthDate.ToString(); i++;
            empWs.Cells[row, i].Value = newEmployee.StartDate.ToString(); i++;
            empWs.Cells[row, i].Value = newEmployee.EndDate.ToString(); i++;
            empWs.Cells[row, i].Value = newEmployee.City; i++;
            empWs.Cells[row, i].Value = newEmployee.Country; i++;
            empWs.Cells[row, i].Value = newEmployee.Adress; i++;
            empWs.Cells[row, i].Value = newEmployee.PostalCode; i++;
            empWs.Cells[row, i].Value = newEmployee.Reason; i++;
            empWs.Cells[row, i].Value = newEmployee.MoPhone; i++;
            empWs.Cells[row, i].Value = newEmployee.Phone; i++;
            empWs.Cells[row, i].Value = newEmployee.IsWorking;
            empWs.Cells.AutoFitColumns();
            package.Save();
            empWs.Dispose();
            package.Dispose();
        }

        public List<Employee> Search(SearchingEmployee searchingEmployee)
        {
            ExcelQueryFactory myFactory = new ExcelQueryFactory(_path);
            
            fileInfo = new FileInfo(_path);
            var package = new ExcelPackage(fileInfo);
            var empWs = package.Workbook.Worksheets["Employees"];
            List<Row> res = new List<Row>();
            List<Employee> result = new List<Employee>();
            if (!String.IsNullOrEmpty(searchingEmployee.SearchingName))
            {
                //result = myFactory.Worksheet<Employee>("Employees").Where(x => x.Name == searchingEmployee.SearchingName).ToList();
                res = (from c in myFactory.Worksheet("Employees")
                       where c["Name"] == searchingEmployee.SearchingName
                       select c).ToList();
            }
            if (!String.IsNullOrEmpty(searchingEmployee.SearchingLastName))
            {
                //result = myFactory.Worksheet<Employee>("Employees").Where(x => x.Name == searchingEmployee.SearchingName).ToList();
                res = (from c in myFactory.Worksheet("Employees")
                       where c["Lastname"] == searchingEmployee.SearchingLastName
                       select c).ToList();
            }
            if(searchingEmployee.SearchingIsWorking.HasValue)
            {
                string iswrkingstr = null;
                if (searchingEmployee.SearchingIsWorking == true)
                    iswrkingstr = "TRUE";
                else
                    iswrkingstr = "FALSE";

                res = (from c in myFactory.Worksheet("Employees")
                       where c["Is Working"].ToString() == iswrkingstr
                       select c).ToList();
            }
            foreach (var emp in res)
            {
                Employee tmp = new Employee();
                tmp.EmployeeID = emp["Employee ID"];
                tmp.Name = emp[1];
                tmp.LastName = emp[2];
                tmp.BirthDate = Convert.ToDateTime(emp[3]);
                tmp.StartDate = Convert.ToDateTime(emp[4]);
                if (String.IsNullOrEmpty(emp[5]))
                {
                    tmp.EndDate = null;
                }
                else
                    tmp.EndDate = Convert.ToDateTime(emp[5]);
                tmp.City = emp[6];
                tmp.Country = emp[7];
                tmp.Adress = emp[8];
                tmp.PostalCode = emp[9];
                tmp.Reason = emp[10];
                tmp.MoPhone = emp[11];
                tmp.Phone = emp[12];
                tmp.IsWorking = Convert.ToBoolean(emp[13]);
                result.Add(tmp);
            }
            return result;
        }

        public void Update(Employee updEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
