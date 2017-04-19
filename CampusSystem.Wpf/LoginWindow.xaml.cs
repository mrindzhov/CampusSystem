namespace CampusSystem.Wpf
{
    using System;
    using System.Windows;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            //DatabaseEntities dbe = new DatabaseEntities();
            if (Campus.Text != string.Empty && Password.Password != string.Empty && Password.Password.Length >= 3)
            {
                //var users = dbe.users.FirstOrDefault(a => a.username.Equals(t1.Text));
                try
                {
                    Campus campus = CampusService.GetCampus(Campus.Text.ToString());
                    if (campus != null)
                    {
                        if (campus.Password.Equals(Password.Password.ToString()))
                        {
                            AuthenticationManager.Login(campus);
                            MainWindow mw = new MainWindow();
                            //mw.Owner = this;
                            this.Close();
                            mw.ShowDialog();
                        }
                        else
                        {
                            MessageBoxResult msgr = MessageBox.Show("Invalid password or campus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBoxResult msgr = MessageBox.Show("Invalid password or campus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBoxResult msgr = MessageBox.Show("Invalid password or campus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBoxResult msgr = MessageBox.Show("Invalid password or campus!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
