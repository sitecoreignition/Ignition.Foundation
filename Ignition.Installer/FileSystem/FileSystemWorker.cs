using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.Installer.FileSystem
{
	public class FileSystemWorker
	{
		[DllImport("kernel32.dll")]
		static extern bool CreateSymbolicLink(
		string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

		private enum SymbolicLink
		{
			File = 0,
			Directory = 1
		}

		void Example()
		{
			var symbolicLink = @"c:\bar.txt";
			var fileName = @"c:\temp\foo.txt";

			using (var writer = File.CreateText(fileName))
			{
				writer.WriteLine("Hello World");
			}

			CreateSymbolicLink(symbolicLink, fileName, SymbolicLink.Directory);
		}
	}
}

