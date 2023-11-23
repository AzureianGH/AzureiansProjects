using Cosmos.Core.IOGroup;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Sys = Cosmos.System;

namespace AzurOS
{
    public class Kernel : Sys.Kernel
    {
        [ManifestResourceStream(ResourceName = "AzurOS.Images.cursor.bmp")]
        static byte[] cursorImage;
        Bitmap cursorbit;
        Canvas screen;
        [ManifestResourceStream(ResourceName = "AzurOS.Images.Azuros.bmp")]
        static byte[] azurosstartImage;
        Bitmap azurosstartbit;
        static int starty1 = 400;
        double angle = 0; // Angle to control rotation
        double rotationSpeed = 1.0; // Adjust rotation speed as needed
        int circleRadius = 30; // Adjust the radius of the circle
        int cutoutAngle = 90; // Angle for the cut-out effect
        Taskbar taskbar;
        public GUIManager guiManager;

        protected override void BeforeRun()
        {
            System.Console.Clear();
            mDebugger.Send("Cleared Screen");
            screen = FullScreenCanvas.GetFullScreenCanvas();
            mDebugger.Send("Got Screen");
            screen.Mode = new Mode(1920, 1080, ColorDepth.ColorDepth32);
            mDebugger.Send("Set Resolution");
            mDebugger.Send("Image Length: " + azurosstartImage.Length);
            azurosstartbit = new Bitmap(azurosstartImage);
            cursorbit = new Bitmap(cursorImage);
            mDebugger.Send("Set Image");
            screen.Clear();
            mDebugger.Send("Cleared Screen");
            taskbar = new Taskbar(0, 1050, (int)screen.Mode.Width, 30, Color.FromArgb(53, 53, 53));
            MouseManager.ScreenWidth = (uint)screen.Mode.Width;
            MouseManager.ScreenHeight = (uint)screen.Mode.Height;
            MouseManager.MouseSensitivity = 0.5f;
            MouseManager.X = (uint)screen.Mode.Width / 2;
            MouseManager.Y = (uint)screen.Mode.Height / 2;
            //guiManager = new GUIManager();
        }
        public struct Button
        {
            public Action action;
            public int x1;
            public int x2;
            public int y1;
            public int y2;
            public Color color;
            public Button(int x1, int y1, int x2, int y2, Action action, Color color)
            {
                this.x1 = x1;
                this.x2 = x2;
                this.y1 = y1;
                this.y2 = y2;
                this.action = action;
                this.color = color;
            }
        }
        public class GUIManager
        {
            public Button[] buttons;
            public void DrawButtons(Canvas screen, Button[] _buttons)
            {
                foreach (Button button in _buttons)
                {
                    screen.DrawFilledRectangle(button.color, button.x1, button.y1, button.x2, button.y2);
                    buttons.Append(button);
                }
            }
            public void CheckButtons()
            {
                foreach (Button button in buttons)
                {
                    if (MouseManager.X >= button.x1 && MouseManager.X <= button.x2 && MouseManager.Y >= button.y1 && MouseManager.Y <= button.y2 && Sys.MouseManager.MouseState == Sys.MouseState.Left)
                    {
                        button.action();
                    }
                }
            }
            public void ClearButtons()
            {
                //delete all buttons in the buttons array
                Array.Clear(buttons);
            }
            public void Draw(Canvas screen, Button[] buttons)
            {
                DrawButtons(screen, buttons);
                CheckButtons();
                ClearButtons();
            }
        }
        protected override void Run()
        {
            screen.DrawImage(azurosstartbit, 0, 0);
            taskbar.Draw(screen);
            screen.DrawImageAlpha(cursorbit, (int)MouseManager.X, (int)MouseManager.Y);
            //guiManager.DrawButtons(screen, new Button[] { new Button(0, 0, 100, 100, () => { mDebugger.Send("Button Pressed"); }, Color.Red) });
            screen.Display();
            screen.Clear();
            //guiManager.ClearButtons();
            //if ctrl alt delete, restart
            if (KeyboardManager.ControlPressed && KeyboardManager.AltPressed && KeyboardManager.NumLock)
            {
                Power.Reboot();
            }
        }
        public class Taskbar
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public Color color;
            public Taskbar(int x, int y, int width, int height, Color color)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
                this.color = color;
            }
            public void Draw(Canvas screen)
            {
                screen.DrawFilledRectangle(color, x, y, width, height);
            }
        }
    }
}
