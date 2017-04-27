using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Da;
using OPC_DA_Proxy.Models;

namespace OPC_DA_Proxy.OpcDaClient
{
    public class OpcDaConnector
    {
        #region fields

        private String opcServerEndpoint;
        private BrowsableGroup[] browsableGroups;
        private Opc.Da.Server server = null;
        
        #endregion

        public OpcDaConnector(String opcServerEndpoint, BrowsableGroup[] browsableGroups)
        {
            this.opcServerEndpoint = opcServerEndpoint;
            this.browsableGroups = browsableGroups;
        }
       
        public Boolean Connect()
        {
            
            // Create a server object and connect to the TwinCATOpcServer
            Opc.URL url = new Opc.URL(opcServerEndpoint);
            
            OpcCom.Factory fact = new OpcCom.Factory();
            server = new Opc.Da.Server(fact, null);
            server.Connect(url, new Opc.ConnectData(new System.Net.NetworkCredential()));

            // Create a group
            Opc.Da.Subscription group;

            foreach (BrowsableGroup BrowsableGroup in browsableGroups)
            {
                Opc.Da.SubscriptionState groupState = new SubscriptionState();
                groupState.Name = BrowsableGroup.GroupName;

                groupState.Active = true;
                group = (Opc.Da.Subscription)server.CreateSubscription(groupState);
                Opc.Da.Item[] items = BrowsableGroup.produceItemsFromNodes();

                items = group.AddItems(items);
                EnableDataChangedCallback(group);
                //todo:
                //EnableDataReadCallback(group);
                //todo:
                //EnableDataWriteCallback(group, BrowsableGroup.produceValueToWrite(items[0],34.0) );
            }


            return false;
        }
        public Boolean Disconnect()
        {

            return false;
        }
        private void EnableDataReadCallback(Subscription group)
        {
            Opc.IRequest req;
            group.Read(group.Items, 44.0, new Opc.Da.ReadCompleteEventHandler(ReadCompleteCallback), out req);
            Console.WriteLine();
            group.State.Active = true;
        }
        private void EnableDataWriteCallback(Subscription group, Opc.Da.ItemValue[] writeValues)
        {
            Opc.IRequest req;
            group.Write(writeValues, 44.0, new Opc.Da.WriteCompleteEventHandler(WriteCompleteCallback), out req);
            group.State.Active = true;
            Console.WriteLine();
        }
        private void EnableDataChangedCallback(Subscription group)
        {
            Opc.Da.DataChangedEventHandler handler = new Opc.Da.DataChangedEventHandler( DataChangedCallback);
            
            group.DataChanged += new Opc.Da.DataChangedEventHandler(DataChangedCallback);
            group.State.Active = true;
        }

        void DataChangedCallback(object subscriptionHandle, object requestHandle, Opc.Da.ItemValueResult[] results)
        {

            Workspace.getInstance().UpdateWorkspace(results);

            //Console.WriteLine("Data Changed in group "+(clientHandle as Subscription)?.Name);
            foreach (Opc.Da.ItemValueResult updateResult in results)
            {
                /**
                Console.WriteLine("\t{0}\tval:{1}", updateResult.ItemName, updateResult.Value);
                Console.WriteLine("TimeStamp: {0:00}:{1:00}:{2:00}:{3:000}",
                    updateResult.Timestamp.Hour,
                    updateResult.Timestamp.Minute,
                    updateResult.Timestamp.Second,
                    updateResult.Timestamp.Millisecond);
                */
                //                Workspace.getInstance().UpdateNode("AI", updateResult.ItemName, updateResult.Value);
                //                Workspace.getInstance().UpdateNode("AI", "FIX.WYSOKOSC.F_CV", -11);
            }
            //Console.WriteLine();
        }

        void WriteCompleteCallback(object clientHandle, Opc.IdentifiedResult[] results)
        {
            Console.WriteLine("Write completed");
            foreach (Opc.IdentifiedResult writeResult in results)
            {
                Console.WriteLine("\t{0} write result: {1}", writeResult.ItemName, writeResult.ResultID);
            }
            Console.WriteLine();
        }

        void ReadCompleteCallback(object clientHandle, Opc.Da.ItemValueResult[] results)
        {
            Console.WriteLine("Read completed");
            foreach (Opc.Da.ItemValueResult readResult in results)
            {
                Console.WriteLine("\t{0}\tval:{1}", readResult.ItemName, readResult.Value);
            }
            Console.WriteLine();
        }

        

    }
}
