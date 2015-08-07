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
        public ReceivePayment()
        {
            refNumber = "";
            deposit = "";
            amount = 0d;
            memo = "";  
        }
        public string  RefNumber { get; set; }
        public string Deposit { get; set; }
        public double Amount { get; set; }
        public string Memo { get; set; }
        public string date { get; set; }
    }
}
