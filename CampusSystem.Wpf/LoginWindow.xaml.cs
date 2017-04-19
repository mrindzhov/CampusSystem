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
using System.Windows.Shapes;
using CampusSystem.Data;
using CampusSystem.Data.Utility;
using CampusSystem.Models;

namespace CampusSystem.Wpf
{
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
            if (Campus.Text != string.Empty || Password.Password != string.Empty || Password.Password.Length <= 3)
            {
                //var users = dbe.users.FirstOrDefault(a => a.username.Equals(t1.Text));
                Campus campus = Helper.GetCampus(Campus.Text.ToString());
                if (campus != null)
                {
                    if (campus.Password.Equals(Password.Password.ToString()))
                    {
                        AuthenticationManager.Login(campus);
                        MainWindow mw = new MainWindow();
                        mw.Owner = this;
                        this.Hide();
                        mw.ShowDialog();
                        //WPFListview l1 = new WPFListview();
                        //l1.ShowDialog();
                        //==> GO TO MAINWINDOW
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
        }
    }
}
