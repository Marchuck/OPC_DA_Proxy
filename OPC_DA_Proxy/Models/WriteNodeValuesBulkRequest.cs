using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_Proxy.Models
{
    public class WriteNodeValuesBulkRequest
    {
        public List<WriteNodeValueRequest> nodes;

        public WriteNodeValuesBulkRequest() { }
    }
}