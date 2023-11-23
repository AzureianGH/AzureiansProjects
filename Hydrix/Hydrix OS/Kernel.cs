using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.HAL;
using Cosmos.HAL.Drivers;
using System.Drawing;
using Cosmos.System.Graphics.Fonts;
using System.Threading;
using Cosmos.Core.Memory;
using static System.Net.Mime.MediaTypeNames;

namespace Hydrix_OS
{
    public class Kernel : Sys.Kernel
    {
        Canvas screen;
        Window window1;
        Pen mousecolor;
        protected override void BeforeRun()
        {
            screen = FullScreenCanvas.GetFullScreenCanvas();
            // set resolution to 1920x1080
            screen.Mode = new Mode(1920, 1080, ColorDepth.ColorDepth32);
            screen.Clear(Color.Blue);
            window1 = new Window("Window 1", 0, 0, 900, 900, true); // Remove the "Window" type declaration.
            window1.init();
            mDebugger.Send("Init");
            window1.Draw(screen);
            mDebugger.Send("Drawn");
            mousecolor = new Pen(Color.Red);
            Sys.MouseManager.ScreenHeight = (ushort)screen.Mode.Rows;
            Sys.MouseManager.ScreenWidth = (ushort)screen.Mode.Columns;
            Sys.MouseManager.MouseSensitivity = 0.2f;
        }
        public class Window
        {
            public string title = "";
            public int x = 0;
            public int y = 0;
            public int width = 0;
            public int height = 0;
            public bool visible = false;
            public bool titlebar = true;
            public Color backgroundcolor = Color.White;
            public Color titlebarcolor = Color.Gray;
            public Color foregroundcolor = Color.Black;
            public Pen bg;
            public Pen fg;
            public Pen tb;
            public Font font;
            public Window(string title, int x, int y, int width, int height, bool visible)
            {
                this.title = title;
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
                this.visible = visible;
            }
            public void init()
            {
                bg = new Pen(backgroundcolor);
                fg = new Pen(foregroundcolor);
                tb = new Pen(titlebarcolor);
            }
            public void Draw(Canvas screen)
            {
                if (visible)
                {    
                    screen.DrawFilledRectangle(bg, x, y, width, height);
                    if (titlebar)
                    {
                        screen.DrawFilledRectangle(tb, x, y, width, 20);
                        //draw text
                        screen.DrawString(title, PCScreenFont.Default, fg, x, y);
                    }
                }
            }
            public void MoveTo(Canvas screen, int x, int y)
            {
                //remove old area
                screen.Clear(Color.Blue);
                this.x = x;
                this.y = y;
            }
        }

        protected override void Run()
        {
            int targetX = 100;
            int targetY = 100;
            window1.MoveTo(screen, targetX, targetY);
            Sys.MouseState mousestate = Sys.MouseManager.MouseState;
            while (true) // Add a loop for continuous animation.
            {
                // Move the window to the new position.
                
                screen.Clear(Color.Blue);
                window1.Draw(screen);
                screen.DrawFilledCircle(mousecolor, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y, 5);

                screen.Display();
                // Sleep for a short time to control animation speed.

            }
        }

    }
}
