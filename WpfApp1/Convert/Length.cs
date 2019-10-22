using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Convert
{
    class Length
    {
        public double meter;
        public double Meter {
            get { return this.meter; }
            set { this.meter = value; }
        }
        public double Kilometer{
            get { return this.meter / 1000; }
            set { this.meter = value * 1000; }
        }
        public double Centimeter{
            get { return this.meter * 100; }
            set { this.meter = value / 100; }
        }
        public double Millimeter{
            get { return this.meter * 1000; }
            set { this.meter = value / 1000; }
        }
        public double Decymeter{
            get { return this.meter * 10; }
            set { this.meter = value / 10; }
        }


    }
}
