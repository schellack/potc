using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendPushoverNotification
{
    public class PushRequest
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
