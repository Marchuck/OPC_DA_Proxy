using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_Proxy.OpcDaClient
{
    public class OpcDaRunner
    {

        public static String SERVER_NAME = "Intellution.OPCiFIX.1";

        private static OpcDaRunner instance = new OpcDaRunner();

        public static OpcDaRunner getInstance()
        {
            return instance;
        }

        OpcDaConnector connector;
        private BrowsableGroup AiSignals()
        {
            BrowsableGroup g = new BrowsableGroup();
            g.GroupName = "AI";
            g.Nodes = new string[] { "FIX.BLACKY.F_CV", "FIX.RED.F_CV" };
            return g;
        }
        private BrowsableGroup DiSignals()
        {
            BrowsableGroup g = new BrowsableGroup();
            g.GroupName = "DI";
            g.Nodes = new string[] { "FIX.GREEN.F_CV" };
            return g;
        }

        public void Connect()
        {
            BrowsableGroup[] browsableGroups = new BrowsableGroup[] { AiSignals() , DiSignals() };
            connector = new OpcDaConnector("opcda://localhost/" + SERVER_NAME, browsableGroups);
            connector.Connect();
            //connector.selectGroup("AI").readNode("FIX.WYSOKOSC.F_CV").execute
            //connector.selectGroup("AI").writeValue(33).intoNode("FIX.WYSOKOSC.F_CV").execute();
        }

        public void Disconnect()
        {
            if (connector != null)
            {
                connector.Disconnect();
            }
        }

        

        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to iFIX Simulation Server");
            OpcDaRunner.getInstance().Connect();
            Console.ReadLine();
        }
    }
}