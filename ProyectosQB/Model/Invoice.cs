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
        private string refnumber;
        private string address;
        private string memo;
        private DateTime date;
        private string deposit;
       
        public Invoice()
        {
            tax = 0f;
            refnumber = "";
            address = "";
            memo = "";
          
        }

        public double Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public string RefNumber
        {
            get { return refnumber; }
            set { refnumber = value; }
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

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Deposit
        {
            get { return deposit; }
            set { deposit = value; }

        }
       
    }
}
