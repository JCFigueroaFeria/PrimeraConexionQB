using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BillPayment
    {
        private string refNumber;
        private string memo;
        private DateTime date;
        private double endingBalance;
        private string bank;
        public BillPayment()
        {
            refNumber = "";
            memo = "";
            endingBalance = 0d;
        }

        public string RefNumber
        {
            get { return refNumber; }
            set { refNumber = value; }
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

        public double Balace
        {
            get { return endingBalance; }
            set { endingBalance = value; }
        }

        public string  Bank
        {
            get { return bank; }
            set { bank = value; }
        }

    }
}
