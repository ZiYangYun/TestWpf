using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SftpServerDemo
{
    public class sftpHelp
    {
        public static int DownloadFtp(string localFileName, string remoteFileName, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            try
            {
                using (SftpClient sftp = new SftpClient(ftpServerIP, ftpUserID, ftpPassword))
                {
                    sftp.Connect();

                    using (var file = File.OpenWrite(localFileName))
                    {
                        sftp.DownloadFile(remoteFileName, file);
                    }

                    sftp.Disconnect();
                    //Log.getInstace().WriteSysInfo($"下载文件{localFileName}成功", "info");
                    return 0;
                }
            }
            catch (Exception e)
            {
                //Log.getInstace().WriteSysInfo($"下载文件{localFileName}失败，原因：{e}", "err");
                Console.WriteLine($"下载失败，原因：{e}");
                return -2;
            }
        }

        public static int UploadFtp(string localFileName, string remoteFileName, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            try
            {
                using (SftpClient sftp = new SftpClient(ftpServerIP, 300, ftpUserID, ftpPassword))
                {
                    sftp.Connect();

                    using (var file = File.OpenWrite(localFileName))
                    {
                        sftp.UploadFile(file, remoteFileName);
                    }

                    sftp.Disconnect();
                    return 0;
                }
            }
            catch (Exception e)
            {
                //Log.getInstace().WriteSysInfo($"上传文件{localFileName}失败，原因：{e}", "err");
                Console.WriteLine($"上传失败，原因：{e}");
                return -2;
            }
        }
    }
}
