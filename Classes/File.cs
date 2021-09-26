using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzLauncher.Classes
{
    class File
    {

        public static System.Linq.IOrderedEnumerable<string> listFiles(string path)
        {
         
            var filePaths = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).OrderByDescending(d => new FileInfo(d).LastAccessTimeUtc);
            return filePaths;
        }

        public static System.Drawing.Bitmap getFileIcon(string extension)
        {
            switch (extension)
            {
                case ".torrent":
                    return Properties.Resources.icons8_qb_480px;

                case ".zip":
                    return Properties.Resources.icons8_zip_48px;

                case ".rar":
                   return Properties.Resources.icons8_rar_48px;

                default:
                    return Properties.Resources.icons8_file_48px;


            }
        }

    }
}
