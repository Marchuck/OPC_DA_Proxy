using System;
using Opc.Da;
using OPC_DA_Proxy.Models;
using Server = Opc.Da.Server;
using NetworkCredential = System.Net.NetworkCredential;
using Factory = OpcCom.Factory;
using Subscription = Opc.Da.Subscription;
using Opc.Dx;
using System.Threading;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPC_DA_Proxy.OpcDaClient
{
    public class OpcDaConnector
    {
        #region fields

        private String opcServerEndpoint;
        public static Server server = null;
        
        #endregion

        public OpcDaConnector(String opcServerEndpoint)
        {
            this.opcServerEndpoint = opcServerEndpoint;
        }

        public Boolean Connect()
        {
            // Create a server object and connects to 
            Opc.URL url = new Opc.URL(opcServerEndpoint);
            
            Factory fact = new Factory();
            server = new Server(fact, null);
            server.Connect(url, new Opc.ConnectData(new NetworkCredential()));
            
            string root = getRootName(server);

            recursiveTreeFill(server, root);

            // Create a group
            Subscription group;

            //AI, DI ...
            BrowseElement[] directories = repository[root];

            foreach (BrowseElement dir in directories) {
                string directoryName = dir.Name;

                SubscriptionState groupState = new SubscriptionState();
                groupState.Name = directoryName;

                groupState.Active = true;
                group = (Subscription)server.CreateSubscription(groupState);

                List<Item> itemsPerDirectory = new List<Item>();

                //FIX.AI.BLACK, FIX.AI.RED, FIX.DI.GREEN ...
                BrowseElement[] dirContent = repository[dir.ItemName];

                foreach (BrowseElement dirNode in dirContent) {
                    
                    //FIX.BLACK>F_CV <-this is real signal!

                    BrowseElement[] signals = repository[dirNode.ItemName];
                    foreach(BrowseElement signal in signals) {
                        //disable this nodes, because they are noisy
                        string itemName = signal.ItemName;
                        if (!itemName.Contains("A_OPCTIME")&& !itemName.Contains("A_SCAN"))
                        {
                            itemsPerDirectory.Add(new Item() { ItemName = signal.ItemName });
                        }
                    }
                }
                Item[] items = itemsPerDirectory.ToArray();
                items = group.AddItems(items);
                EnableDataChangedCallback(group);
            }
            
            /*
            foreach (BrowsableGroup BrowsableGroup in browsableGroups)
            {
                SubscriptionState groupState = new SubscriptionState();
                groupState.Name = BrowsableGroup.GroupName;

                groupState.Active = true;
                group = (Subscription)server.CreateSubscription(groupState);
                Item[] items = BrowsableGroup.produceItemsFromNodes();

                items = group.AddItems(items);
                EnableDataChangedCallback(group);
                //todo:
                //EnableDataReadCallback(group);
                //todo:
                //EnableDataWriteCallback(group, BrowsableGroup.produceValueToWrite(items[0],34.0) );
            }*/
            return false;
        }

        private Item[] produceItemsFromNodes(string directory, BrowseElement[] Nodes)
        {
            Item[] items = new Item[Nodes.Length];

            for (int j = 0; j < Nodes.Length; j++)
            {
                items[j] = new Item();
                items[j].ItemName = Nodes[j].ItemName;
            }
            return items;
        }

        private string getRootName(Server server)
        {
            BrowsePosition position;
            BrowseFilters filters = new BrowseFilters() { BrowseFilter = browseFilter.all };

            BrowseElement[] rootElements = server.Browse(new ItemIdentifier(), filters, out position);
            return rootElements[0].ItemName;
        }
        
        public static Dictionary<string, BrowseElement[]> repository { get; set; } = new Dictionary<string, BrowseElement[]>();

        public static string WriteValue(string nodeName, string directoryName, double value)
        {
            /*Opc.IRequest req;
            ItemValue it = new ItemValue(new Opc.ItemIdentifier(nodeName));
            it.Value = value;

            SubscriptionState groupState = new SubscriptionState();
            groupState.Name = directoryName;

            groupState.Active = true;
            Subscription group = (Subscription)server.CreateSubscription(groupState);
            group.Write( new ItemValue[] { it }, 44.0, new WriteCompleteEventHandler(WriteCompleteCallbackImpl), out req);
            group.State.Active = true;
            */


            ItemValueResult it = new ItemValueResult(new Opc.ItemIdentifier(nodeName));
            it.Value = value;
            
            server.Write(new ItemValueResult[] { it });

            Thread thread = new Thread(() =>
                        {
              Thread.CurrentThread.IsBackground = true;
            });

            thread.Start();
            thread.Name = "Masz ty RiGCz? wpisałeś  " +value+" do węzła "+ nodeName;
            return thread.Name;
            //return nodeName + " : " + value; 
        }

        private void recursiveTreeFill(Server server, string itemId)
        {
            BrowsePosition position;
            BrowseFilters filters = new BrowseFilters() { BrowseFilter = browseFilter.all };

            ItemIdentifier item = (itemId == null) ? new ItemIdentifier() : new ItemIdentifier(itemId);

            BrowseElement[] browseElements = server.Browse(item, filters, out position);

            repository.Add(itemId, browseElements);

            for (int index = 0; index < browseElements.Length; index++)
            {
                    BrowseElement browsedElement = browseElements[index];
                    string itemName = browsedElement.ItemName;
                if (browsedElement.HasChildren)
                {
                    recursiveTreeFill(server, itemName);
                }
                else
                {
                    if (!repository.ContainsKey(itemId))
                    {
                        repository.Add(itemId, new BrowseElement[] { });
                    }
                }
            }
        }
        

        private string[] crateNodeNames(BrowseElement[] browseElements)
        {
            int len = browseElements.Length;
            string[] nodeNames = new string[len];
            for(int j = 0; j < len; j++)
            {
                nodeNames[j] = browseElements[j].ItemName;
            }
            return nodeNames;
        }
        
        private void EnableDataReadCallback(Subscription group)
        {
            Opc.IRequest req;
            group.Read(group.Items, 44.0, new ReadCompleteEventHandler(ReadCompleteCallback), out req);
            Console.WriteLine();
            group.State.Active = true;
        }
        private void EnableDataWriteCallback(Subscription group, ItemValue[] writeValues)
        {
            Opc.IRequest req;
            group.Write(writeValues, 44.0, new WriteCompleteEventHandler(WriteCompleteCallback), out req);
            group.State.Active = true;
            Console.WriteLine();
        }
        private void EnableDataChangedCallback(Subscription group)
        {
            DataChangedEventHandler handler = new DataChangedEventHandler( DataChangedCallback);
            
            group.DataChanged += new DataChangedEventHandler(DataChangedCallback);
            group.State.Active = true;
        }

        void DataChangedCallback(object subscriptionHandle, object requestHandle, ItemValueResult[] results)
        {
            Workspace.getInstance().UpdateWorkspace(results);
        }
        static void WriteCompleteCallbackImpl(object clientHandle, Opc.IdentifiedResult[] results) { }


        void WriteCompleteCallback(object clientHandle, Opc.IdentifiedResult[] results)
        {
            Console.WriteLine("Write completed");
            foreach (Opc.IdentifiedResult writeResult in results)
            {
                Console.WriteLine("\t{0} write result: {1}", writeResult.ItemName, writeResult.ResultID);
            }
            Console.WriteLine();
        }

        void ReadCompleteCallback(object clientHandle, ItemValueResult[] results)
        {
            Console.WriteLine("Read completed");
            foreach (ItemValueResult readResult in results)
            {
                Console.WriteLine("\t{0}\tval:{1}", readResult.ItemName, readResult.Value);
            }
            Console.WriteLine();
        }
    }
}
