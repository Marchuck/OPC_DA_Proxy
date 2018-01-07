using OPC_DA_Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OPC_DA_Proxy.Controllers
{
    public class WriteController : ApiController
    {   
        public Opc.IdentifiedResult[] PostMultipleValues(WriteNodeValuesBulkRequest bulkRequest)
        {
            return OpcDaClient.OpcDaConnector.WriteMultipleValues(bulkRequest);
        }
    }
}
