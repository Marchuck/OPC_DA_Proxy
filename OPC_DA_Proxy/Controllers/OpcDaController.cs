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
        public string GetWriteValueResponse(string nodeId, string directory, double value)
        {
            string fixedNodeId = nodeId.Replace("$", ".");
            return OpcDaConnector.WriteValue(fixedNodeId, directory, value);
        }

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

        public string[] GetAvailablePictures(bool pictures)
        {
            //return Workspace.getInstance().pictures();
            return Data.availablePicturesImpl2();
        }

        public Image GetPicture(string pictureId)
        {
            return new Image(pictureId, Data.forId(pictureId));
        }

    }
}
