using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EasyTools.Framework.Application
{
    [DataContract]
    public class BusinessException
    {
        [DataMember]
        public String Code { get; private set; }

        [DataMember]
        public String AppMessage { get; private set; }

        private List<String> appMessageDetails;

        [DataMember]
        public List<String> AppMessageDetails
        {
            get
            {
                if (appMessageDetails == null)
                    appMessageDetails = new List<String>();
                return appMessageDetails;
            }
            private set
            {
                appMessageDetails = value;
            }
        }

        public BusinessException()
        {
        }
        public BusinessException(String message)
        {
            AppMessage = message;
        }
        public BusinessException(String message, String detail)
        {
            AppMessage = message;
            AppMessageDetails.Add(detail);
        }

        public BusinessException(Exception e)
        {
            if (e.GetType() == typeof(FaultException<BusinessException>))
            {
                AppMessage = ((FaultException<BusinessException>)e).Detail.AppMessage;
                AppMessageDetails = ((FaultException<BusinessException>)e).Detail.AppMessageDetails;
            }
            else
            {
                AppMessage = e.Message;
                e = e.InnerException;
                while (e != null)
                {
                    AppMessageDetails.Add(e.Message);
                    e = e.InnerException;
                }
            }
        }

        public BusinessException(BusinessException e)
        {
            AppMessage = e.AppMessage;
            AppMessageDetails = e.AppMessageDetails;
        }

        public FaultException<BusinessException> GetFaultException()
        {
            List<FaultReasonText> allMessages = new List<FaultReasonText>();
            allMessages.Add(new FaultReasonText(AppMessage));
            if (AppMessageDetails != null && AppMessageDetails.Count > 0)
                foreach (string item in AppMessageDetails)
                {
                    allMessages.Add(new FaultReasonText(item));
                }
            return new FaultException<BusinessException>(this, new FaultReason(allMessages));
        }

        public BusinessException(FaultException e)
        {
            if (e != null && e.Reason.Translations != null && e.Reason.Translations.Count > 0)
            {
                for (int i = 0; i < e.Reason.Translations.Count; i++)
                {
                    if (i == 0)
                        AppMessage = e.Reason.Translations[i].Text;
                    else
                        AppMessageDetails.Add(e.Reason.Translations[i].Text);
                }
            }

        }

        public string GetExceptionMessage()
        {
            string message = AppMessage + " \n";
            if (AppMessageDetails != null && AppMessageDetails.Count > 0)
                foreach (var item in AppMessageDetails)
                {
                    message += item + " \n";
                }
            return message;
        }
    }
}