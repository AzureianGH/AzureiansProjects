using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AzuriHTMLEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int openport;
        private TcpListener myListener;
        //private WebServer server;

        public MainWindow()
        {
            InitializeComponent();
            SearchForOpenPorts();
            StartWebServer();
        }

        public void SearchForOpenPorts()
        {
            //Get a random number 0, 36000
            Random rnd = new Random();
            int port = rnd.Next(0, 36000);
            //Check if the port is open
            if (CheckPort(port))
            {
                //If it is open, return the port
                openport = port;
            }
        }

        public bool CheckPort(int port)
        {
            //Check if the port is open
            try
            {
                //Try to listen on the port
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                listener.Stop();
                //If it is open, return true
                return true;
            }
            catch
            {
                //If it is not open, return false
                return false;
            }
        }

        public void StartWebServer()
        {
           // string rootDirectory = Environment.CurrentDirectory;
            //server = new WebServer(rootDirectory, openport);
            //Task.Run(() => server.StartHosting());
        }

        // Add any other methods or event handlers you need for your MainWindow class
    }
}
