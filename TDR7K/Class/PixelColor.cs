using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TDR7K.Class
{
    class PixelColor
    {
        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary> 
        /// Gets the System.Drawing.Color from under the given position. 
        /// </summary> 
        /// <returns>The color value.</returns> 
        public static string Get(int x, int y)
        {
            IntPtr dc = GetWindowDC(WinGetHandle("BlueStacks App Player"));
            long color = GetPixel(dc, x, y);

            Color cc = Color.FromArgb((int)color);
            string hex = cc.B.ToString("X2") + cc.G.ToString("X2") + cc.R.ToString("X2");
            return hex;
        }
        public static IntPtr WinGetHandle(string wName)
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains(wName))
                    hWnd = pList.MainWindowHandle;
            return hWnd;
        }
    }
}
