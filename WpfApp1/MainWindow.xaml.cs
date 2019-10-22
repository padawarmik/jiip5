using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Convert;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FromUnitSelector.ItemsSource = Enum.GetValues(typeof(Units)).Cast<Units>().ToList(); ;
            ToUnitSelector.ItemsSource = Enum.GetValues(typeof(Units)).Cast<Units>().ToList(); ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String value = FromUnitSelector.Text;
            double convertFromValue = Double.Parse(ConvertFromValue.Text);
            Length l = new Length();
            PropertyInfo set = typeof(Length).GetProperty(FromUnitSelector.Text);
            PropertyInfo get = typeof(Length).GetProperty(ToUnitSelector.Text);
            if (set == null || get == null)
            {
                Console.Write("null");
                throw new MethodAccessException();
            }
            set.SetValue(l, convertFromValue);
            ReturnValue.Text = get.GetValue(l).ToString();
            
        }
    }
}

