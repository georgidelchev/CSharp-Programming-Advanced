using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("ZipAndExtract", "copyMe.png");
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dirPath = Path.Combine(desktopPath, "myZip.zip");

            using (var zipFile = ZipFile.Open(dirPath, ZipArchiveMode.Create))
            {
                zipFile.CreateEntryFromFile(path, "copyMe.png");
            }

            var extractPath = Path.Combine(desktopPath, "ExtractedZip");
            ZipFile.ExtractToDirectory(dirPath, extractPath);
        }
    }
}
