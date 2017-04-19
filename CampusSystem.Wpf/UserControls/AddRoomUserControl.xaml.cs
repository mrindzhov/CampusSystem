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
    /// Interaction logic for AddRoomUserControl.xaml
    /// </summary>
    public partial class AddRoomUserControl : UserControl
    {
        public AddRoomUserControl()
        {
            InitializeComponent();
        }

        private void AddRoom(object sender, RoutedEventArgs e)
        {
            var roomNumber = Number.Text;
            if (roomNumber.Length < 3)
            {
                MessageBox.Show($"You need to insert room number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    var campus = AuthenticationManager.GetCurrentCampus();
                    Room room = new Room
                    {
                        Number = roomNumber,
                        CampusId = campus.Id
                    };
                    Helper.AddRoomToCampus(room);
                    MessageBox.Show($"Added room {room.Number} to {campus.Number} campus", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    new MainWindow().RoomsList.ItemsSource = Helper.GetRoomsByCampus(campus).ToList();
                    this.Content = new AddRoomUserControl();

                }
                catch (Exception)
                {
                    MessageBox.Show($"You need to insert room number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
