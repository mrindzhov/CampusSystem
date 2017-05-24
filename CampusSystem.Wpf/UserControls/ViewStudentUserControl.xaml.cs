namespace CampusSystem.Wpf.UserControls
{
    using System.Windows;
    using System.Windows.Controls;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;

    /// <summary>
    /// Interaction logic for StudentUserControl.xaml
    /// </summary>
    public partial class ViewStudentUserControl : UserControl
    {
        //public override void BeginInit()
        //{
        //    base.BeginInit();
        //}
        public ViewStudentUserControl()
        {
            InitializeComponent();
            //this.DataContext = StudentService.GetStudents();
            LoadData();
            //var roomn = DataContext as List<Student>;
            //roomn.ForEach(r => r.Room.Number);
        }

        private void LoadData()
        {
            Data.ItemsSource = StudentService.GetStudentsByCampus(AuthenticationManager.GetCurrentCampus().Id);
        }

        private void ButtonPayObligations(object sender, System.Windows.RoutedEventArgs e)
        {
            var student = Data.SelectedItem as Student;
            MessageBoxResult res = MessageBox.Show($"Pay debit for {student.FullName}?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                StudentService.PayObligationsById(student.Id);
                LoadData();
            }

        }
    }
}
