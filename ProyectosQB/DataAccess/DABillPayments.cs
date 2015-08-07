using Model;
using QBFC13Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DABillPayments
    {
        private SessionQB session;
        private IMsgSetRequest request;
        private QBSessionManager sessionManager;
        private IBillPaymentCheckQuery paymentQuery;
       
        public DABillPayments()
        {
            session = new SessionQB();
            paymentQuery = null;
        }

        public List<BillPayment> getList()
        {
            List<BillPayment> completeList = new List<BillPayment>();
            prepareQuery();
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;
        }
        public List<BillPayment> getList(DateTime fechaInicio, DateTime fechaTermino)
        {
            List<BillPayment> completeList = new List<BillPayment>();
            prepareQuery();
            setFilter(fechaInicio, fechaTermino);
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;
        }

        public BillPayment getElement(string refNumber)
        {
            List<BillPayment> completeList = new List<BillPayment>();
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
            paymentQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
            paymentQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(refNumber);
        }
        private void setFilter(DateTime fechaInicio, DateTime fechaTermino)
        {
            paymentQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fechaInicio);
            paymentQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(fechaTermino);
        }



        private void prepareQuery()
        {
            session.open();
            request = session.getRequest();
            sessionManager = session.getSession();
            paymentQuery = request.AppendBillPaymentCheckQueryRq();
            paymentQuery.IncludeLineItems.SetValue(true);
        }
        private IResponse executeQuery()
        {
            IMsgSetResponse respuestaMsg = sessionManager.DoRequests(request);
            IResponse respuesta = respuestaMsg.ResponseList.GetAt(0);
            session.close();
            return respuesta;
        }
        private void readData(List<BillPayment> completeList, IResponse respuesta)
        {
            if (respuesta.StatusCode == 0)
            {
                IBillPaymentCheckRetList paymentCheckList = (IBillPaymentCheckRetList)respuesta.Detail;
                for (int i = 0; i < paymentCheckList.Count; i++)
                {
                    BillPayment billPayment = readBillPayment(paymentCheckList.GetAt(i));
                    completeList.Add(billPayment);
                }
            }
        }

        private BillPayment readBillPayment(IBillPaymentCheckRet paymentCheckRet)
        {
            BillPayment billPayment = new BillPayment();
            billPayment.RefNumber = paymentCheckRet.RefNumber.GetValue();
            billPayment.Memo = paymentCheckRet.Memo.GetValue();
            return billPayment;
        }
    }
}
