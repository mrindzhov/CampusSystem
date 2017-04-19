namespace CampusSystem.Wpf.UserControls
{
    using System.Windows.Controls;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;

    /// <summary>
    /// Interaction logic for ViewTakingsUserControl.xaml
    /// </summary>
    public partial class ViewTakingsUserControl : UserControl
    {
        public ViewTakingsUserControl()
        {
            InitializeComponent();
            this.Takings.Text = GeneralService.GetTotalTakingsForCampus(AuthenticationManager.GetCurrentCampus().Id).ToString();
        }
    }
}
