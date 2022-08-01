using System.Security.Cryptography;
using System.Text;

namespace MuayThaiApp.Tools
{
    public class Md5Helper
    {
        #region Patron de Diseño
        private static Md5Helper _instance;
        private static readonly object _instanceLock = new object();
        public static Md5Helper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                            _instance = new Md5Helper();
                    }
                }
                return _instance;
            }
        }
        #endregion
        public string PasswordMd5Hash(string Password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Password));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
