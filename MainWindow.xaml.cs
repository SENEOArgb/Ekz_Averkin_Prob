using Ekzam_Averkin_Hotel.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Ekzam_Averkin_Hotel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Client> Clients;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clients = new List<Client>(App.DbContext.Client
                .Include(c => c.Card)
                .Include(c => c.ContractClientRoom)
                    .ThenInclude(ccr => ccr.HotelRoom)
                .ToList());
            dgClients.ItemsSource = Clients;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (dgClients.SelectedItem is Client client)
            {
                var room = App.DbContext.ContractClientRoom
                    .Include(r => r.Client)
                    .Include(r => r.HotelRoom)
                    .FirstOrDefault(r => r.ClientId == client.ClientId && r.HotelRoom.StatusRoomId == 1);
                room.HotelRoom.StatusRoomId = 2;

                MessageBox.Show("Номер освобожден!");
            }
        }
    }
}
