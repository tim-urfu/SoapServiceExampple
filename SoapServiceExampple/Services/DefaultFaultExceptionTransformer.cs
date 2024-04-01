using SoapCore.Extensibility;
using System.ServiceModel.Channels;
using System.Xml;

namespace SoapServiceExampple.Services
{
    public class DefaultFaultExceptionTransformer : IFaultExceptionTransformer
    {
        public Message ProvideFault(Exception exception, MessageVersion messageVersion, Message requestMessage, XmlNamespaceManager xmlNamespaceManager)
        {
            return Message.CreateMessage(messageVersion, "Exception", exception.Message.ToString());
        }
    }
}
