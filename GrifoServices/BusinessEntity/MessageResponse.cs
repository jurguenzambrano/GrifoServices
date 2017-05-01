using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrifoServices.BusinessEntity
{
    public class MessageResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public IList<string> data { get; set; }
    }
}