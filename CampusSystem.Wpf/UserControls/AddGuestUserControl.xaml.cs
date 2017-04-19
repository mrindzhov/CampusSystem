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
    /// Interaction logic for AddGuestUserControl.xaml
    /// </summary>
    public partial class AddGuestUserControl : UserControl
    {
        public AddGuestUserControl()
        {
            InitializeComponent();
            Rooms.ItemsSource = Helper.GetRooms().Select(r => r.Number);
            Student.ItemsSource = Helper.GetStudents().Select(c => c.FullName);
        }

        private void AddGuest(object sender, RoutedEventArgs e)
        {
            try
            {
                //var fullNameArgs = this.FullName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var townName = this.Town.Text.ToString();
                var student = Helper.GetStudentByRoomAndName(
                        Rooms.SelectedItem.ToString(), Student.SelectedItem.ToString());

                Guest guest = new Guest
                {
                    FirstName = this.FirstName.Text ?? "",
                    MiddleName = this.MiddleName.Text ?? "",
                    LastName = this.LastName.Text ?? "",
                    StudentVisited = student,
                    Town = Helper.GetTownByName(townName)

                };
                Helper.AddGuest(guest);
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