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
        public ItemValueResult[] GetWorkspace()
        {
            ItemValueResult[] results = Workspace.getInstance().GetWorkspace();
            return results;
        }
    }
}
