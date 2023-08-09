using System.Security.Cryptography;
using System.Text;

namespace PracticaWeb.Data.Resorces
{
	public class Utilidades
	{
		public static string EncryptClave(string password)
		{
			StringBuilder sb = new StringBuilder();
			using (SHA256 hash = SHA256Managed.Create())
			{
				Encoding enc = Encoding.UTF8;
				byte[] res = hash.ComputeHash(enc.GetBytes(password));
				foreach (byte b in res)
				{
					sb.Append(b.ToString("x2"));
				}
			}
			return sb.ToString();
		}
	}
}
