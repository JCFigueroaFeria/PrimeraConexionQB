
using Controller;
using DataAccess;
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
        List<Bill> ultimaLista;

        public VentanaBill()
        {
            InitializeComponent();
            cargarBill = new ControllerBill();
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
            this.tblReceive.ItemsSource = ultimaLista;
            ultimaLista = bills;
        }


        public void cargarTablaPorReferencia()
        {
            List<Bill> listBill = new List<Bill>();
            Bill rBill = cargarBill.cargarBillReferent(this.txtRefNumber.Text);
            listBill.Add(rBill);
            tblReceive.ItemsSource = ultimaLista;
            ultimaLista = listBill;
        }
        public void busquedaPorNombre()
        {

            List<Bill> billName = new List<Bill>();
            for (int i = 0; i < ultimaLista.Count; i++)
            {

                if (ultimaLista[i].Vendor.Equals(txtRefNumber.Text))
                {
                    billName.Add(ultimaLista[i]);
                }
                this.tblReceive.ItemsSource = billName;
            }


        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {

            exportarDatosExcel();
        }


        public void exportarDatosExcel()
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exportar Contenido de la tabla";

            //Se le manda a la cabezera los datos de las tabla
            worksheet.Cells[1, 1] = "Vendor";
            worksheet.Cells[1, 2] = "Date";
            worksheet.Cells[1, 3] = "Ref-Number";
            worksheet.Cells[1, 4] = "Amount";

            
            for (int i = 0; i < tblReceive.Items.Count; i++)
            {

                Bill bills = (Bill)tblReceive.Items.GetItemAt(i);
                worksheet.Cells[i + 3, 1] = bills.Vendor;
                worksheet.Cells[i + 3, 2] = bills.Date;
                worksheet.Cells[i + 3, 3] = bills.RefNumber;
                worksheet.Cells[i + 3, 4] = bills.Amount;

            }


        }
    }
}
