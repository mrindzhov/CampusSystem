namespace CampusSystem.Wpf.UserControls
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;

    /// <summary>
    /// Interaction logic for AddGuestUserControl.xaml
    /// </summary>
    public partial class AddGuestUserControl : UserControl
    {
        public AddGuestUserControl()
        {
            InitializeComponent();
            Rooms.ItemsSource = RoomService.GetRoomsByCampus(AuthenticationManager.GetCurrentCampus()).Select(r => r.Number);
            Student.ItemsSource = StudentService.GetStudentsByCampus(AuthenticationManager.GetCurrentCampus().Id).Select(c => c.FullName);
        }

        private void AddGuest(object sender, RoutedEventArgs e)
        {
            try
            {
                var townName = this.Town.Text.ToString();
                var student = RoomService.GetStudentByRoomAndName(
                        Rooms.SelectedItem.ToString(), Student.SelectedItem.ToString());

                Guest guest = new Guest
                {
                    FirstName = this.FirstName.Text ?? "",
                    MiddleName = this.MiddleName.Text ?? "",
                    LastName = this.LastName.Text ?? "",
                    StudentVisited = student,
                    Town = TownService.GetTownByName(townName)

                };
                GuestService.AddGuest(guest);
                MessageBox.Show($"Added guest {this.FirstName.Text} {this.LastName.Text} to {student.FullName}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Content = new AddGuestUserControl();

            }
            catch (Exception)
            {
                MessageBox.Show($"You need to fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}