using System.Collections.Generic;

namespace WpfApp1.Convert
{
    class Temperature
    {
        public double celsius;
        public double Celsius
        {
            get { return this.celsius; }
            set { this.celsius = value; }
        }
        public double Farenheit
        {
            get { return this.celsius * 9 / 5 + 32; }
            set { this.celsius = (value - 32) * 5 / 9; }
        }
        public double Kelvin
        {
            get { return this.celsius + 273.15; }
            set { this.celsius = value - 273.15; }
        }
        public double Rankine
        {
            get { return (this.celsius + 273.15) * 9 / 5; }
            set { this.celsius = (value - 491.67) * 5 / 9; }
        }
        

       

        public static List<string> GetListOfProperties()
        {
            List<string> array = new List<string>();
            foreach(var prop in typeof(Temperature).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
