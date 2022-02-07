using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Control_v3
{
    class Door
    {
        public delegate void DoorOpenHandler(Door door);
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public event DoorOpenHandler Opened;
        bool isOpened;
        public bool IsOpened { get
            {
                return this.isOpened;
            }
            set {
                this.isOpened = value;
                if (isOpened && Opened != null)
                    Opened(this );
            }
        }
    }
}
