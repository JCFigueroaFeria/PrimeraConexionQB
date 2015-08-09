using Controller;
using MahApps.Metro.Controls;
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

namespace ProyectosQB
{
    /// <summary>
    /// Lógica de interacción para ViewRecivePayment.xaml
    /// </summary>
    public partial class ViewRecivePayment : MetroWindow

    {
        public ViewRecivePayment()
        {
            InitializeComponent();
            dpFechaInicio.SelectedDate = dpFechaTermino.SelectedDate = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            cargarDatosDePagos();
        }

        private void cargarDatosDePagos()
        {
            ControllerReceivePayment cargarReceive = new ControllerReceivePayment();
            this.tblReceive.ItemsSource = cargarReceive.cargarReceivePayment((DateTime)dpFechaInicio.SelectedDate, (DateTime)dpFechaTermino.SelectedDate);
        }
    }
}
