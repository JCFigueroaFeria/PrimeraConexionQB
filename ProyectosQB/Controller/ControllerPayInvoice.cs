using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ControllerPayInvoice
    {
        private DAInvoice daInvoice;
        public ControllerPayInvoice()
        {

            daInvoice = new DAInvoice();
        }

        public List<Invoice> cargarPagosInvoice(DateTime fechaInicio, DateTime fechaTermino)
        {
            return daInvoice.getListInvoiceDate(fechaInicio, fechaTermino);
        }
    }
}
