
using System;
using System.Runtime.InteropServices;

namespace Win32_API
{
	internal struct LASTINPUTINFO 
	{
		public uint cbSize;

		public uint dwTime;
	}

	/// <summary>
	/// Summary description for Win32.
	/// </summary>
	public class Win32
	{
		[DllImport("User32.dll")]
		public static extern bool LockWorkStation();

		[DllImport("User32.dll")]
		private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);		

		[DllImport("Kernel32.dll")]
		private static extern uint GetLastError();
	
		public static uint GetIdleTime()
		{
			LASTINPUTINFO lastInPut = new LASTINPUTINFO();
			lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
			GetLastInputInfo(ref lastInPut);

			return ( (uint)Environment.TickCount - lastInPut.dwTime);
		}

		public static long GetTickCount()
		{
			return Environment.TickCount;
		}

		public static long GetLastInputTime()
		{
			LASTINPUTINFO lastInPut = new LASTINPUTINFO();
			lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
			if (!GetLastInputInfo(ref lastInPut))
			{
				throw new Exception(GetLastError().ToString());
			}
							
			return lastInPut.dwTime;
		}
        public static int GetIntLastInputTime()
        {
            int idletime = 0;
            idletime = 0;
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            lastInPut.dwTime = 0;

            if (GetLastInputInfo(ref lastInPut))
            {
                var tickcount = GetTickCount();
                idletime = Convert.ToInt32(lastInPut.dwTime);
            }

            if (idletime != 0)
            {
                return idletime / 1000;
            }
            else
            {
                return 0;
            } 
        }

	}

}
