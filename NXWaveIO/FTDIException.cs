using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXWaveIO
{
    [Serializable]
    public class FTDIException : Exception
    {
        public FTDIException(FTStatus status) : base("FTDI Driver Returned Status:" + status + "Type:" + Enum.GetName(typeof(FTStatus), status))
        {

        }
        public FTDIException() : base()
        {

        }
        public FTDIException(string message) : base(message)
        {

        }
        public FTDIException(FTStatus status, string message) : base("FTDI Driver Returned Status:" + status + "Type:" + Enum.GetName(typeof(FTStatus), status) + " Message: " + message)
        {

        }

        public FTDIException(FTStatus status, string message, Exception inner) : base("FTDI Driver Returned Status:" + status + "Type:" + Enum.GetName(typeof(FTStatus), status) + " Message: " + message, inner)
        {

        }

        protected FTDIException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext contex)
        {
        }
    }
}
