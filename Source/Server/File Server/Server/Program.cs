namespace Server
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {
            SocketServer server =new  SocketServer(8080);
            Thread threadServer = new Thread(server.Listen);
            threadServer.Start();
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form_FileManager());
            server.disconect(false);
        }
    }
}