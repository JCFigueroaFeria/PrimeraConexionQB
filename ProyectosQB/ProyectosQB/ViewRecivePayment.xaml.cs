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
            ReceivePayment rPayment = cargar2.cardarReceivePayment(txtRefNumber.Text);
            List<ReceivePayment> lista = new List<ReceivePayment>();
            lista.Add(rPayment);
            this.tblReceive.ItemsSource = lista;
        }

        private void btnCargarTabla_Click(object sender, RoutedEventArgs e)
        {
            cargarDatosDePagos();
        }




        public void exportarDatosExcel()
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Receive Payment";

            //Se le manda a la cabezera los datos de las tabla
            worksheet.Cells[1, 1] = "Date";
            worksheet.Cells[1, 2] = "Num-Referent";
            worksheet.Cells[1, 3] = "Receive From";
            worksheet.Cells[1, 4] = "Amount";


            for (int i = 0; i < tblReceive.Items.Count; i++)
            {

                ReceivePayment rpaymentcheck = (ReceivePayment)tblReceive.Items.GetItemAt(i);
                worksheet.Cells[i + 3, 1] = rpaymentcheck.Date;
                worksheet.Cells[i + 3, 2] = rpaymentcheck.RefNumber;
                worksheet.Cells[i + 3, 3] = rpaymentcheck.Customer;
                worksheet.Cells[i + 3, 4] = rpaymentcheck.Amount;

            }
            
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            exportarDatosExcel();
        }


    }
}
