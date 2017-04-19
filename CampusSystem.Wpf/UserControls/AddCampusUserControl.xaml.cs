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
    /// Interaction logic for AddCampusUserControl.xaml
    /// </summary>
    public partial class AddCampusUserControl : UserControl
    {
        public AddCampusUserControl()
        {
            InitializeComponent();
            University.ItemsSource = Helper.GetUniversities().Select(u => u.Name);
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
                    University university = Helper.GetUniversityByName(University.SelectedItem.ToString());

                    Campus camp = new Campus
                    {
                        Number = campusNum,
                        UniversityId = university.Id,
                        Password = Password.Password
                    };
                    Helper.AddCampus(camp);
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
