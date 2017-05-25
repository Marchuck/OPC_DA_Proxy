using System;

namespace OPC_DA_Proxy.OpcDaClient
{
    public class OpcDaRunner
    {
        public static String SERVER_NAME = "Intellution.OPCiFIX.1";

        private OpcDaConnector connector;

        private static OpcDaRunner instance = new OpcDaRunner();

        public static OpcDaRunner getInstance()
        {
            return instance;
        }
        
        public void Connect()
        {
            connector = new OpcDaConnector("opcda://localhost/" + SERVER_NAME);
            connector.Connect();
        }
        
        static void Main(string[] args)
        {
            getInstance().Connect();
        }
    }
}