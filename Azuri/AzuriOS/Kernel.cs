using System;
using System.Drawing;
using Cosmos.Core.IOGroup;
using Cosmos.HAL;
using Cosmos.HAL.Drivers;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Console = System.Console;
using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using System.IO;
namespace AzuriOS
{
    public class Kernel : Sys.Kernel
    {

        [ManifestResourceStream(ResourceName = "AzuriOS.Images.Azuri1.bmp")]
        static byte[] bg1;

        Bitmap currentbgbitmap;
        Canvas canvas;
        int xresolution = 1920;
        int yresolution = 1080;

        protected override void BeforeRun()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Mode = new(xresolution, yresolution, ColorDepth.ColorDepth32);
            currentbgbitmap = new Bitmap(bg1);
        }

        protected override void Run()
        {
            canvas.DrawImage(currentbgbitmap, 0, 0);
            canvas.Display();
        }
    }
}
