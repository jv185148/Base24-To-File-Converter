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

        internal bool SaveFile(string fileName)
        {
            bool result = false;

            

            return result;
        }
    }

}
