using Newtonsoft.Json;
using Opc.Da;
using Opc.Dx;
using OPC_DA_Proxy.OpcDaClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItemValueResult = Opc.Da.ItemValueResult;

namespace OPC_DA_Proxy.Models
{
    public class Workspace
    {
        private static Workspace instance = new Workspace();

        ItemValueResult[] results { get; set; }

        Dictionary<string, BrowseElement[]> nodes = new Dictionary<string, BrowseElement[]>();

        public Workspace()
        {
        }
     
        public static Workspace getInstance()
        {
            return instance;
        }

        public void UpdateWorkspace(ItemValueResult[] NewResults)
        {
            results = NewResults;
        }

        public string[] directories()
        {
            string[] _nodes = new string[nodes.Keys.Count];
            int h = 0;
            foreach (string directory in nodes.Keys)
            {
                _nodes[h] = directory; ++h;
            }
            return _nodes;
        }
        
        public BrowseElement[] browse(ref string itemName)
        {
            BrowsePosition position;
            BrowseFilters filters = new BrowseFilters() { BrowseFilter = browseFilter.all };
            if (OpcDaConnector.server == null) return new BrowseElement[] { new BrowseElement() };
            else
            {
                BrowseElement[]  browsed = OpcDaConnector.server.Browse(new ItemIdentifier(itemName), filters, out position);
                return browsed;
            }
        }


        public void UpdateWorkspaceNodes(Dictionary<string, BrowseElement[]> nodes)
        {
            this.  nodes = nodes;
        }

        public ItemValueResult[] GetWorkspace()
        {
            return results;
        }
        public BrowseElement[] GetDirectoryNodes(string dirname)
        {
            return nodes[dirname];
        }

        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
   
}