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
    /// Interaction logic for AddStudentUserControl.xaml
    /// </summary>
    public partial class AddStudentUserControl : UserControl
    {
        private Campus campus = AuthenticationManager.GetCurrentCampus();
        public AddStudentUserControl()
        {
            InitializeComponent();
            this.Rooms.ItemsSource = RoomService.GetRoomsByCampus(campus).Select(r => r.Number);
            this.University.ItemsSource = GeneralService.GetUniversities().Select(u => u.Name);
            this.Town.ItemsSource = TownService.GetTowns().Select(t => t.Name);
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
                    Room room = RoomService.getRoomInCampusByNumber(this.Rooms.SelectedItem.ToString(), campus.Id);
                    University university = GeneralService.GetUniversityByName(University.SelectedItem.ToString());
                    Town town = TownService.GetTownByName(this.Town.SelectedItem.ToString());
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
                    StudentService.AddStudent(student);
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
