namespace CampusSystem.Wpf
{
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Input;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;
    using CampusSystem.Wpf.UserControls;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.contentControl.Content = new ViewHomeUserControl();
            //RoomsList.ItemsSource = Helper.GetRoomsByCampus(AuthenticationManager.GetCurrentCampus());
            this.DataContext = RoomService.GetRoomsByCampus(AuthenticationManager.GetCurrentCampus());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ButtonAddGuest(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddGuestUserControl();
        }

        private void ButtonAddRoom(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddRoomUserControl();
        }

        private void ButtonAddCampus(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddCampusUserControl();
        }

        private void ButtonAddUniversity(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddUniversityUserControl();
        }

        private void ButtonAddStudent(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddStudentUserControl();
        }

        private void ButtonViewRoom(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewRoomUserControl();
        }
        private void ButtonViewStudents(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewStudentUserControl();
        }

        private void ButtonViewTakings(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewTakingsUserControl();
        }

        private void ButtonViewUnsignedGuests(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewUnsignedGuestsUserControl();
        }

        private void ButtonViewHome(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewHomeUserControl();
        }
        private void ButtonLogout(object sender, RoutedEventArgs e)
        {

            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
            AuthenticationManager.Logout();
        }

        private void RoomsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var test = ((Room)RoomsList.SelectedItem).Number;
            System.Console.WriteLine(e);
        }
    }
}
