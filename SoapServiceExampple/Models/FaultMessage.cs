using System.Runtime.Serialization;

namespace SoapServiceExampple.Models
{
    [DataContract]
    public class FaultMessage
    {
        [DataMember]
        public string Message { get; set; } = null!;
    }
}
