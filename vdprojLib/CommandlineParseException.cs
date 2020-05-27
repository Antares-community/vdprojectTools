using System;
using System.Collections.Generic;
using System.Text;

namespace Antares.BuildTools
{

    [Serializable]
    public class CommandlineParseException : Exception
    {
        public CommandlineParseException() { }
        public CommandlineParseException(string message) : base(message) { }
        public CommandlineParseException(string message, Exception inner) : base(message, inner) { }
        protected CommandlineParseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
