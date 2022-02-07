using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Control_v3
{
    class Employee
    {
        string _id;
        string _name;
        string _lastName;
        DateTime _birthDate;
        DateTime _startDate;
        DateTime? _endDate;
        bool? _isWorking;
        string _city;
        string _country;
        string _adress;
        string _reason;
        string _moPhone;
        string _phone;
        string _postalCode;

        public string EmployeeID { get { return this._postalCode + Convert.ToInt32(this._phone) % 1000; } set { this._id = this._postalCode + Convert.ToInt32(this._phone) % 1000; } }
        public string Name { get { return this._name; } set { this._name = value; } }
        public string LastName { get { return this._lastName; } set { this._lastName = value; } }
        public DateTime BirthDate { get { return this._birthDate; } set { this._birthDate = value; } }
        public DateTime StartDate { get { return this._startDate; } set { this._startDate = value; } }
        public DateTime? EndDate { get { return this._endDate; } set { this._endDate = value; } }
        public bool? IsWorking { get { return this._isWorking; } set { this._isWorking = value; } }
        public string City { get { return this._city; } set { this._city = value; } }
        public string Country { get { return this._country; } set { this._country = value; } }
        public string Adress { get { return this._adress; } set { this._adress = value; } }
        public string Reason { get { return this._reason; } set { this._reason = value; } }
        public string MoPhone { get { return this._moPhone; } set { this._moPhone = value; } }
        public string Phone { get { return this._phone; } set { this._phone = value; } }
        public string PostalCode { get { return this._postalCode; } set { this._postalCode = value; } }
    }
}
