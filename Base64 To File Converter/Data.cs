using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base24_To_File_Converter
{
    public class Data:IDisposable
    {

        public static string GetNewFile(string path)
        {
            string fileName = "file";
            string ext = ".ext";

            int fileIndex = 0;

            string newFile = fileName + ext;
            while (System.IO.File.Exists(newFile))
            {
                fileIndex++;
                newFile = fileName + fileIndex + ext;
            }
            return newFile;
        }

        public Data()
        {

        }

        public void Dispose()
        {

        }

        internal bool SaveFile(string fileName,string data)
        {
            bool result = false;

            byte[] bytes = Convert.FromBase64String(data);
            string fileData = Encoding.UTF8.GetString(bytes);

            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            Array.Clear(bytes, 0, bytes.Length);


            return result;
        }
    }

}
