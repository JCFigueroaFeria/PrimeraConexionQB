using Model;
using QBFC13Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DABill
    {

        private SessionQB session;
        private IMsgSetRequest request;
        private QBSessionManager sessionManager;
        private IBillQuery billQuery;

        public DABill()
        {
            session = new SessionQB();
            billQuery = null;
        }


        public List<Bill> getList()
        {
            List<Bill> completeList = new List<Bill>();
            prepareQuery();
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;
        }
        public List<Bill> getListBillDate(DateTime fechaInicio, DateTime fechaTermino)
        {
            List<Bill> completeList = new List<Bill>();
            prepareQuery();
            setFilter(fechaInicio, fechaTermino);
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;
        }

        public Bill getElement(string refNumber)
        {
            List<Bill> completeList = new List<Bill>();
            prepareQuery();
            setFilter(refNumber);
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            if (completeList.Count >= 1)
                return completeList[0];

            return null;
        }

        private void setFilter(string refNumber)
        {
            billQuery.ORBillQuery.BillFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
            billQuery.ORBillQuery.BillFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(refNumber);
        }
        private void setFilter(DateTime fechaInicio, DateTime fechaTermino)
        {
            billQuery.ORBillQuery.BillFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fechaInicio);
            billQuery.ORBillQuery.BillFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(fechaTermino);
        }



        private void prepareQuery()
        {
            session.open();
            request = session.getRequest();
            sessionManager = session.getSession();
            billQuery = request.AppendBillQueryRq();
            billQuery.IncludeLineItems.SetValue(true);
        }
        private IResponse executeQuery()
        {
            IMsgSetResponse respuestaMsg = sessionManager.DoRequests(request);
            IResponse respuesta = respuestaMsg.ResponseList.GetAt(0);
            session.close();
            return respuesta;
        }
        private void readData(List<Bill> completeList, IResponse respuesta)
        {
            if (respuesta.StatusCode == 0)
            {
                IBillRetList billCheckList = (IBillRetList)respuesta.Detail;

                for (int i = 0; i < billCheckList.Count; i++)
                {
                    Bill bill = readBill(billCheckList.GetAt(i));
                    completeList.Add(bill);
                }
            }
        }

        private Bill readBill(IBillRet billCheckRet)
        {
            Bill bill = new Bill();
            bill.Vendor = billCheckRet.VendorRef.FullName.GetValue();
            bill.RefNumber = billCheckRet.RefNumber.GetValue();
            bill.Date = billCheckRet.TxnDate.GetValue();
            bill.Amount = billCheckRet.AmountDue.GetValue();
            bill.Facturados = facturadoAzar();
            return bill;
        }

        private bool facturadoAzar()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 100);
            return ((number > 50) ? true : false);
        }
    }
}

