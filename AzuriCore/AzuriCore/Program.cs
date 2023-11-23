using System;
using System.Threading;
using System.Windows.Forms;

namespace AzuriCore
{
    internal static class Program
    {
        private static load? splashScreen;
        private static Thread? mainThread;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            splashScreen = new load();

            mainThread = new Thread(StartMainThread);
            mainThread.Start();

            Application.Run(splashScreen);
        }

        private static void StartMainThread()
        {
            // Simulate some work being done
            Thread.Sleep(1000);
            
            splashScreen?.Invoke((Action)splashScreen.Close);
            Application.Run(new AzuriCoreMain());
        }
    }
}
