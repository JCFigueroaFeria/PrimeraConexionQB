using QBFC13Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SessionQB
    {
        private bool connectionOpen;
        private bool sessionBegun;
        private QBSessionManager sessionManager;
        private IMsgSetRequest requestMsgSet;
        public SessionQB()
        {
            connectionOpen = false;
            sessionBegun = false;
            sessionManager = new QBSessionManager();

        }

        public void open()
        {
            requestMsgSet = sessionManager.CreateMsgSetRequest("US", 8, 0);
            requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

            sessionManager.OpenConnection("@", "QuickBooks Integration Demo");
            connectionOpen = true;
            sessionManager.BeginSession("", ENOpenMode.omDontCare);
            sessionBegun = true;
        }
        public void close()
        {
            if (sessionBegun)
            {
                sessionManager.EndSession();
            }
            if (connectionOpen)
            {
                sessionManager.CloseConnection();
            }
        }
        public IMsgSetRequest getRequest()
        {
            return requestMsgSet;
        }
        public QBSessionManager getSession()
        {
            return sessionManager;
        }
    }
}
