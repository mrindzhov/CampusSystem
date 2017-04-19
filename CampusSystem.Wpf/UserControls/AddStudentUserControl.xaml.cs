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
using CampusSystem.Models;

namespace CampusSystem.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for AddStudentUserControl.xaml
    /// </summary>
    public partial class AddStudentUserControl : UserControl
    {
        private Campus campus = AuthenticationManager.GetCurrentCampus();
        public AddStudentUserControl()
        {
            InitializeComponent();
            this.Rooms.ItemsSource = Helper.GetRoomsByCampus(campus).Select(r => r.Number);
            this.University.ItemsSource = Helper.GetUniversities().Select(u => u.Name);
            this.Town.ItemsSource = Helper.GetTowns().Select(t => t.Name);
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {

            if (this.FirstName.Text.Length < 3 || this.MiddleName.Text.Length < 3 ||
                this.LastName.Text.Length < 3 || decimal.Parse(this.Obligations.Text) < 0)
            {
                MessageBox.Show($"No empty fields allowed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Room room = Helper.getRoomInCampusByNumber(this.Rooms.SelectedItem.ToString(), campus.Id);
                    University university = Helper.GetUniversityByName(University.SelectedItem.ToString());
                    Town town = Helper.GetTownByName(this.Town.SelectedItem.ToString());
                    Student student = new Student
                    {
                        FirstName = this.FirstName.Text,
                        MiddleName = this.MiddleName.Text,
                        LastName = this.LastName.Text,
                        CampusId = campus.Id,
                        IsActive = true,
                        Obligations = decimal.Parse(Obligations.Text),
                        UniversityId = university.Id,
                        RoomId = room.Id,
                        TownId = town.Id
                    };
                    Helper.AddStudent(student);
                    MessageBox.Show("Added student successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Content = new AddStudentUserControl();
                }
                catch (Exception)
                {
                    MessageBox.Show($"Invalid data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
