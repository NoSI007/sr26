using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace sr26
{

    
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class NutCompare : UserControl
    {
        Sr26Entities db = new Sr26Entities();
        short GroupCd;
        //short Nutr_No;
        NUTR_DEF t_Nutr_Def;
        public NutCompare()
        {
            InitializeComponent();
            this.Loaded += NutCompare_Loaded;
        }

        void NutCompare_Loaded(object sender, RoutedEventArgs e)
        {
            this.fD_GROUPComboBox.DataContext = db.FD_GROUP.ToList<FD_GROUP>();
            this.Nuts.DataContext = db.NUTR_DEF.ToList<NUTR_DEF>();
        }




       

     

     

        private bool GetGroup()
        {

            if (fD_GROUPComboBox.SelectedItem == null)
                return false;

            short.TryParse(fD_GROUPComboBox.SelectedValue.ToString(), out this.GroupCd);
            return true;
        }
      
        private bool GetNut()
        {
           
            if (Nuts.SelectedValue == null)
            {
                t_Nutr_Def = null;
                return false;
            }
            else
            {
                t_Nutr_Def = (NUTR_DEF)Nuts.SelectedItem;
            }
            //short.TryParse(Nuts.SelectedValue.ToString(), out this.Nutr_No);
            return true;
        }

       

     

      

       

        private void CompareBtn_Click(object sender, RoutedEventArgs e)
        {
            List4Compare();
        }

        private void List4Compare()
        {


            if (GetNut() == false || GetGroup() == false)
                return;

            var foo = from f in db.FOOD_DES 
                      where f.FdGrp_Cd == this.GroupCd 
                      select f;

            CommonSearch(foo);
        }

        private void CommonSearch(IQueryable<FOOD_DES> foo)
        {
            var res = from v in db.NUT_DATA
                      join f in foo on v.NDB_No equals f.NDB_No
                      where v.Nutr_No == t_Nutr_Def.Nutr_No
                      orderby v.Nutr_Val descending
                      select new CompList { Value = v.Nutr_Val, Food = f.Long_Desc };

            //make sure its done before the datacontext is set for the conversion to HAPPEN.
            App.SetStrFormat(t_Nutr_Def.Num_Dec);
            CmpRes.DataContext = res.ToList<CompList>();

            int count = res.Count();

            AddHead(count);
        }
        private void FindKword()
        {

            if ( GetNut() == false)
            {
                return;// missing search word.
            }
            
            if( string.IsNullOrWhiteSpace(Kword.Text) == true )
            {
                var foo = from f in db.FOOD_DES
                          select f;
                CommonSearch(foo);
            }
            else
            { 
                var foo = from f in db.FOOD_DES
                        where f.Long_Desc.Contains(Kword.Text)
                        select f;

                CommonSearch(foo);
            }
            
        }
        private void AddHead(int count)
        {
            NUTR_DEF ndf = (NUTR_DEF)Nuts.SelectedItem;

            BTHead.Text = string.Format("Comapring ( {0} ) Records For ( {1} ) in ( {2} ) Units.", count, ndf.NutrDesc, ndf.Units);
        }

        private void SearchCompBtn_Click(object sender, RoutedEventArgs e)
        {
            FindKword();
        }

       
    }
}
