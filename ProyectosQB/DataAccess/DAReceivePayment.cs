using Model;
using QBFC13Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAReceivePayment
    {

        private SessionQB session;
        private IMsgSetRequest request;
        private QBSessionManager sessionManager;
        private IReceivePaymentQuery receivePaymentQuery;
        public DAReceivePayment() {
            session = new SessionQB();
            receivePaymentQuery = null;
        }


        public List<ReceivePayment> getList()
        {
            List<ReceivePayment> completeList = new List<ReceivePayment>();
            prepareQuery();
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;
        }

        public List<ReceivePayment> getListReceivePayment(DateTime fechaInicio, DateTime fechaTermino)
        {
            List<ReceivePayment> completeList = new List<ReceivePayment>();
            prepareQuery();
            setFilter(fechaInicio, fechaTermino);
            IResponse respuesta = executeQuery();
            readData(completeList, respuesta);
            return completeList;
        }

        public ReceivePayment getElement(string refNumber)
        {
            List<ReceivePayment> completeList = new List<ReceivePayment>();
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
            
            receivePaymentQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
            receivePaymentQuery.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(refNumber);
        }
        private void setFilter(DateTime fechaInicio, DateTime fechaTermino)
        {
            receivePaymentQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(fechaInicio);
            receivePaymentQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(fechaTermino);
        }


        private void prepareQuery()
        {
            session.open();
            request = session.getRequest();
            sessionManager = session.getSession();
            receivePaymentQuery = request.AppendReceivePaymentQueryRq();
            receivePaymentQuery.IncludeLineItems.SetValue(true);
        }
        private IResponse executeQuery()
        {
            IMsgSetResponse respuestaMsg = sessionManager.DoRequests(request);
            IResponse respuesta = respuestaMsg.ResponseList.GetAt(0);
            session.close();
            return respuesta;
        }
        private void readData(List<ReceivePayment> completeList, IResponse respuesta)
        {
            if (respuesta.StatusCode == 0)
            {
                IReceivePaymentRetList paymentCheckList = (IReceivePaymentRetList)respuesta.Detail;
                for (int i = 0; i < paymentCheckList.Count; i++)
                {
                    ReceivePayment receivePayment = readReceivePayment(paymentCheckList.GetAt(i));
                    completeList.Add(receivePayment);
                }
            }
        }

        private ReceivePayment readReceivePayment( IReceivePaymentRet receiveCheckRet)
        { 
            ReceivePayment receivePayment = new ReceivePayment();
            receivePayment.Date = receiveCheckRet.TxnDate.GetValue();
            receivePayment.RefNumber = receiveCheckRet.RefNumber.GetValue();
            receivePayment.Amount = receiveCheckRet.TotalAmount.GetValue();
            receivePayment.Customer = receiveCheckRet.CustomerRef.FullName.GetValue();
            return receivePayment;
        }


    }
}
