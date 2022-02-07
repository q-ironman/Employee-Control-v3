using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Employee_Control_v3
{
    class EmployeeXMLService : IEmployeeService
    {
        string _path;
        XDocument doc;
        
        public EmployeeXMLService():this(@"C:\Users\osman\Desktop\Lectures\C#\Employee Control v3\Employees.xml")
        {

        }
        public EmployeeXMLService(string path)
        {
            _path = path;
            if (!File.Exists(_path))
            {
                doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Employees"));
                doc.Save(_path);
            }

        }
        //public static EmployeeXMLService OnCreate()
        //{
        //    return new EmployeeXMLService(@"C:\Users\osman\Desktop\Lectures\C#\Employee Control v3\Employees.xml");
        //}
        //public static EmployeeXMLService OnCreate(string path)
        //{

        //    return new EmployeeXMLService(path);
        //}
        public void Delete(string _id)
        {
            XDocument emps = XDocument.Load(_path);
            //emps.Descendants("Employee").Where(x => x.Element("ID").Value == _id).Remove();
            //emps.Save(_path);
            emps.Descendants("Employee").Single(x => x.Element("ID").Value == _id).Remove();
            emps.Save(_path);


        }

        public void Insert(Employee newEmployee)
        {

            XElement newXele = XElement.Load(_path);
            newXele.Add(new XElement("Employee",
                new XElement("ID", newEmployee.EmployeeID),
                new XElement("Name",newEmployee.Name),
                new XElement ("Lastname",newEmployee.LastName),
                new XElement ("BirthDate",newEmployee.BirthDate),
                new XElement ("StartDate",newEmployee.StartDate),
                new XElement ("EndDate",newEmployee.EndDate),
                new XElement ("City",newEmployee.City),
                new XElement ("Country",newEmployee.Country),
                new XElement ("Adress",newEmployee.Adress),
                new XElement ("Reason",newEmployee.Reason),
                new XElement ("MobilePhone",newEmployee.MoPhone),
                new XElement ("Phone",newEmployee.Phone),
                new XElement ("PostalCode",newEmployee.PostalCode),
                new XElement ("IsWorking",newEmployee.IsWorking)));
            newXele.Save(_path);
        }

        public List<Employee> Search(SearchingEmployee searchingEmployee)
        {
            XElement resultEle = XElement.Load(_path);
            List<Employee> rslt = new List<Employee>();
            IEnumerable<XElement> res = null;
            if(!String.IsNullOrEmpty(searchingEmployee.SearchingName))
            {                
                res = from employee in resultEle.Elements("Employee")
                      where employee.Element("Name").Value == searchingEmployee.SearchingName
                      select employee;
                
            }
            if(!String.IsNullOrEmpty(searchingEmployee.SearchingLastName))
            {
                res = from employee in resultEle.Elements("Employee")
                      where employee.Element("Lastname").Value == searchingEmployee.SearchingLastName
                      select employee;
            }
            if(searchingEmployee.SearchingIsWorking.HasValue)
            {
                res = from employee in resultEle.Elements("Employee")
                      where Convert.ToBoolean(employee.Element("IsWorking").Value) == searchingEmployee.SearchingIsWorking
                      select employee;
            }
            foreach (XElement emp in res)
            {
                Employee tmp = new Employee();
                tmp.Name = emp.Element("Name").Value;
                tmp.LastName = emp.Element("Lastname").Value;
                tmp.BirthDate = Convert.ToDateTime(emp.Element("BirthDate").Value);
                tmp.StartDate = Convert.ToDateTime(emp.Element("StartDate").Value);
                if (String.IsNullOrEmpty(emp.Element("EndDate").Value))
                    tmp.EndDate = null;
                else
                    tmp.EndDate = Convert.ToDateTime(emp.Element("EndDate").Value);

                tmp.City = emp.Element("City").Value;
                tmp.Country = emp.Element("Country").Value;
                tmp.Adress = emp.Element("Adress").Value;
                tmp.Reason = emp.Element("Reason").Value;
                tmp.MoPhone = emp.Element("MobilePhone").Value;
                tmp.Phone = emp.Element("Phone").Value;
                tmp.PostalCode = emp.Element("PostalCode").Value;
                tmp.IsWorking = Convert.ToBoolean(emp.Element("IsWorking").Value);
                rslt.Add(tmp);

            }
            return rslt;
        }

        public void Update(Employee updEmployee)
        {
            string updEmpId = updEmployee.EmployeeID;
            XDocument empsDoc = XDocument.Load(_path);
            XElement upEmpEle = empsDoc.Descendants("Employee").Single(x => x.Element("ID").Value == updEmpId);
            upEmpEle.Element("Name").Value = updEmployee.Name;
            upEmpEle.Element("Lastname").Value = updEmployee.LastName;
            upEmpEle.Element("BirthDate").Value = updEmployee.BirthDate.ToString();
            upEmpEle.Element("StartDate").Value = updEmployee.StartDate.ToString();
            upEmpEle.Element("EndDate").Value = updEmployee.EndDate.ToString();
            upEmpEle.Element("City").Value = updEmployee.City;
            upEmpEle.Element("Country").Value = updEmployee.Country;
            upEmpEle.Element("Adress").Value = updEmployee.Adress;
            upEmpEle.Element("Reason").Value = updEmployee.Reason;
            upEmpEle.Element("MobilePhone").Value = updEmployee.MoPhone;
            upEmpEle.Element("Phone").Value = updEmployee.Phone;
            upEmpEle.Element("PostalCode").Value = updEmployee.PostalCode;
            upEmpEle.Element("IsWorking").Value = updEmployee.IsWorking.ToString();
            empsDoc.Save(_path);

        }
        public Employee RtrnUpdEmp(string _id)
        {
            XDocument doc = XDocument.Load(_path);
            XElement upEmpele = doc.Descendants("Employee").Single(x => x.Element("ID").Value == _id);
            Employee upEmployee = new Employee();
            upEmployee.Name = upEmpele.Element("Name").Value;
            upEmployee.LastName = upEmpele.Element("Lastname").Value;
            upEmployee.BirthDate = Convert.ToDateTime(upEmpele.Element("BirthDate").Value);
            upEmployee.StartDate = Convert.ToDateTime(upEmpele.Element("StartDate").Value);
            if (String.IsNullOrEmpty(upEmpele.Element("EndDate").Value))
                upEmployee.EndDate = null;
            else
                upEmployee.EndDate = Convert.ToDateTime(upEmpele.Element("EndDate").Value);
            upEmployee.City = upEmpele.Element("City").Value;
            upEmployee.Country = upEmpele.Element("Country").Value;
            upEmployee.Adress = upEmpele.Element("Adress").Value;
            upEmployee.Reason = upEmpele.Element("Reason").Value;
            upEmployee.MoPhone = upEmpele.Element("MobilePhone").Value;
            upEmployee.Phone = upEmpele.Element("Phone").Value;
            upEmployee.PostalCode = upEmpele.Element("PostalCode").Value;
            upEmployee.IsWorking = Convert.ToBoolean(upEmpele.Element("IsWorking").Value);


            return upEmployee;
        }
    }
}
