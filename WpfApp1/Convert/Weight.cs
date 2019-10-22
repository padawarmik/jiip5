using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Convert
{
    class Weight
    {
        public double gram;
        public double Gram
        {
            get { return this.gram; }
            set { this.gram = value; }
        }
        

       

        public static List<string> GetListOfProperties()
        {
            List<string> array = new List<string>();
            foreach(var prop in typeof(Weight).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
