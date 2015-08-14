
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
            aplicarDescuento(bills);
            ultimaLista = bills;
        }


        public void cargarTablaPorReferencia()
        {
            List<Bill> listBill = new List<Bill>();
            Bill rBill = cargarBill.cargarBillReferent(txtRefNumber.Text);
            listBill.Add(rBill);
            ultimaLista = listBill;
        }
       /* private void aplicarDescuento(List<Bill> bills)
        {
            foreach (var bill in bills)
            {
                discount.aplicarDecuento(bill);
            }
            this.tblReceive.ItemsSource = bills;
        }*/

        public void busquedaPorNombre() {

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
           

        }


        public void exportarDatosExcel()
        {
            //Instancia del libreria offcice
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exportar Contenido de la tabla";

            // Agregando color a una celda
            Microsoft.Office.Interop.Excel.Range cambios = worksheet.get_Range("A1:B1");
            cambios.EntireRow.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            cambios.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
            cambios.EntireRow.Font.Size = 14;
            cambios.EntireRow.AutoFit();

            //Se le manda a la cabezera los datos de las tabla
            worksheet.Cells[1, 1] = "Vendor";
            worksheet.Cells[1, 2] = "DAte";
            worksheet.Cells[1, 3] = "Ref-Number";
            worksheet.Cells[1, 4] = "Amount";




            // Almacenar cada valor de la fila y la columna de sobresalir hoja
            for (int i = 0; i < tblReceive.Items.Count; i++)
            {

                Bill bills = (Bill)tblReceive.Items.GetItemAt(i);
                worksheet.Cells[i + 3, 1] = bills.Vendor;
                worksheet.Cells[i + 3, 2] = bills.Date;
                worksheet.Cells[i + 3, 3] = bills.RefNumber;
                worksheet.Cells[i + 3, 4] = bills.Amount;

            }


            // Guardar la aplicación
            //workbook.SaveAs("@C:/Users/JulioCesar/OneDrive/Documentos/output2.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


        }
    }
}
