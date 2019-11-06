using System.Collections.Generic;

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
        public double Decymeter
        {
            get { return this.meter * 10; }
            set { this.meter = value / 10; }
        }
        public double Feet
        {
            get { return this.meter * 3.2808; }
            set { this.meter = value / 3.2808; }
        }
        public double Inch
        {
            get { return this.meter * 39.37; }
            set { this.meter = value / 39.37; }
        }
        public double Mile
        {
            get { return this.meter * 0.000621; }
            set { this.meter = value / 0.000621; }
        }
        public double Yard
        {
            get { return this.meter * 1.0936; }
            set { this.meter = value / 1.0936; }
        }
        public double Nautical_mile
        {
            get { return this.meter * 0.0005399; }
            set { this.meter = value / 0.0005399; }
        }
        public double Cable
        {
            get { return this.meter * 0.005399; }
            set { this.meter = value / 0.005399; }
        }
        

        public static List<string> GetListOfProperties()
        {
            List<string> array = new List<string>();
            foreach(var prop in typeof(Length).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
