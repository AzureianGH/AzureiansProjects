using Azuri_Editor;

namespace CrashHandler
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) // Modify Main method to accept string[] args
        {
            string errorMessage = ""; // Initialize the error message variable

            if (args.Length > 0)
            {
                errorMessage = string.Join(" ", args); // Join the arguments into a single string
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form2(errorMessage)); // Start the form with the provided error message (or empty if none)
        }

    }
}
