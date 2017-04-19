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
using CampusSystem.Models;

namespace CampusSystem.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for ViewUnsignedGuestsUserControl.xaml
    /// </summary>
    public partial class ViewUnsignedGuestsUserControl : UserControl
    {
        public ViewUnsignedGuestsUserControl()
        {
            InitializeComponent();
            LoadGuests();
        }

        private void LoadGuests()
        {
            Data.ItemsSource = Helper.GetAllUnsignedGuests();
        }

        private void ButtonReleaseGuest(object sender, RoutedEventArgs e)
        {
            var guest = Data.SelectedItem as Guest;
            //MessageBox.Show($"{ex.Message}", "Cannot add empty guest", MessageBoxButton.OK, MessageBoxImage.Error);

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to release {guest.FullName}", "Release guest", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Helper.ReleaseGuest(guest);
            }
            LoadGuests();
        }

        private void DataGridTextColumn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var asd = e.Handled;
        }
    }
}
