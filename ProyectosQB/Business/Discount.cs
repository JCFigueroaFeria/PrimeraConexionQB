using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class Discount
    {
        private float descuento;

        public Discount()
        {

            descuento = .17f;
        }
        public void aplicarDecuento(Bill billDiscount)
        {
            billDiscount.Amount = (float)(billDiscount.Amount * descuento);
        }
    }
}