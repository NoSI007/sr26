using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace sr26
{
    /// <summary>
    /// Interaction logic for Listing.xaml
    /// </summary>
    //public partial class Listing : UserControl
    //{
    //    public Listing()
    //    {
    //        InitializeComponent();
    //    }
    //}

    public partial class Listing : UserControl
    {
        Sr26Entities db = new Sr26Entities();
        short GroupCd;
        public Listing()
        {
            InitializeComponent();
            Loaded += Listing_Loaded;
        }

        void Listing_Loaded(object sender, RoutedEventArgs e)
        {
            if( db != null)
            {
                this.fD_GROUPComboBox.DataContext = db.FD_GROUP.ToList<FD_GROUP>();
                BSBtn.Content = "";
                ToggleBtn();
            }

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            FindKword();
        }

        private void FindKword()
        {
            if (GetGroup() == false)
                return;

            if (string.IsNullOrWhiteSpace(Kword.Text) == true)
            {
                var res = from f in db.FOOD_DES
                          where f.FdGrp_Cd == GroupCd
                          orderby f.Long_Desc
                          select f;
                Lv4search.DataContext = res.ToList<FOOD_DES>();

                AddSearchHeader(res);
            }
            else
            {
                var res = from f in db.FOOD_DES
                          where f.Long_Desc.Contains(Kword.Text) && f.FdGrp_Cd == GroupCd
                          orderby f.Long_Desc
                          select f;

                Lv4search.DataContext = res.ToList<FOOD_DES>();

                AddSearchHeader(res);
            }
        }

        private void AddSearchHeader(IOrderedQueryable<FOOD_DES> res)
        {
            STHead.Text = string.Format("{0} Results Found.", res.Count());
        }

        private void fD_GROUPComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FoodCombo();
        }

        private void FoodCombo()
        {


            if (GetGroup() == false)
                return;


            List<FOOD_DES> grplist = (from f in db.FOOD_DES
                                      where f.FdGrp_Cd == GroupCd
                                      orderby f.Long_Desc
                                      select f).ToList<FOOD_DES>();

            fOOD_DESComboBox.DataContext = grplist;
        }

        private bool GetGroup()
        {

            if (fD_GROUPComboBox.SelectedItem == null)
                return false;

            short.TryParse(fD_GROUPComboBox.SelectedValue.ToString(), out this.GroupCd);
            return true;
        }
        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            ListNuts();
        }

        private void ListNuts()
        {
            if (fOOD_DESComboBox.SelectedValue == null)
                return;
            int ndb = int.Parse(fOOD_DESComboBox.SelectedValue.ToString());

            RenderNuts4(ndb);
        }

        private void RenderNuts4(int ndb)
        {
            var res = from v in db.NUT_DATA
                      join n in db.NUTR_DEF on v.Nutr_No equals n.Nutr_No
                      where v.NDB_No == ndb
                      select new NutrVal { Value = v.Nutr_Val, Units = n.Units, Nutrient = n.NutrDesc };

            Lv4Nuts.DataContext = res.ToList<NutrVal>();
            var foo = (from f in db.FOOD_DES
                       where f.NDB_No == ndb
                       select f).Distinct().FirstOrDefault();

            BTHead.Text = string.Format("{0} Results Found for {1}", res.Count(), foo.Long_Desc);
        }


        private void Lv4search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lv4search.SelectedValue == null)
                return;
            int ndb = int.Parse(Lv4search.SelectedValue.ToString());
            RenderNuts4(ndb);
        }


        private void BSBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleBtn();
        }

        private void ToggleBtn()
        {
            if (BSBtn.Content.Equals("Browse") == true)
            {
                BSBtn.Content = "Search";
                BSp.Visibility = System.Windows.Visibility.Collapsed;
                SSp.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                BSBtn.Content = "Browse";
                BSp.Visibility = System.Windows.Visibility.Visible;
                SSp.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
