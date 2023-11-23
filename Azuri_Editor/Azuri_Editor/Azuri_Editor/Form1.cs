using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO.Compression;
using Azuri_Editor;

namespace Azuri_Hub
{
    public partial class AzuriHub : Form
    {
        private void UninstallAz()
        {
            if (Directory.Exists("Azuri Editor"))
            {
                Directory.Delete("Azuri Editor", true);
                installButton.Text = "Install";
                installButton.BackColor = Color.FromArgb(11, 122, 171);
                installButton.ForeColor = Color.White;
                installButton.Font = new Font("TkDefaultFont", 16);
                installButton.Click -= LaunchAz;
                installButton.Click += InstallAz;
                uninstallButton.Dispose();
            }
            else
            {
                MessageBox.Show("Azuri Editor cannot be uninstalled. Is administrator privileges enabled?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaunchAz()
        {
            Process.Start("cmd.exe", "/c " + Directory.GetCurrentDirectory() + "\\Azuri Editor\\Launch.bat");
        }

        private void InstallAz(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("https://github.com/AzureianGH/AzuriEditor/releases/download/Azuri_Editor/Azuri_Editor.zip", "azed.zip");
                ZipFile.ExtractToDirectory("azed.zip", Directory.GetCurrentDirectory() + "\\Azuri Editor");
                File.Delete("azed.zip");
            }

            installButton.Text = "Launch";
            installButton.BackColor = Color.FromArgb(59, 194, 245);
            installButton.ForeColor = Color.White;
            installButton.Font = new Font("TkDefaultFont", 16);
            installButton.Click -= InstallAz;
            installButton.Click += LaunchAz;
            uninstallButton.Click -= UninstallAz;
            uninstallButton.Click += UninstallAz;
        }

        public AzuriHub()
        {
            InitializeComponent();
            this.Text = "Azuri Hub";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.FromArgb(8, 154, 209);
            this.Icon = new Icon("logo.ico");

            Panel topBar = new Panel()
            {
                BackColor = Color.FromArgb(59, 194, 245),
                Size = new Size(this.ClientSize.Width, 25),
                Dock = DockStyle.Top
            };
            this.Controls.Add(topBar);

            Panel bottomBar = new Panel()
            {
                BackColor = Color.FromArgb(59, 194, 245),
                Size = new Size(this.ClientSize.Width, 25),
                Dock = DockStyle.Bottom
            };
            this.Controls.Add(bottomBar);

            Panel leftBar = new Panel()
            {
                BackColor = Color.FromArgb(59, 194, 245),
                Size = new Size(20, 790),
                Location = new Point(0, 0)
            };
            form1.Controls.Add(leftBar);
        }
    }
}