using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
namespace CSNPS
{
    /// <summary>
    /// hwid.xaml 的互動邏輯
    /// </summary>
    public partial class hwid : Window
    {
        public hwid()
        {
            InitializeComponent();
            this.Show();
            //JPN
            MessageBoxResult JPN = MessageBox.Show("啟動器開啟前會先收集你的電腦硬件資訊,請按下'確定''繼續", "hwid.exe", MessageBoxButton.OKCancel); //throw the agreement to user
            if (JPN == MessageBoxResult.Cancel)
            {
                MessageBox.Show("由於閣下不同意我們收集你的電腦硬件資訊,啟動器即會關閉", "hwid", MessageBoxButton.OK); //if result return failed
                Close();
            }
            //JPN
            //File Check_hwid and updater.exe
            msg.Text = "正在讀取hwid資料並進行驗證";
            if (File.Exists("userhwid.txt"))
            {
                File.Delete("hwidban.txt");
                File.Decrypt("userhwid.txt");
                File.Decrypt("clientip.txt");
            }
            Task.Delay(1000);
            Thread.Sleep(1000);
            Process.Start("hwid.exe");
            Task.Delay(1000);
            Thread.Sleep(1000);
            //download file
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebClient webcom = new WebClient();
            string comparetxt = "https://drive.google.com/uc?export=download&id=12pCIm5H1pVj8YTCvE23FBkGmBiJUdUsx"; //hwidban.txt
            webcom.DownloadFile(comparetxt, "hwidban.txt");
            /*
                  WebClient webcom = new WebClient();
                string comparetxt = "https://drive.google.com/uc?export=download&id=1eAZgKtbPc4SA69mPm8Ed-wusSGectWZY"; //hwid_compare.txt
                webcom.DownloadFile(comparetxt, "hwid_compare.txt");
                */
            Task.Delay(1000);
            Thread.Sleep(1000);
            //download file
            string[] bannedhwid = File.ReadAllLines("hwidban.txt"); //server
            //  string[] serverip = File.ReadAllLines("ipban.txt"); //server
            string[] userhwid = File.ReadAllLines("userhwid.txt"); //client
            // string[] comparehwid = File.ReadAllLines("hwid_compare.txt"); //PaymentServer_FileReadHeader
            //readfile

            foreach (string client in userhwid)
            {
                foreach (string compare in bannedhwid)
                {
                    if (client.Contains("DESKTOP-8801E42") || client.Contains("AGI512G16AI198  0100_0000_0000_0000. "))
                    {
                        MainWindow mainWindow1 = new MainWindow();
                        mainWindow1.Show();
                        this.Hide();
                        File.Delete("hwidban.txt");
                        File.Decrypt("userhwid.txt");
                        File.Decrypt("clientip.txt");
                    }
                     else
                    {

                    }
                    string hv = "Hyper-V";
                    string VM = "VMware";
                    if (client.Contains(compare))
                    {
                        msg.Text = "FailCompare";
                        MessageBox.Show("你因違反NeverLess遊戲伺服器規則而被管理員hwid封鎖,詳情請參讀NeverLess伺服器規則或在Discord開啟一個ticket並提供你的hwid (位於遊戲文件Bin內的userhwid.txt)", "hwid.exe");
                        File.Delete("hwidban.txt");
                        Close();
                        return;
                    }
                    else
                    {
                        if (client.Contains(hv) || client.Contains(VM))
                        {
                            msg.Text = "detectVMorHyperVnetwork";
                            MessageBox.Show("hwid.exe已檢測到你已經安裝或你正在運作虛擬機器在你的電腦上,根據NeverLess遊戲伺服器規則內已列明玩家不能使用Hyper-V或VMware的虛擬機器,詳情請參讀NeverLess伺服器規則!", "hwid.exe");
                            Close();
                            return;
                        }
                        else
                        {

                        }
                    }
                        
                }
            }
            //start launcher
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
            File.Delete("hwidban.txt");
            File.Decrypt("userhwid.txt");
            File.Decrypt("clientip.txt");
        }
    }
}

