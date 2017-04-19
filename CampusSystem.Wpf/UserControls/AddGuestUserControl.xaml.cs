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
                var fullNameArgs = this.FullName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var townName = this.Town.Text.ToString();
                var student = Helper.GetStudentByRoomAndName(
                        Rooms.SelectedItem.ToString(), Student.SelectedItem.ToString());

                Guest guest = new Guest
                {
                    FirstName = fullNameArgs[0] ?? "",
                    MiddleName = fullNameArgs[1] ?? "",
                    LastName = fullNameArgs[2] ?? "",
                    StudentVisited = student,
                    Town = Helper.GetTownByName(townName)

                };
                //Initializer.AddGuest(guest);
                MessageBox.Show($"Added guest {fullNameArgs} to {student.FullName}", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Content = new AddGuestUserControl();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}","Cannot add empty guest",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
