
using System.Windows;


using System.Windows.Data;

namespace sr26
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _str;

        public static string StrFormat
        {
            get { return _str; }
            set { _str = value; }
        }

        const string F0 = "{0:F0}";
        const string F1 = "{0:F1}";
        const string F2 = "{0:F2}";
        const string F3 = "{0:F3}";

        private static string[] _strformat = { F0, F1, F2, F3 };
        //private string ;

        public static void SetStrFormat(string fmt)
        {
            int idx = int.Parse(fmt);
            StrFormat = _strformat[idx];
        }
    }

    public class NutrVal
    {
        public NutrVal()
        {

        }
        private float? _val;

        public float? Value
        {
            get { return _val; }
            set { _val = value; }
        }

        private string _units;

        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public string Nutrient { get; set; }

    }

    public class CompList
    {
        public CompList()
        {

        }
        public float? Value { get; set; }
        public string Food { get; set; }
    }
    
     public class Formatter : IValueConverter
     {


         public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             if (value != null || string.IsNullOrWhiteSpace(App.StrFormat) == true)
             {
                 string fmt = App.StrFormat;
                return string.Format(fmt,value);
             }
             return null;
         }

         public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             throw new System.NotImplementedException();
         }
     }

}
