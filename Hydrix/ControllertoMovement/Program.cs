using System;
using SharpDX.DirectInput;
using System.Numerics;
using SharpDX.XInput;
using WindowsInput;
namespace CONT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Controller controller = new Controller(UserIndex.One);
            InputSimulator inputSimulator = new InputSimulator();

            while (true)
            {
                State state = controller.GetState();
                var gamepad = state.Gamepad;

                if (gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
                {
                    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
                }
            }
        }
    }
}