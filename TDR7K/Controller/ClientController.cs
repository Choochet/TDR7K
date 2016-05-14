using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TDR7K.Model;
using TDR7K.WinAPI;

namespace TDR7K.Controller
{
    public static class ClientController
    {
        const string appver = "WindowsForms10.Window.8.app.0.1ca0192_r35_ad1";
        const string appname = "BlueStacks App Player";
        public static IntPtr GetClient()
       {
           var WndSearcher = new WndSearcher();
           var getwin = WndSearcher.SearchForWindow(appver, appname);
           return getwin;
       }
        public static int GetProcessID(IntPtr Client)
        {
            int processID = 0;
            int pID = GetWindowThreadProcessId(Client, out processID);
            return processID;
        }
        public static Rectangle GetWndRect(IntPtr client)
       {
           Rectangle rect = new Rectangle();
           var getpos = GetWindowRect(client, out rect);
           return rect;
       }
        public static Bitmap GetBitmap(Rectangle bonds)
       {
           Bitmap bmp = new Bitmap(bonds.Width, bonds.Height);
           return bmp;
       }

       [DllImport("user32.dll", SetLastError = true)]
       //public static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);
       public static extern bool GetWindowRect(IntPtr hwnd, out Rectangle lpRect);
       [DllImport("user32.dll")]
       public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
    
       [DllImport("user32.dll")]
       static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
    }
}
