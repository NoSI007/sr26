using System.Windows;
using System.Windows.Media;

namespace sr26
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        Brush bg = Brushes.Red;
        public HomePage()
        {
            InitializeComponent();
            this.Loaded += HomePage_Loaded;
        }

        void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            bg = BBrowse.Background;
            BBrowse.IsChecked = true;
        }


        private void ToggVis()
        {

             if(BBrowse.IsChecked == true )
             {
                 z_browse.Visibility = System.Windows.Visibility.Visible;
                 z_compare.Visibility = System.Windows.Visibility.Collapsed;
                 //BBrowse.Background = Brushes.Red;
                 //BComp.Background = bg;
             }
             else if(BComp.IsChecked == true )
            {
                z_browse.Visibility = System.Windows.Visibility.Collapsed;
                z_compare.Visibility = System.Windows.Visibility.Visible;
                //BBrowse.Background = bg;
                //BComp.Background = Brushes.Red;
            }
        }

      

        private void BrowseOrCompare(object sender, RoutedEventArgs e)
        {
            ToggVis();
        }
    }
}
