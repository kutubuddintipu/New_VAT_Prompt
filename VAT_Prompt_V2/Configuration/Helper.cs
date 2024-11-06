using System.Security.Cryptography;

namespace VAT_Prompt_V2.Configuration
{
    public static class Helper
    {
        public static string EncryptString(string str, string key)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(str);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }

        public static string DecryptString(string str, string key)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(key));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToDecrypt = Convert.FromBase64String(str);
            // Step 5. Bat dau giai ma chuoi
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch (Exception)
            {
                Results = DataToDecrypt;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return UTF8.GetString(Results);
        }

        public static Dictionary<string, string> GetRequestInfo(IHttpContextAccessor accessor, RouteData routeData)
        {
            string ipAddress = accessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            string accessToken = string.Empty;
            if (accessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                accessToken = accessor.HttpContext.Request.Headers["Authorization"].ToString();
            }
            string controllerName = routeData.Values["controller"].ToString();
            string actionName = routeData.Values["action"].ToString();
            string methodType = accessor.HttpContext.Request.Method;
            string scheme = accessor.HttpContext.Request.Scheme;
            string host = accessor.HttpContext.Request.Host.Value;
            string path = accessor.HttpContext.Request.Path.Value;

            Dictionary<string, string> reqInfos = new Dictionary<string, string>()
            {
                {"ipAddress", ipAddress},
                {"accessToken", accessToken},
                {"methodType", methodType},
                {"controllerName", controllerName},
                {"actionName", actionName},
                {"scheme", scheme},
                {"host", host},
                {"path", path},
            };

            return reqInfos;
        }
    }
}