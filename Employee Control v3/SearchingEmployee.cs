using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Control_v3
{
    class SearchingEmployee
    {
        string _name;
        string _lastName;
        bool? _isWorking;

        public string SearchingName { get { return this._name; } set { this._name = value; } }
        public string SearchingLastName { get { return this._lastName; } set { this._lastName = value; } }
        public bool? SearchingIsWorking { get { return this._isWorking; } set { this._isWorking = value; } }
    }
}
