﻿namespace CampusSystem.Wpf.UserControls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using CampusSystem.Data.Utility;
    using CampusSystem.Data.Utility.Services;
    using CampusSystem.Models;

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
                    RoomService.AddRoomToCampus(room);
                    MessageBox.Show($"Added room {room.Number} to {campus.Number} campus", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    //mw.Owner = this;
                    this.Content = new AddRoomUserControl();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
