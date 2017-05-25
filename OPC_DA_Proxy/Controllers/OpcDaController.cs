using Opc.Da;
using OPC_DA_Proxy.Models;
using OPC_DA_Proxy.OpcDaClient;
using System.Collections.Generic;
using System.Web.Http;
using ItemValueResult = Opc.Da.ItemValueResult;

namespace OPC_DA_Proxy.Controllers
{
    public class OpcDaController : ApiController
    {
        // GET: api/OpcDa
        public IEnumerable<ItemValueResult> Get()
        {
            ItemValueResult[] results = Workspace.getInstance().GetWorkspace();
            return results;
        }

        public BrowseElement[] Get(string id)
        {
            id = id.Replace("$", ".");
            return OpcDaConnector.repository[id];
        }
         
        public string[] GetDirectories(bool directories )
        {
            return Workspace.getInstance().directories();
        }
    }
}
