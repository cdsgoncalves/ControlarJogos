using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Util.Exceptions
{
    [Serializable]
    public class S2ItException : Exception
    {
        public S2ItException() { }
        public S2ItException(string mensagem) : base(mensagem) { }
        public S2ItException(string mensagem, Exception innerException) : base(mensagem, innerException) { }


        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected S2ItException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}