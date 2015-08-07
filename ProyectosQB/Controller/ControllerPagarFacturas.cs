using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ControllerPagarFacturas
    {
        private DABillPayments daBillPayments;
        public ControllerPagarFacturas()
        {
            daBillPayments = new DABillPayments();
        }

        public List<BillPayment> cargarFacturasPendientesDePagoPorMes(DateTime fechaInicio, DateTime fechaTermino)
        {
            return daBillPayments.getList(fechaInicio, fechaTermino);
        }
    }
}
