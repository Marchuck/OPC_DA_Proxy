using OPC_DA_Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OPC_DA_Proxy.Controllers
{
    public class OpcDaController : ApiController
    {
        // GET: api/OpcDa
        public IEnumerable<Opc.Da.ItemValueResult> Get()
        {
            Opc.Da.ItemValueResult []results = Workspace.getInstance().GetWorkspace();
            return results;
        }
    }
}
