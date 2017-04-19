namespace CampusSystem.Wpf.UserControls
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;

    /// <summary>
    /// Interaction logic for AddCampusUserControl.xaml
    /// </summary>
    public partial class AddCampusUserControl : UserControl
    {
        public AddCampusUserControl()
        {
            InitializeComponent();
            University.ItemsSource = GeneralService.GetUniversities().Select(u => u.Name);
            Password.BorderBrush = Brushes.Black;
            RepeatPassword.BorderBrush = Brushes.Black;
        }

        private void AddCampus(object sender, RoutedEventArgs e)
        {
            if (this.Number.Text.Length < 1)
            {
                MessageBox.Show($"No empty fields allowed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Password.Password.Equals(RepeatPassword.Password)
                && this.Number.Text != null && this.University.SelectedItem != null)
            {
                try
                {
                    var campusNum = this.Number.Text.ToString();
                    University university = GeneralService.GetUniversityByName(University.SelectedItem.ToString());

                    Campus camp = new Campus
                    {
                        Number = campusNum,
                        UniversityId = university.Id,
                        Password = Password.Password
                    };
                    CampusService.AddCampus(camp);
                    MessageBox.Show($"Added campus {campusNum} to {university.Name}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Content = new AddCampusUserControl();

                }
                catch (Exception)
                {
                    MessageBox.Show($"Invalid data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Password.BorderBrush = Brushes.Red;
                RepeatPassword.BorderBrush = Brushes.Red;
            }
        }

    }
}
