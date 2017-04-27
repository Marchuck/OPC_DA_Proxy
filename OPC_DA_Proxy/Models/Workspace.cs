using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_Proxy.Models
{
    public class Workspace
    {
        private static Workspace instance = new Workspace();
        
        Opc.Da.ItemValueResult[] results { get; set; }
        public Workspace()
        {
        }
     
        public static Workspace getInstance()
        {
            return instance;
        }
     
        public void UpdateWorkspace(Opc.Da.ItemValueResult[] NewResults)
        {
            this.results = NewResults;
        }

        public Opc.Da.ItemValueResult[] GetWorkspace()
        {
            return results;
        }

        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


    }
   
}