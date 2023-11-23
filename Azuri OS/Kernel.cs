using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;

namespace AzureOS
{
    public class Kernel : Sys.Kernel
    {
        [ManifestResourceStream(ResourceName = "AzureOS.Images.OSBG1.bmp")]
        static byte[] bg1;
        Bitmap currentbgbitmap;
        uint xresolution = 1920;
        uint yresolution = 1080;
        Canvas canvas;
        protected override void BeforeRun()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();

            canvas.Mode = new Mode((int)xresolution, (int)yresolution, ColorDepth.ColorDepth24);

            currentbgbitmap = new Bitmap(bg1);
        }

        protected override void Run()
        {
            // Constantly draw bg
            canvas.DrawImage(currentbgbitmap, 0, 0);
        }
    }
}
