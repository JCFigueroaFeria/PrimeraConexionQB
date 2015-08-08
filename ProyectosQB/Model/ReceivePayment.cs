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
        /*Nota: Aqui se agregara los datos a pedir de customer Payment*/

        private string refNumber;
        private string deposit;
        private double amount;
        private string memo;
        private DateTime date;
        public ReceivePayment()
        {
            refNumber = "";
            deposit = "";
            amount = 0d;
            memo = "";
            
        }
        public string RefNumber { get {return refNumber ;} set {refNumber=value ;} }
        public string Deposit { get { return deposit; } set { deposit = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public string Memo { get { return memo; } set { memo = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
    }
}
