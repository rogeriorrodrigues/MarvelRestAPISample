using System;
using System.Security;

namespace MarvelApp
{
	public class Settings
	{
		public Settings()
		{
		}

		public static String GetTimestamp(DateTime value)
		{
			return value.ToString("yyyyMMddHHmmssffff");
		}

		public static string stamp = GetTimestamp(DateTime.Now);


		public static string timestamp { get { return stamp; } }


		public static string publicKey = "67cd8f1ba8a3d486d99be05962003bab";
		public static string privateKey = "e189b1a4c63ca463f1730425f032aba31ed6e20a";


		static string md5 = EasyEncryption.MD5.ComputeMD5Hash(stamp + privateKey + publicKey);

		public static string hash { get { return md5; } }

	}
}
