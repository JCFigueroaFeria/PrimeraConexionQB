using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bill
    {

       private string vendor;
       private DateTime date;
       private string refnumber;
       private double amount;
       private float discount;
       private bool facturados;
      
        public Bill() {

            vendor = "";
            refnumber = "";
            amount = 0d;
            discount = 0f;
            facturados = false;

        }


        public string Vendor { get { return vendor; } set { vendor = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string RefNumber { get { return refnumber; } set { refnumber = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public float Discount { get { return discount; } set { discount = value; } }
        public bool Facturados { get { return facturados; } set { facturados = value; } }

        
    }
}
