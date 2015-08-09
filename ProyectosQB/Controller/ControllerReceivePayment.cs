using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ControllerReceivePayment
    {

        private DAReceivePayment daReceive;
        public ControllerReceivePayment() {
            daReceive = new DAReceivePayment();
        }

        public List<ReceivePayment> cargarReceivePayment(DateTime fechaInicio, DateTime fechaTermino)
        {
            return daReceive.getListReceivePayment(fechaInicio, fechaTermino);
        }
       

        
    }
}
