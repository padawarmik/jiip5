using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using WpfApp1.Commons;
namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Type classType;
        DbController dbController;
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
            dbController = new DbController();
            List<string> listOfTypes = GetListOfTypes();
            TypeSelector.ItemsSource = listOfTypes;
            LoadInputTypes(listOfTypes.First());
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            StatisticData.ItemsSource = dbController.ExecSelect("select * from [KASETY_502_17].[Z502_17].[CONVERSION_LOG]").DefaultView;
            StatisticData.AutoGenerateColumns = true;
        }

        private void LoadInputTypes(string className)
        {
            try
            {
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
            FillDataGrid();
        }

        private string ConvertValue() //TODO ogarnij to trochę
        {
            Object classInstance = classType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            String value = FromUnitSelector.Text;
            double convertFromValue = Double.Parse(ConvertFromValue.Text.Replace(".", ","));
            string fromUnit = FromUnitSelector.Text;
            string toUnit = ToUnitSelector.Text;
            string convertedValue;
            PropertyInfo set = classType.GetProperty(fromUnit);
            PropertyInfo get = classType.GetProperty(toUnit);
            if (set == null || get == null)
            {
                throw new MethodAccessException();
            }
            set.SetValue(classInstance, convertFromValue);
            convertedValue = get.GetValue(classInstance).ToString();
            DbLog(convertFromValue, fromUnit, toUnit, convertedValue);
            return convertedValue;
        }

        private void DbLog(double convertFromValue, string fromUnit, string toUnit, string convertedValue)
        {

            string sql = String.Format("INSERT INTO [Z502_17].[CONVERSION_LOG]([CL_UnitFrom],[CL_ValueFrom]," +
                "[CL_UnitTo],[CL_ValueTo], [CL_UnitType]) VALUES('{0}',{1},'{2}',{3}, '{4}')", fromUnit, ReplaceComma(convertFromValue), 
                    toUnit, ReplaceComma(convertedValue), classType.Name);
            int i = dbController.ExecStatement(sql);
            Log.Info(i.ToString());
        }

        private string ReplaceComma(object obj)
        {
            return obj.ToString().Replace(',', '.');
        }

        private void TypeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = TypeSelector.SelectedItem.ToString();
            Console.WriteLine(selected);
            LoadInputTypes(selected);


        }
    }
}

