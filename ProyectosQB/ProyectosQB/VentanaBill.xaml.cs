using Business;
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
    /// <summary>
    /// Lógica de interacción para VentanaBill.xaml
    /// </summary>
    public partial class VentanaBill : MetroWindow
    {
        ControllerBill cargarBill;
        Discount discount;
        public VentanaBill()
        {
            InitializeComponent();
            cargarBill = new ControllerBill();
            discount = new Discount();
            dpFechaInicio.SelectedDate = dpFechaTermino.SelectedDate = DateTime.Now;
        }

        private void btntableload_Click(object sender, RoutedEventArgs e)
        {
            cargarTablaPorFechas();
        }

        private void btnBuscarReferent_Click(object sender, RoutedEventArgs e)
        {
            cargarTablaPorReferencia();
        }

        public void cargarTablaPorFechas()
        {

            List<Bill> bills = cargarBill.cargarDatosBill((DateTime)dpFechaInicio.SelectedDate, (DateTime)dpFechaTermino.SelectedDate);
            aplicarDescuento(bills);
        }


        public void cargarTablaPorReferencia()
        {
            List<Bill> listBill = new List<Bill>();
            Bill rBill = cargarBill.cargarBillReferent(txtRefNumber.Text);
            listBill.Add(rBill);
            aplicarDescuento(listBill);
        }
        private void aplicarDescuento(List<Bill> bills)
        {
            foreach (var bill in bills)
            {
                discount.aplicarDecuento(bill);
            }
            this.tblReceive.ItemsSource = bills;
        }
    }
}
