using System;
//Sql
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Runtime.InteropServices;

namespace Scrap_Mechanic_World_Browser
{
    public partial class Form1 : Form
    {
        //public sql file db
        public SQLiteConnection dbConnection;
        private bool MissingGame = false;
        private bool MissingChildShape = false;
        private bool MissingController = false;
        private bool MissingGenericData = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void openSMFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open file dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Scrap Mechanic World File|*.db";
            openFileDialog1.Title = "Select a Scrap Mechanic World File";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();

            //Check if file exists, if it does, set the dbConnection to the file
            if (File.Exists(openFileDialog1.FileName))
            {
                try
                {
                    dbConnection.Close();
                }
                catch
                {
                    Console.WriteLine("No Connection to close!");
                }
                Console.WriteLine("File Exists!");
                //set worldnamelabel to the file name but remove the path and extension
                worldnamelabel.Text = "World Name: " + Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                dbConnection = new SQLiteConnection("Data Source=" + openFileDialog1.FileName + ";Version=3;");
                Console.WriteLine("SQL Version: " + dbConnection.ServerVersion);
                dbConnection.Open();
                Console.WriteLine("SQL Connection Opened!");
                //check if the tables exist
                Console.WriteLine("Checking for tables...");
                Console.WriteLine("Game: ");
                if (!TableExists(dbConnection, "Game"))
                {
                    Console.WriteLine("Game Table Not Found!");
                    MissingGame = true;
                }
                else
                {
                    Console.WriteLine("Game Table Found!");
                    MissingGame = false;
                }
                Console.WriteLine("ChildShape: ");
                if (!TableExists(dbConnection, "ChildShape"))
                {
                    Console.WriteLine("ChildShape Table Not Found!");
                    MissingChildShape = true;
                }
                else
                {
                    Console.WriteLine("ChildShape Table Found!");
                    MissingChildShape = false;
                }
                Console.WriteLine("Controller: ");
                if (!TableExists(dbConnection, "Controller"))
                {
                    Console.WriteLine("Controller Table Not Found!");
                    MissingController = true;
                }
                else
                {
                    Console.WriteLine("Controller Table Found!");
                    MissingController = false;
                }
                if (!TableExists(dbConnection, "GenericData"))
                {
                    Console.WriteLine("GenericData Table Not Found!");
                    MissingGenericData = true;
                }
                else
                {
                    Console.WriteLine("GenericData Table Found!");
                    MissingGenericData = false;
                }
                //check if any of the tables are missing, if they are, show a message box
                if (MissingGame || MissingChildShape || MissingController || MissingGenericData)
                {
                    string MissingTables = "";
                    if (MissingGame)
                    {
                        MissingTables += "Game\n";
                    }
                    if (MissingChildShape)
                    {
                        MissingTables += "ChildShape\n";
                    }
                    if (MissingController)
                    {
                        MissingTables += "Controller\n";
                    }
                    if (MissingGenericData)
                    {
                        MissingTables += "GenericData\n";
                    }
                    MessageBox.Show("The following tables are missing from the database:\n" + MissingTables + "\nThis is most likely due to the world being created in an older version of Scrap Mechanic.", "Missing Tables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //open table game and get savegameversion int and set label to it
                saveverlabel.Text = "Save Version: " + GetSaveVersion();
                //do the same for seed
                seedlabel.Text = "Seed: " + GetSeed();
                //do the same for gametick
                gticklabel.Text = "Game Tick: " + GetGameTick();
                //do the same for worldtime
                timeinlabel.Text = "World Time: " + GetWorldTime(GetGameTick()) + " Minutes";
                //do the same for mods
                if (CheckForMods())
                {
                    ismoddedlabel.Text = "Is Modded: Yes";
                }
                else
                {
                    ismoddedlabel.Text = "Is Modded: No";
                }
                //do the same for flags
                flagslabel.Text = "Flags: " + GetFlags();
            }
        }
        private string GetFlags()
        {
            Console.WriteLine("GetFlags");
            //get flags int from table game
            SQLiteCommand cmd = new SQLiteCommand("SELECT flags FROM Game", dbConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            //Write found flags to console for debugging
            Console.WriteLine("Found Flags: " + reader.GetInt32(0).ToString());
            return reader.GetInt32(0).ToString();
        }
        private bool CheckForMods()
        {
            // check the mods blob, if it is more than 4 bytes, then there are mods
            Console.WriteLine("CheckForMods");
            SQLiteCommand cmd = new SQLiteCommand("SELECT mods FROM Game", dbConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            //no rowid so we have to use GetBytes
            byte[] mods = new byte[5];
            reader.GetBytes(0, 0, mods, 0, 4);
            //check if all the bytes are 00
            if (mods[0] == 0 && mods[1] == 0 && mods[2] == 0 && mods[3] == 0 && mods[4] == 0)
            {
                Console.WriteLine("Checksum Complete, No mods found.");
                return false;
            }
            else
            {
                Console.WriteLine("Checksum Complete, Mods found with starter byte: " + mods[4]);
                return true;
            }
        }
        private string GetWorldTime(string gtick)
        {
            //scrap mechanic ticks are 40 ticks per second
            //so we divide the gametick by 40 to get the seconds
            //then we divide the seconds by 60 to get the minutes
            return (Convert.ToInt32(gtick) / 40 / 60).ToString();
        }
        private string GetGameTick()
        {
            //get gametick int from table game
            Console.WriteLine("GetGameTick");
            SQLiteCommand cmd = new SQLiteCommand("SELECT gametick FROM Game", dbConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0).ToString();
        }
        private string GetSeed()
        {
            //get seed int from table game
            Console.WriteLine("GetSeed");
            SQLiteCommand cmd = new SQLiteCommand("SELECT seed FROM Game", dbConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0).ToString();
        }
        private string GetSaveVersion()
        {
            //get savegameversion int from table game
            Console.WriteLine("GetSaveVersion");
            SQLiteCommand cmd = new SQLiteCommand("SELECT savegameversion FROM Game", dbConnection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0).ToString();
        }

        private void openSMFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private bool TableExists(SQLiteConnection file, string table)
        {
            // Check if table exists
            Console.WriteLine("Running SQL Check for table...");
            Console.WriteLine("SELECT name FROM sqlite_master WHERE type='table' AND name='" + table + "'", file);
            SQLiteCommand cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='" + table + "'", file);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Table Found!");
                return true;
            }
            else
            {
                Console.WriteLine("Table Not Found!");
                return false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}