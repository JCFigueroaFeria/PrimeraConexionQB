using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReceivePayment
    {
       
        private string refNumber;
        private string deposit;
        private double amount;
        private string customer;
        private DateTime date;
        public ReceivePayment()
        {
            refNumber = "";
            deposit = "";
            amount = 0d;
            customer = "";
            
        }
        public string RefNumber { get {return refNumber ;} set {refNumber=value ;} }
        public string Deposit { get { return deposit; } set { deposit = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public string Customer { get { return customer; } set { customer = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
    }
}
