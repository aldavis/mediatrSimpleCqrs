using System.Collections.Generic;

namespace application.Logging
{
    public class Logger
    {
        public IList<string> Messages { get; } = new List<string>();
    }
}
