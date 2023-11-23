using System.Diagnostics;

namespace Azuri_Editor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Add handler to handle the exception raised by main threads
            Application.ThreadException +=
            new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Add handler to handle the exception raised by additional threads
            AppDomain.CurrentDomain.UnhandledException +=
            new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AzuriEditor());

            // Stop the application and all the threads in suspended state.
            Environment.Exit(-1);
        }

        static void Application_ThreadException
            (object sender, System.Threading.ThreadExceptionEventArgs e)
        {// All exceptions thrown by the main thread are handled over this method

            //use cmd to run CrashHandler.exe
            CurrentDomain_UnhandledException(sender, new UnhandledExceptionEventArgs(e.Exception, false));

        }

        static void CurrentDomain_UnhandledException
            (object sender, UnhandledExceptionEventArgs e)
        {// All exceptions thrown by additional threads are handled in this method
            //Messagebox with Continue and Exit buttons
            
            MessageBoxManager.Abort = "Exit";
            MessageBoxManager.Retry = "Restart";
            MessageBoxManager.Register();
            MessageBox.Show("An error occured. Please send the error report to the developer.", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }

    }

}