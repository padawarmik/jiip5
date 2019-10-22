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
        Type classType;
        public List<string> GetListOfTypes()
        {
            List<string> listOfClasses = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.Namespace == "WpfApp1.Convert")
                {
                    listOfClasses.Add(type.Name);
                }
            }
            return listOfClasses;
        }
        public MainWindow()
        {
            InitializeComponent();
            List<string> listOfTypes = GetListOfTypes();
            TypeSelector.ItemsSource = listOfTypes;
            LoadInputTypes(listOfTypes.First());
        }

        private void LoadInputTypes(string className)
        {
            try
            {
                Console.WriteLine("className: " + className);
                classType = Type.GetType("WpfApp1.Convert." + className);
                if (classType != null)
                {
                    MethodInfo method = classType.GetMethod("GetListOfProperties");
                    List<string> propertiesList = (List<string>)method.Invoke(null, null);
                    FillComboBox(FromUnitSelector, propertiesList);
                    FillComboBox(ToUnitSelector, propertiesList);
                }
            }
            catch (Exception e){
                Console.WriteLine(e.StackTrace);
            }
        }

        private void FillComboBox(ComboBox comboBox, List<string> propertiesList)
        {
            comboBox.ItemsSource = propertiesList;
            comboBox.SelectedItem = propertiesList.First();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue.Text = ConvertValue();
        }

        private string ConvertValue()
        {
            Object classInstance = classType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            String value = FromUnitSelector.Text;
            double convertFromValue = Double.Parse(ConvertFromValue.Text);
            PropertyInfo set = classType.GetProperty(FromUnitSelector.Text);
            PropertyInfo get = classType.GetProperty(ToUnitSelector.Text);
            if (set == null || get == null)
            {
                throw new MethodAccessException();
            }
            set.SetValue(classInstance, convertFromValue);
            return get.GetValue(classInstance).ToString();
        }

        private void TypeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = TypeSelector.SelectedItem.ToString();
            Console.WriteLine(selected);
            LoadInputTypes(selected);


        }
    }
}

