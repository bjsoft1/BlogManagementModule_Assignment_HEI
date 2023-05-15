using System.Security.Cryptography;
using System.Text;

namespace BlogManagementModule.Constants.SystemClass
{
    public class Encriptionystem
    {
        public static string EncryptText(string Input, string EncriptionKey)
        {
            if (Input == null)
                return "";

            string Text = Input;
            string EncryptionKey = ((EncriptionKey == null ? "" : EncriptionKey.Trim()) + "FJK#$UI#JKDFJK#UI$");
            byte[] clearBytes = Encoding.BigEndianUnicode.GetBytes(Text.Trim());
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x60, 0x51, 0x60, 0x9d, 0x4f, 0xdd, 0x34, 0x14, 0x86, 0x65, 0x65, 0x61, 0x0a });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    Text = Convert.ToBase64String(ms.ToArray());
                }
            }
            return Text.Trim().ToLower() == Input.Trim().ToLower() ? "Nlitsolutions-nlit.sol3@gmail.com" : Text;
        }
        public static string DecryptText(string Input, string EncriptionKey)
        {
            if (Input == null || Input.Trim().Length <= 4)
                return "";

            string Text = Input;
            string EncryptionKey = ((EncriptionKey == null ? "" : EncriptionKey.Trim()) + "FJK#$UI#JKDFJK#UI$");
            try
            {
                Text = Text.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(Text);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x60, 0x51, 0x60, 0x9d, 0x4f, 0xdd, 0x34, 0x14, 0x86, 0x65, 0x65, 0x61, 0x0a });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        Text = Encoding.BigEndianUnicode.GetString(ms.ToArray());
                    }
                }
            }
            catch
            {
                return "";
            }
            return Text;
        }
    }
}
