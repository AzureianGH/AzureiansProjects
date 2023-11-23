// Decompiled with JetBrains decompiler
// Type: KeyAuth.Program
// Assembly: keyauth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8DC670F4-051F-46A9-8348-44431FE85723
// Assembly location: E:\Downloads\winrta\winterz spoof\keyauth.dll

using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;


#nullable enable
namespace KeyAuth
{
  internal class Program
  {
    public static api KeyAuthApp = new api("example", "9J0Fqpb7Gt", "5ad4926c352d6f3f3ae338033e914edc01c5ddda7b52f2fd0a6c527879236f19", "1.0");

    private void ShowResponse(string type)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
      interpolatedStringHandler.AppendLiteral("It took ");
      interpolatedStringHandler.AppendFormatted<long>(api.responseTime);
      interpolatedStringHandler.AppendLiteral(" ms to ");
      interpolatedStringHandler.AppendFormatted(type);
      Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
    }

    private static void Main(string[] args)
    {
      Console.Title = "Loader";
      Console.WriteLine("\n\n Connecting..");
      Program.KeyAuthApp.init();
      if (!Program.KeyAuthApp.response.success)
      {
        Console.WriteLine("\n Status: " + Program.KeyAuthApp.response.message);
        Thread.Sleep(1500);
        Environment.Exit(0);
      }
      Console.Write("\n type 1 to continue: ");
      int.Parse(Console.ReadLine());
      Console.Write("\n\n Enter license: ");
      string key = Console.ReadLine();
      Program.KeyAuthApp.license(key);
      if (!Program.KeyAuthApp.response.success)
      {
        Console.WriteLine("\n Status: " + Program.KeyAuthApp.response.message);
        Console.WriteLine("\n Closing in five seconds...");
        Thread.Sleep(5000);
        Environment.Exit(0);
      }
      Console.WriteLine("\n Logged In!");
      Mainx();

      static void CheckRegistryKeys()
      {
        try
        {
          CheckRegistryKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "InstallationID");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", "ComputerName");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", "ActiveComputerName");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerNamePhysicalDnsDomain", "");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", "ComputerName");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", "ActiveComputerName");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", "ComputerNamePhysicalDnsDomain");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "Hostname");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", "NV Hostname");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces", "Hostname");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces", "NV Hostname");
          CheckRegistryKey("HARDWARE\\DEVICEMAP\\Scsi", "");
          CheckRegistryKey("HARDWARE\\DEVICEMAP\\Scsi\\{port}", "");
          CheckRegistryKey("HARDWARE\\DEVICEMAP\\Scsi\\{port}\\{bus}\\Target Id 0\\Logical Unit Id 0", "DeviceIdentifierPage");
          CheckRegistryKey("HARDWARE\\DEVICEMAP\\Scsi\\{port}\\{bus}\\Target Id 0\\Logical Unit Id 0", "Identifier");
          CheckRegistryKey("HARDWARE\\DEVICEMAP\\Scsi\\{port}\\{bus}\\Target Id 0\\Logical Unit Id 0", "InquiryData");
          CheckRegistryKey("HARDWARE\\DEVICEMAP\\Scsi\\{port}\\{bus}\\Target Id 0\\Logical Unit Id 0", "SerialNumber");
          CheckRegistryKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral", "");
          CheckRegistryKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral\\{disk}", "Identifier");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", "HwProfileGuid");
          CheckRegistryKey("SOFTWARE\\Microsoft\\Cryptography", "MachineGuid");
          CheckRegistryKey("SOFTWARE\\Microsoft\\SQMClient", "MachineId");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "BIOSReleaseDate");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "BIOSVersion");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "ComputerHardwareId");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "ComputerHardwareIds");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "ComputerManufacturer");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "ComputerModel");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "InstallDate");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemBiosMajorVersion");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemBiosMinorVersion");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemBiosVersion");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemManufacturer");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemProductName");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemSku");
          CheckRegistryKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", "SystemVersion");
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error to check the Registry-Key: " + ex.Message);
        }
      }

      static void CheckRegistryKey(string keyPath, string valueName)
      {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath);
        if (registryKey != null)
        {
          if (!string.IsNullOrEmpty(valueName))
          {
            if (registryKey.GetValue(valueName) != null)
              return;
            Console.WriteLine("Registry-Key not found: " + keyPath + "\\" + valueName);
          }
          else
          {
            if (registryKey.SubKeyCount != 0)
              return;
            Console.WriteLine("Registry-Key not found: " + keyPath);
          }
        }
        else
          Console.WriteLine("Registry-Key not found: " + keyPath);
      }

      static void SpoofInstallationID()
      {
        using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true))
        {
          if (registryKey == null)
            return;
          string str = Guid.NewGuid().ToString();
          registryKey.SetValue("InstallationID", (object) str);
          registryKey.Close();
        }
      }

      static void SpoofPCName()
      {
        string str = RandomId(8);
        using (RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true))
        {
          registryKey1.SetValue("ComputerName", (object) str);
          registryKey1.SetValue("ActiveComputerName", (object) str);
          registryKey1.SetValue("ComputerNamePhysicalDnsDomain", (object) "");
          using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true))
          {
            registryKey2.SetValue("ComputerName", (object) str);
            registryKey2.SetValue("ActiveComputerName", (object) str);
            registryKey2.SetValue("ComputerNamePhysicalDnsDomain", (object) "");
            using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", true))
            {
              registryKey3.SetValue("Hostname", (object) str);
              registryKey3.SetValue("NV Hostname", (object) str);
              using (RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces", true))
              {
                foreach (string subKeyName in registryKey4.GetSubKeyNames())
                {
                  using (RegistryKey registryKey5 = registryKey4.OpenSubKey(subKeyName, true))
                  {
                    registryKey5.SetValue("Hostname", (object) str);
                    registryKey5.SetValue("NV Hostname", (object) str);
                  }
                }
              }
            }
          }
        }
      }

      static string RandomId(int length)
      {
        string str1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string str2 = "";
        Random random = new Random();
        for (int index = 0; index < length; ++index)
          str2 += str1[random.Next(str1.Length)].ToString();
        return str2;
      }

      static string RandomMac()
      {
        string str1 = "ABCDEF0123456789";
        string str2 = "26AE";
        string str3 = "";
        Random random = new Random();
        string str4 = str3 + str1[random.Next(str1.Length)].ToString() + str2[random.Next(str2.Length)].ToString();
        for (int index = 0; index < 5; ++index)
          str4 = str4 + "-" + str1[random.Next(str1.Length)].ToString() + str1[random.Next(str1.Length)].ToString();
        return str4;
      }

      static void Enable_LocalAreaConection(string adapterId, bool enable = true)
      {
        string str1 = "Ethernet";
        foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
          if (networkInterface.Id == adapterId)
          {
            str1 = networkInterface.Name;
            break;
          }
        }
        string str2 = !enable ? "disable" : nameof (enable);
        ProcessStartInfo processStartInfo = new ProcessStartInfo("netsh", "interface set interface \"" + str1 + "\" " + str2);
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();
      }

      static void SpoofDisks()
      {
        using (RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi"))
        {
          foreach (string subKeyName1 in registryKey1.GetSubKeyNames())
          {
            using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi\\" + subKeyName1))
            {
              foreach (string subKeyName2 in registryKey2.GetSubKeyNames())
              {
                RegistryKey localMachine = Registry.LocalMachine;
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(55, 2);
                interpolatedStringHandler.AppendLiteral("HARDWARE\\DEVICEMAP\\Scsi\\");
                interpolatedStringHandler.AppendFormatted(subKeyName1);
                interpolatedStringHandler.AppendLiteral("\\");
                interpolatedStringHandler.AppendFormatted(subKeyName2);
                interpolatedStringHandler.AppendLiteral("\\Target Id 0\\Logical Unit Id 0");
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                using (RegistryKey registryKey3 = localMachine.OpenSubKey(stringAndClear, true))
                {
                  if (registryKey3 != null)
                  {
                    if (registryKey3.GetValue("DeviceType").ToString() == "DiskPeripheral")
                    {
                      string s1 = RandomId(14);
                      string s2 = RandomId(14);
                      registryKey3.SetValue("DeviceIdentifierPage", (object) Encoding.UTF8.GetBytes(s2));
                      registryKey3.SetValue("Identifier", (object) s1);
                      registryKey3.SetValue("InquiryData", (object) Encoding.UTF8.GetBytes(s1));
                      registryKey3.SetValue("SerialNumber", (object) s2);
                    }
                  }
                }
              }
            }
          }
          using (RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral"))
          {
            foreach (string subKeyName in registryKey4.GetSubKeyNames())
            {
              using (RegistryKey registryKey5 = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController\\0\\DiskPeripheral\\" + subKeyName, true))
                registryKey5.SetValue("Identifier", (object) (RandomId(8) + "-" + RandomId(8) + "-A"));
            }
          }
        }
      }

      static void SpoofGUIDs()
      {
        using (RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true))
        {
          RegistryKey registryKey2 = registryKey1;
          DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(2, 1);
          interpolatedStringHandler1.AppendLiteral("{");
          interpolatedStringHandler1.AppendFormatted<Guid>(Guid.NewGuid());
          interpolatedStringHandler1.AppendLiteral("}");
          string stringAndClear1 = interpolatedStringHandler1.ToStringAndClear();
          registryKey2.SetValue("HwProfileGuid", (object) stringAndClear1);
          using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true))
          {
            RegistryKey registryKey4 = registryKey3;
            Guid guid = Guid.NewGuid();
            string str1 = guid.ToString();
            registryKey4.SetValue("MachineGuid", (object) str1);
            using (RegistryKey registryKey5 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\SQMClient", true))
            {
              RegistryKey registryKey6 = registryKey5;
              DefaultInterpolatedStringHandler interpolatedStringHandler2 = new DefaultInterpolatedStringHandler(2, 1);
              interpolatedStringHandler2.AppendLiteral("{");
              interpolatedStringHandler2.AppendFormatted<Guid>(Guid.NewGuid());
              interpolatedStringHandler2.AppendLiteral("}");
              string stringAndClear2 = interpolatedStringHandler2.ToStringAndClear();
              registryKey6.SetValue("MachineId", (object) stringAndClear2);
              using (RegistryKey registryKey7 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", true))
              {
                Random random = new Random();
                int num1 = random.Next(1, 31);
                DefaultInterpolatedStringHandler interpolatedStringHandler3;
                string stringAndClear3;
                if (num1 < 10)
                {
                  interpolatedStringHandler3 = new DefaultInterpolatedStringHandler(1, 1);
                  interpolatedStringHandler3.AppendLiteral("0");
                  interpolatedStringHandler3.AppendFormatted<int>(num1);
                  stringAndClear3 = interpolatedStringHandler3.ToStringAndClear();
                }
                else
                  stringAndClear3 = num1.ToString();
                int num2 = random.Next(1, 13);
                string stringAndClear4;
                if (num2 < 10)
                {
                  interpolatedStringHandler3 = new DefaultInterpolatedStringHandler(1, 1);
                  interpolatedStringHandler3.AppendLiteral("0");
                  interpolatedStringHandler3.AppendFormatted<int>(num2);
                  stringAndClear4 = interpolatedStringHandler3.ToStringAndClear();
                }
                else
                  stringAndClear4 = num2.ToString();
                RegistryKey registryKey8 = registryKey7;
                interpolatedStringHandler3 = new DefaultInterpolatedStringHandler(2, 3);
                interpolatedStringHandler3.AppendFormatted(stringAndClear3);
                interpolatedStringHandler3.AppendLiteral("/");
                interpolatedStringHandler3.AppendFormatted(stringAndClear4);
                interpolatedStringHandler3.AppendLiteral("/");
                interpolatedStringHandler3.AppendFormatted<int>(random.Next(2000, 2023));
                string stringAndClear5 = interpolatedStringHandler3.ToStringAndClear();
                registryKey8.SetValue("BIOSReleaseDate", (object) stringAndClear5);
                registryKey7.SetValue("BIOSVersion", (object) RandomId(10));
                RegistryKey registryKey9 = registryKey7;
                interpolatedStringHandler3 = new DefaultInterpolatedStringHandler(2, 1);
                interpolatedStringHandler3.AppendLiteral("{");
                interpolatedStringHandler3.AppendFormatted<Guid>(Guid.NewGuid());
                interpolatedStringHandler3.AppendLiteral("}");
                string stringAndClear6 = interpolatedStringHandler3.ToStringAndClear();
                registryKey9.SetValue("ComputerHardwareId", (object) stringAndClear6);
                RegistryKey registryKey10 = registryKey7;
                interpolatedStringHandler3 = new DefaultInterpolatedStringHandler(9, 3);
                interpolatedStringHandler3.AppendLiteral("{");
                interpolatedStringHandler3.AppendFormatted<Guid>(Guid.NewGuid());
                interpolatedStringHandler3.AppendLiteral("}\n{");
                interpolatedStringHandler3.AppendFormatted<Guid>(Guid.NewGuid());
                interpolatedStringHandler3.AppendLiteral("}\n{");
                interpolatedStringHandler3.AppendFormatted<Guid>(Guid.NewGuid());
                interpolatedStringHandler3.AppendLiteral("}\n");
                string stringAndClear7 = interpolatedStringHandler3.ToStringAndClear();
                registryKey10.SetValue("ComputerHardwareIds", (object) stringAndClear7);
                registryKey7.SetValue("SystemManufacturer", (object) RandomId(15));
                registryKey7.SetValue("SystemProductName", (object) RandomId(6));
                using (RegistryKey registryKey11 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", true))
                {
                  RegistryKey registryKey12 = registryKey11;
                  guid = Guid.NewGuid();
                  string str2 = guid.ToString();
                  registryKey12.SetValue("SusClientId", (object) str2);
                  registryKey11.SetValue("SusClientIdValidation", (object) Encoding.UTF8.GetBytes(RandomId(25)));
                }
              }
            }
          }
        }
      }

      static void UbisoftCache()
      {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string path4_1 = Path.Combine("Ubisoft Game Launcher", "cache");
        string path4_2 = Path.Combine("Ubisoft Game Launcher", "logs");
        string path4_3 = Path.Combine("Ubisoft Game Launcher", "savegames");
        string path3 = Path.Combine("Ubisoft Game Launcher", "spool");
        DirectoryInfo directoryInfo1 = new DirectoryInfo(Path.Combine("C:", "Program Files (x86)", "Ubisoft", path4_1));
        DirectoryInfo directoryInfo2 = new DirectoryInfo(Path.Combine("C:", "Program Files (x86)", "Ubisoft", path4_2));
        DirectoryInfo directoryInfo3 = new DirectoryInfo(Path.Combine("C:", "Program Files (x86)", "Ubisoft", path4_3));
        DirectoryInfo directoryInfo4 = new DirectoryInfo(Path.Combine(folderPath, "Ubisoft Game Launcher", path3));
        foreach (FileSystemInfo file in directoryInfo1.GetFiles())
          file.Delete();
        foreach (DirectoryInfo directory in directoryInfo1.GetDirectories())
          directory.Delete(true);
        foreach (FileSystemInfo file in directoryInfo2.GetFiles())
          file.Delete();
        foreach (DirectoryInfo directory in directoryInfo2.GetDirectories())
          directory.Delete(true);
        foreach (FileSystemInfo file in directoryInfo3.GetFiles())
          file.Delete();
        foreach (DirectoryInfo directory in directoryInfo3.GetDirectories())
          directory.Delete(true);
        foreach (FileSystemInfo file in directoryInfo4.GetFiles())
          file.Delete();
        foreach (DirectoryInfo directory in directoryInfo4.GetDirectories())
          directory.Delete(true);
      }

      static void DeleteValorantCache()
      {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\VALORANT\\saved";
        if (!Directory.Exists(path))
          return;
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        foreach (FileSystemInfo file in directoryInfo.GetFiles())
          file.Delete();
        foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
          directory.Delete(true);
      }

      static bool SpoofMAC()
      {
        bool flag = false;
        using (RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}"))
        {
          foreach (string subKeyName in registryKey1.GetSubKeyNames())
          {
            if (subKeyName != "Properties")
            {
              try
              {
                using (RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}\\" + subKeyName, true))
                {
                  if (registryKey2.GetValue("BusType") != null)
                  {
                    registryKey2.SetValue("NetworkAddress", (object) RandomMac());
                    string adapterId = registryKey2.GetValue("NetCfgInstanceId").ToString();
                    Enable_LocalAreaConection(adapterId, false);
                    Enable_LocalAreaConection(adapterId, true);
                  }
                }
              }
              catch (SecurityException ex)
              {
                Console.WriteLine("\n[X] Start the spoofer in admin mode to spoof your MAC address!");
                flag = true;
                break;
              }
            }
          }
          return flag;
        }
      }

      static void SpoofGPU()
      {
        string name = "SYSTEM\\CurrentControlSet\\Enum\\PCI\\VEN_10DE&DEV_0DE1&SUBSYS_37621462&REV_A1";
        using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, true))
        {
          if (registryKey == null)
            return;
          string str = "PCIVEN_8086&DEV_1234&SUBSYS_5678ABCD&REV_01";
          registryKey.GetValue("HardwareID");
          registryKey.SetValue("HardwareID", (object) str);
          registryKey.SetValue("CompatibleIDs", (object) new string[1]
          {
            str
          });
          registryKey.SetValue("Driver", (object) "pci.sys");
          registryKey.SetValue("ConfigFlags", (object) 0, RegistryValueKind.DWord);
          registryKey.SetValue("ClassGUID", (object) "{4d36e968-e325-11ce-bfc1-08002be10318}");
          registryKey.SetValue("Class", (object) "Display");
          registryKey.Close();
        }
      }

      static void SpoofEFIVariableId()
      {
        try
        {
          RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Nsi\\{eb004a03-9b1a-11d4-9123-0050047759bc}\\26", true);
          if (registryKey == null)
            return;
          string str = Guid.NewGuid().ToString();
          registryKey.SetValue("VariableId", (object) str);
          registryKey.Close();
        }
        catch (Exception ex)
        {
          Console.WriteLine("\n[X] Start the spoofer in admin mode to spoof your MAC address!");
        }
      }

      static void SpoofSMBIOSSerialNumber()
      {
        try
        {
          RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS", true);
          if (registryKey != null)
          {
            string str = RandomId(10);
            registryKey.SetValue("SystemSerialNumber", (object) str);
            registryKey.Close();
          }
          else
            Console.WriteLine("\n[X] Cant find the SMBIOS");
        }
        catch (Exception ex)
        {
          Console.WriteLine("\n[X] Start the spoofer in admin mode to spoof your MAC address!");
        }
      }

      static void DisplaySystemData()
      {
        Console.WriteLine("System Data:");
        Console.WriteLine("------------------------------------------------");
        try
        {
          using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true))
            Console.WriteLine("HWID:              " + (registryKey.GetValue("InstallationID") as string));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving HWID: " + ex.Message);
        }
        try
        {
          using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography"))
            Console.WriteLine("Machine GUID:      " + (registryKey.GetValue("MachineGuid") as string));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving Machine GUID: " + ex.Message);
        }
        try
        {
          foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
          {
            PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
            Console.WriteLine("MAC ID (" + networkInterface.Name + "):     " + physicalAddress.ToString());
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving MAC ID: " + ex.Message);
        }
        try
        {
          using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true))
            Console.WriteLine("Installation ID:    " + (registryKey.GetValue("InstallationID") as string));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving Installation ID: " + ex.Message);
        }
        try
        {
          using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName"))
            Console.WriteLine("PC Name:           " + (registryKey.GetValue("ComputerName") as string));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving PC Name: " + ex.Message);
        }
        try
        {
          using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\PCI\\VEN_10DE&DEV_0DE1&SUBSYS_37621462&REV_A1"))
            Console.WriteLine("GPU ID:            " + (registryKey.GetValue("HardwareID") as string));
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving GPU ID: " + ex.Message);
        }
        try
        {
          string str = string.Empty;
          using (StreamReader streamReader = new StreamReader("C:\\proc\\cpuinfo"))
            str = streamReader.ReadToEnd();
          Console.WriteLine("CPU Information:   " + str);
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving CPU Information: " + ex.Message);
        }
        try
        {
          using (StreamReader streamReader = new StreamReader("/proc/meminfo"))
          {
            string str;
            while ((str = streamReader.ReadLine()) != null)
              Console.WriteLine("Memory Information: " + str);
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine("Error retrieving Memory Information: " + ex.Message);
        }
      }

      static void Menu()
      {
        Console.WriteLine("\n");
        Console.Write("  Select an option: ");
        switch (Console.ReadLine())
        {
          case "1":
            Console.WriteLine("\n  [+] Disks spoofed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "10":
            SpoofSMBIOSSerialNumber();
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "11":
            CheckRegistryKeys();
            ClearConsoleAfterDelay2();
            Menu();
            break;
          case "12":
            DisplaySystemData();
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "13":
            SpoofDisks();
            SpoofGUIDs();
            SpoofMAC();
            UbisoftCache();
            DeleteValorantCache();
            SpoofGPU();
            SpoofPCName();
            SpoofEFIVariableId();
            SpoofInstallationID();
            Console.WriteLine("\n  [+] All commands executed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "2":
            Console.WriteLine("\n  [+] GUIDs spoofed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "3":
            Console.WriteLine("  [+] MAC address spoofed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "4":
            Console.WriteLine("\n  [+] Ubisoft Cache deleted");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "5":
            Console.WriteLine("\n  [+] Valorant Cache deleted");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "6":
            Console.WriteLine("\n  [+] GPU ID Spoofed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "7":
            SpoofPCName();
            Console.WriteLine("\n  [+] PC name spoofed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "8":
            SpoofInstallationID();
            Console.WriteLine("\n  [+] Installation ID spoofed");
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "9":
            SpoofEFIVariableId();
            ClearConsoleAfterDelay();
            Menu();
            break;
          case "exit":
            Environment.Exit(0);
            break;
          default:
            Console.WriteLine("\n  [X] Invalid option!");
            ClearConsoleAfterDelay();
            Menu();
            break;
        }
      }

      static void ClearConsoleAfterDelay()
      {
        Thread.Sleep(3000);
        Console.Clear();
        Mainx();
      }

      static void ClearConsoleAfterDelay2()
      {
        Thread.Sleep(6000);
        Console.Clear();
        Mainx();
      }

      static void Mainx()
      {
        Console.Title = "WinterZ Premium Spoofer | V1.3 | UD EAC BE VA | softaim.org";
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();
        Console.WriteLine("░██╗░░░░░░░██╗██╗███╗░░██╗████████╗███████╗██████╗░███████╗      ");
        Console.WriteLine("░██║░░██╗░░██║██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗╚════██║      ");
        Console.WriteLine("░╚██╗████╗██╔╝██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝░░███╔═       ");
        Console.WriteLine("░░████╔═████║░██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗██╔══╝░░        ");
        Console.WriteLine("░░╚██╔╝░╚██╔╝░██║██║░╚███║░░░██║░░░███████╗██║░░██║███████╗         ");
        Console.WriteLine("░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚══════╝         ");
        Console.WriteLine("https://discord.gg/ffyF5gVupG                               ");
        Console.WriteLine("                                            ");
        Console.WriteLine("[1] Spoof HWID                       [7] Spoof PC Name            ");
        Console.WriteLine("[2] Spoof GUID                       [8] Spoof Installation ID    ");
        Console.WriteLine("[3] Spoof MAC ID                     [9] Spoof EFI                ");
        Console.WriteLine("[4] Delete UBI Cache                 [10] Spoof SMBIOS            ");
        Console.WriteLine("[5] Delete Valoant Cache                    ");
        Console.WriteLine("[6] Spoof GPU ID                            ");
        Console.WriteLine("                                            ");
        Console.WriteLine("[11] Check Registry Paths                   ");
        Console.WriteLine("[12] Get System informations                ");
        Console.WriteLine("[13] Spoof all                              ");
        Console.WriteLine("[exit] Exit                                 ");
        Console.WriteLine("  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Menu();
      }
    }
  }
}
