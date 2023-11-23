using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzuriHTMLEditor.WebManagement
{
    using System;
    using System.IO;
    using System.Net;

    public class WebServer
    {
        private readonly string rootDirectory;
        private readonly int port;
        private readonly HttpListener listener;

        public WebServer(string rootDirectory, int port)
        {
            this.rootDirectory = rootDirectory;
            this.port = port;
            listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{port}/");
        }

        public void StartHosting()
        {
            listener.Start();
            Console.WriteLine($"Server started. Listening on port {port}...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                ProcessRequest(context);
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            string requestUrl = context.Request.RawUrl;
            string filePath = Path.Combine(rootDirectory, requestUrl.Substring(1));

            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            context.Response.Close();
        }

        public void StopHosting()
        {
            listener.Stop();
            listener.Close();
            Console.WriteLine("Server stopped.");
        }
    }

}
