using SoapCore;
using SoapCore.Extensibility;
using SoapServiceExampple.Models;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace SoapServiceExampple.Services
{
    public class DefaultFaultExceptionTransformer : IFaultExceptionTransformer
    {
        public Message ProvideFault(Exception exception, MessageVersion messageVersion, Message requestMessage, XmlNamespaceManager xmlNamespaceManager)
        {
            var fault = new FaultMessage
            {
                Message = exception.Message
            };

            var faultException = new FaultException<FaultMessage>(fault, new FaultReason(exception.Message), new FaultCode(nameof(FaultMessage)), nameof(FaultMessage));

            var messageFault = faultException.CreateMessageFault();
            var bodyWriter = new MessageFaultBodyWriter(messageFault, messageVersion);
            var faultMessage = Message.CreateMessage(messageVersion, null, bodyWriter);

            faultMessage.Properties.Add(HttpResponseMessageProperty.Name, new HttpResponseMessageProperty { StatusCode = HttpStatusCode.OK, StatusDescription = "Exception description" });

            return faultMessage;
        }
    }
}
