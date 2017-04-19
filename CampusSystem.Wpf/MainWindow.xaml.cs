using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using CampusSystem.Wpf.UserControls;

namespace CampusSystem.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = new ViewHomeUserControl();
            RoomsList.ItemsSource = Helper.GetRooms();
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(RoomsList.ItemsSource);
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription("Campus.Number");
            //view.GroupDescriptions.Add(groupDescription);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ButtonViewRoom(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewRoomUserControl();
        }
        private void ButtonViewStudents(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ViewStudentUserControl();
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
            this.Hide();
            AuthenticationManager.Logout();
        }
    }
}
