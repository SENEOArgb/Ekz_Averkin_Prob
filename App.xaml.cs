using Ekzam_Averkin_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ekzam_Averkin_Hotel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Ekzam_Averkin_HotelContext DbContext { get; private set; }

        public App()
        {
            InitializeComponent();
            DbContext = new Ekzam_Averkin_HotelContext();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DbContext.Dispose();
            base.OnExit(e);
        }
    }
}
