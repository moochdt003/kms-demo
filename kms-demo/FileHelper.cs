using System;
namespace kms_demo
{
	public static class FileHelper
	{
		public static MemoryStream FileToMemoryStream(string filePath)
		{
			var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			var ms = new MemoryStream();
			fileStream.CopyTo(ms);
			return ms;
		}

		public static byte[] FileToBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		public static void WriteToFile(string fileName, byte[] byteArray)
		{
			using var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			fileStream.Write(byteArray, 0, byteArray.Length);
		}

	}
}

