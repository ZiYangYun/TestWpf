using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Renci.SshNet;

namespace SftpServerDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private SftpClient sftpClient;
        private string host = "Desktop-1nlg2t4";
        private string username = "TestSFTP";
        private string password = "000000";
        private string remotePath = $"/aaaaaa/sharefolder/test1.txt";

        public MainWindow()
        {
            InitializeComponent();



        }


        public void a(object state)
        {
            Task.Run(() =>
            {
                string localPath = $"D:\\local\\path\\{Guid.NewGuid()}.txt";
                using (var client = new SftpClient(host, username, password))
                {
                    client.Connect();
                    //// 上传文件
                    //using (var fileStream = new FileStream(localPath, FileMode.Open))
                    //{
                    //    client.UploadFile(fileStream, remotePath);
                    //}
                    //File.Create(localPath).Close();
                    // 下载文件
                    using (var fileStream = File.OpenWrite(localPath))
                    {
                        client.DownloadFile(remotePath, fileStream);
                    }

                    //sftpClient.Disconnect();
                }
            });
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            string host = "192.168.0.138";
            string username = "aaa";
            string password = "123456";
            string remotePath = "//DESKTOP-7KC2GF6/remote";
            string localPath = "C:\\local\\path";
            sftpHelp.UploadFtp(localPath, remotePath, host, username, password);
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            int workerThreads, ioThreads;
            ThreadPool.GetMaxThreads(out workerThreads, out ioThreads);
            ThreadPool.SetMaxThreads(workerThreads, 50);
            // 向线程池提交1000个任务
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(a);
            }
        }
    }
}
