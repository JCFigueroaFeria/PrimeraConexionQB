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
        public BillPayment()
        {
            refNumber = "";
            memo = "";
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
    }
}
