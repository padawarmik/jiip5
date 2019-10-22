using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
