using System.IO;

namespace Ignition.Foundation.Core.Models.System
{
	public interface IFile
	{
		string MimeType { get; set; }
		string Icon { get; set; }
		Stream Blob { get; set; }
		string Extension { get; set; }
		int Size { get; set; }
	}
}
