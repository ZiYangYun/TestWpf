using System;
using System.IO;

namespace Wipe
{
    class Program
    {
        static void Main(string[] args)
        {
            Wipe(@"C:\Users\。\Desktop\Data");
            Console.ReadKey();
        }
        public static void Wipe(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo item in fileinfo)
            {
                if (item is DirectoryInfo)
                {
                    DirectoryInfo subdir = new DirectoryInfo(item.FullName);
                    subdir.Delete(true);
                }
            }
        }
    }
}
