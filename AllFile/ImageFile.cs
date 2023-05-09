using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.AllFile
{
    class ImageFileService
    {
        public static string GetBitmapImageMD5(BitmapImage bitmapImage)
        {

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (var fileStream = new System.IO.FileStream(System.Environment.CurrentDirectory + "/Logs/Temp", System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
            return SHA256File(System.Environment.CurrentDirectory + "/Logs/Temp");
        }
        public static string SaveBitmapImage(BitmapImage bitmapImage)
        {

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (var fileStream = new System.IO.FileStream(System.Environment.CurrentDirectory + "/Logs/Temp", System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
            string fileName = SHA256File(System.Environment.CurrentDirectory + "/Logs/Temp");

            if (string.Equals(fileName, "04B2B0179BAF8257BF2318BE65B16B0F"))
            {
                return "ActorNull";
            }

            if (string.Equals(fileName, "2B19DF69FA567C605F6A8007C1B93D33")) 
            {
                return "ClipNull";
            }
            if (string.Equals(fileName, "38170E3A6583E6AFAB8410B70F8AD44B"))
            {
                return "CompanyNull";
            }

            if (!new FileInfo(System.Environment.CurrentDirectory + "/Logs/" + fileName).Exists)
                new FileInfo(System.Environment.CurrentDirectory + "/Logs/Temp").MoveTo(System.Environment.CurrentDirectory + "/Logs/" + fileName);

            return fileName;


        }

        public static string SHA256File(string fileName)
        {
            return HashFile(fileName, "md5");
        }

        /// <summary> 
        /// 计算文件的哈希值 
        /// </summary> 
        /// <param name="fileName">要计算哈希值的文件名和路径</param> 
        /// <param name="algName">算法:sha1,md5</param> 
        /// <returns>哈希值16进制字符串</returns> 
        public static string HashFile(string fileName, string algName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }


        /// <summary> 
        /// 字节数组转换为16进制表示的字符串 
        /// </summary> 
        public static string ByteArrayToHexString(byte[] buf)
        {
            string returnStr = "";
            if (buf != null)
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    returnStr += buf[i].ToString("X2");
                }
            }
            return returnStr;
        }


        /// <summary> 
        /// 计算哈希值 
        /// </summary> 
        /// <param name="stream">要计算哈希值的 Stream</param> 
        /// <param name="algName">算法:sha1,md5</param> 
        /// <returns>哈希值字节数组</returns> 
        public static byte[] HashData(Stream stream, string algName)
        {
            HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }
            if (string.Compare(algName, "sha256", true) == 0)
            {
                algorithm = SHA256.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha256 或 md5");
                }
                algorithm = MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        public static BitmapImage GetImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            if (File.Exists(imagePath))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                using (Stream ms = new MemoryStream(File.ReadAllBytes(imagePath)))
                {
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }
            return bitmap;
        }


    }
}
