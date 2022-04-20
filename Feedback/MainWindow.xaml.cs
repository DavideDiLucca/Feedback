using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Feedback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string host = @"139.162.174.212";
        string username = "lefftp";
        string password = "wic@L3F";

        public MainWindow()
        {
            InitializeComponent();
            OpenLink();
        }

        private void OpenLink()
        {
            string feedbackDirectory = @"/home/lefftp/Feedback/link.txt";
            using (var sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();

                try
                {
                    using (var remoteFileStream = sftp.OpenRead(feedbackDirectory))
                    {
                        using (var reader = new StreamReader(remoteFileStream))
                        {
                            string link = reader.ReadLine();
                            System.Diagnostics.Process.Start(link);
                            this.Close();
                            //MessageBox.Show(link);
                        }
                    }
                }
                finally
                {
                    sftp.Disconnect();
                }
            }
        }
    }
}
