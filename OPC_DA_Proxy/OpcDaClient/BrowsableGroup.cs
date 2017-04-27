using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_Proxy.OpcDaClient
{
    public class BrowsableGroup
    {
        public string GroupName { get; set; }

        public string[] Nodes { get; set; }

        public BrowsableGroup() { }

        public Opc.Da.Item[] produceItemsFromNodes()
        {
            Opc.Da.Item[] items = new Opc.Da.Item[Nodes.Length];

            for (int j = 0; j < Nodes.Length; j++)
            {
                items[j] = new Opc.Da.Item();
                items[j].ItemName = Nodes[j];
            }

            return items;
        }

        public Opc.Da.ItemValue[] produceValuesToWrite(Opc.Da.Item[] itemsToWrite, double[] valuesToWrite)
        {
            Opc.Da.ItemValue[] writeValues = new Opc.Da.ItemValue[itemsToWrite.Length];

            for (int index = 0; index < itemsToWrite.Length; index++)
            {
                writeValues[index] = new Opc.Da.ItemValue();
                writeValues[index].ServerHandle = itemsToWrite[index].ServerHandle;
                writeValues[index].Value = valuesToWrite[index];
            }

            return writeValues;
        }

        public Opc.Da.ItemValue[] produceValueToWrite(Opc.Da.Item itemToWrite, double valueToWrite)
        {
            Opc.Da.Item[] itemsToWrite = new Opc.Da.Item[] { itemToWrite };

            double[] valuesToWrite = new double[] { valueToWrite };

            return produceValuesToWrite(itemsToWrite, valuesToWrite);
        }
    }
}