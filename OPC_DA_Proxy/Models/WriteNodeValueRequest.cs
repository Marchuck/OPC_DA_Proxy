using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_Proxy.Models
{
    public class WriteNodeValueRequest
    {
        public string nodeName;
        public double value;
    }
}