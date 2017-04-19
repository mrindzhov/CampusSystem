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

namespace CampusSystem.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for RoomUserControl.xaml
    /// </summary>
    public partial class ViewRoomUserControl : UserControl
    {
        public ViewRoomUserControl()
        {
            InitializeComponent();
            //    RoomNumber.Text = roomNumber;
            //    StudentsCount.Text = Helper.GetStudentsInRoom(roomNumber).ToString();
            //    TotalTakings.Text = Helper.GetTotalObligationsByRoom(roomNumber);
        }
    }
}
