using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.Core;
using Cosmos.Common;
using Cosmos.HAL;
using Cosmos.System.Graphics;
using System.Drawing;

namespace GUI
{
    public class Kernel : Sys.Kernel
    {
        Canvas screen;
        protected override void BeforeRun()
        {
            screen = FullScreenCanvas.GetFullScreenCanvas();
            screen.Mode = new Mode(800, 600, ColorDepth.ColorDepth32);
            screen.Clear();
        }

        protected override void Run()
        {
            screen.Clear(Color.White);
            screen.Display();
        }
    }
}
