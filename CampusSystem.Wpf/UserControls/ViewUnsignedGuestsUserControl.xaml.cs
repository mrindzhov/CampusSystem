namespace CampusSystem.Wpf.UserControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;

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
            Data.ItemsSource = GuestService.GetAllUnsignedGuestsForCampus(AuthenticationManager.GetCurrentCampus().Id);
        }

        private void ButtonReleaseGuest(object sender, RoutedEventArgs e)
        {
            var guest = Data.SelectedItem as Guest;
            //MessageBox.Show($"{ex.Message}", "Cannot add empty guest", MessageBoxButton.OK, MessageBoxImage.Error);

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to release {guest.FullName}", "Release guest", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                GuestService.ReleaseGuest(guest);
            }
            LoadGuests();
        }

        private void DataGridTextColumn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var asd = e.Handled;
        }
    }
}
