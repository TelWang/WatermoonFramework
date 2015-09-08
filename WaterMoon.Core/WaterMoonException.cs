using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.Core
{
    [Serializable]
    public class WaterMoonException : Exception
    {
        public WaterMoonException()
        {
        }

        public WaterMoonException(string message)
            : base(message)
        {
        }

        public WaterMoonException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        protected WaterMoonException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }

        public WaterMoonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
