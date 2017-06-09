using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXWaveIO
{
    /// <summary>
    /// The Exception for FTDI Driver
    /// </summary>
    [Serializable]
    public class FTDIException : Exception
    {
        /// <summary>
        /// Instance from FTStatus <see cref="FTStatus"/>
        /// </summary>
        /// <param name="status"></param>
        public FTDIException(FTStatus status) : base("FTDI Driver Returned Status:" + status + "Type:" + Enum.GetName(typeof(FTStatus), status))
        {

        }
        /// <summary>
        /// Normal Instance
        /// </summary>
        public FTDIException() : base()
        {

        }
        /// <summary>
        /// Instance by message 
        /// </summary>
        /// <param name="message"></param>
        public FTDIException(string message) : base(message)
        {

        }
        /// <summary>
        /// Instance by FTStatus and message
        /// </summary>
        /// <param name="status"><see cref="FTStatus"/></param>
        /// <param name="message">Message of Error</param>
        public FTDIException(FTStatus status, string message) : base("FTDI Driver Returned Status:" + status + "Type:" + Enum.GetName(typeof(FTStatus), status) + " Message: " + message)
        {

        }

        /// <summary>
        /// Instance with inner Exception
        /// </summary>
        /// <param name="status"><see cref="FTStatus"/></param>
        /// <param name="message">Message of Error</param>
        /// <param name="inner">inner exception</param>
        public FTDIException(FTStatus status, string message, Exception inner) : base("FTDI Driver Returned Status:" + status + "Type:" + Enum.GetName(typeof(FTStatus), status) + " Message: " + message, inner)
        {

        }
        /// <summary>
        /// Serialize exception 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="contex"></param>
        protected FTDIException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) :base(info,context)
        {
        }
    }
}
