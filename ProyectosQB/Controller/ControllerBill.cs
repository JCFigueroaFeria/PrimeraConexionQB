using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ControllerBill
    {
        private DABill daBills;
        public ControllerBill()
        {
            daBills = new DABill();
        }

        public List<Bill> cargarDatosBill(DateTime fechaInicio, DateTime fechaTermino)
        {
            return daBills.getListBillDate(fechaInicio, fechaTermino);
        }

        public Bill cargarBillReferent(string numReferent)
        {
            return daBills.getElement(numReferent);
        }


    }
}

