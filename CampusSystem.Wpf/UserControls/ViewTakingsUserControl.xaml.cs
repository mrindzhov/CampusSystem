using System;
using System.Collections.Generic;
using System.Linq;
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
using CampusSystem.Data;
using CampusSystem.Data.Utility;

namespace CampusSystem.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for ViewTakingsUserControl.xaml
    /// </summary>
    public partial class ViewTakingsUserControl : UserControl
    {
        public ViewTakingsUserControl()
        {
            InitializeComponent();
            this.Takings.Text = Helper.GetTotalTakingsForCampus(AuthenticationManager.GetCurrentCampus().Id).ToString();
        }
    }
}
