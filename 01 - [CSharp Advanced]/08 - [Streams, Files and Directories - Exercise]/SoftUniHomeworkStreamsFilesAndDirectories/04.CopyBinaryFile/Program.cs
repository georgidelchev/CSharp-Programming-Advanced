using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathRead = Path.Combine("CopyBinaryFile", "copyMe.png");
            var pathDir = Path.Combine("CopyBinaryFile", "picture.png");

            using (var write = new FileStream(pathDir, FileMode.Create))
            {
                using (var read = new FileStream(pathRead, FileMode.Open))
                {
                    var buffer = new byte[4096];

                    while (true)
                    {
                        var counter = read.Read(buffer, 0, buffer.Length);

                        if (counter == 0)
                        {
                            break;
                        }

                        write.Write(buffer);
                    }
                }
            }
        }
    }
}

