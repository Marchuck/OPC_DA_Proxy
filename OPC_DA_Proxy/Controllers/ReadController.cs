using Opc.Da;
using OPC_DA_Proxy.Models;
using OPC_DA_Proxy.OpcDaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OPC_DA_Proxy.Controllers
{
    public class ReadController : ApiController
    {
        public ItemValueResult[] PostFetchCurrentValues(ReadNodeValuesBulkRequest body)
        {
            return OpcDaConnector.ReadMultipleValues(body);
        }
    }
}
