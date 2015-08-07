using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Invoice
    {
        /*Nota: Attibutos de la clase invoice y la interfaz invoice*/
        private double tax;
        private string numInvoice;
        private string address;
        private string memo;
        public Invoice()
        {
            tax = 0f;
            numInvoice = "";
            address = "";
            memo = "";
        }

        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public string NumInvoice
        {
            get { return numInvoice; }
            set { numInvoice = value; }
        }

        public string Address
        {
            get { return address; ; }
            set { address = value; }
        }

        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }
}
