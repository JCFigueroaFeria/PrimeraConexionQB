using Controller;
using MahApps.Metro.Controls;
using Model;
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
     public partial class ViewRecivePayment : MetroWindow
    {
        public ViewRecivePayment()
        {
            InitializeComponent();
            dpFechaInicio.SelectedDate = dpFechaTermino.SelectedDate = DateTime.Now;
        }
        private void cargarDatosDePagos()
        {
            ControllerReceivePayment cargarReceive = new ControllerReceivePayment();
            this.tblReceive.ItemsSource = cargarReceive.cargarReceivePayments((DateTime)dpFechaInicio.SelectedDate, (DateTime)dpFechaTermino.SelectedDate);
        }

    

        private void tnBuscar2_Click(object sender, RoutedEventArgs e)
        {
            ControllerReceivePayment cargar2 = new ControllerReceivePayment();
            ReceivePayment rPayment = cargar2.cardarReceivePayment(this.txtRefNumber.Text);
            List<ReceivePayment> lista = new List<ReceivePayment>();
            lista.Add(rPayment);
            this.tblReceive.ItemsSource = lista;
        }

        private void btnCargarTabla_Click(object sender, RoutedEventArgs e)
        {
            cargarDatosDePagos();
        }
    }
}
