using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Management;
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
            else
            {

            }
            if (File.Exists("hwidban.txt"))
            {
                File.Delete("hwidban.txt");
                File.Delete("sg14version.txt");
                File.Delete("hwid_compare.txt");
                File.Delete("userhwid.txt"); 
            }
            //JPN
            //File Check_hwid and updater.exe
            Process.Start("hwid.exe");
            msg.Text = "正在讀取hwid資料並進行驗證";
            Task.Delay(2500);
            Thread.Sleep(2500);
            //download file
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebClient downloadverison = new WebClient();
            downloadverison.DownloadFile("https://drive.google.com/uc?export=download&id=1AfoTJ3AsG36_a52O0Hr-X0fiaYPt4hkt", "sg14version.txt");
            Task.Delay(1000);
            Thread.Sleep(1000);
            WebClient webcom = new WebClient();
            string comparetxt = "https://drive.google.com/uc?export=download&id=12pCIm5H1pVj8YTCvE23FBkGmBiJUdUsx"; //hwidban.txt
            webcom.DownloadFile(comparetxt, "hwidban.txt");
            /*
            WebClient webcom = new WebClient();
            string comparetxt = "https://drive.google.com/uc?export=download&id=1eAZgKtbPc4SA69mPm8Ed-wusSGectWZY"; //hwid_compare.txt
            webcom.DownloadFile(comparetxt, "hwid_compare.txt");
            */
            //download file
            string[] bannedhwid = File.ReadAllLines("hwidban.txt"); //server
            //  string[] serverip = File.ReadAllLines("ipban.txt"); //server
            string[] userhwid = File.ReadAllLines("userhwid.txt"); //client
            // string[] comparehwid = File.ReadAllLines("hwid_compare.txt"); //PaymentServer_FileReadHeader
            Task.Delay(1000);
            Thread.Sleep(1000);
            //readfile
            foreach (string client in userhwid)
            {
                foreach (string compare in bannedhwid)
                {
                        string hv = "Hyper-V";
                        string VM = "VMware";
                    if (client.Contains(compare))
                    {
                        msg.Text = "FailCompare";
                        MessageBox.Show("你因違反NeverLess遊戲伺服器規則而被管理員hwid封鎖,詳情請參讀NeverLess伺服器規則或在Discord開啟一個ticket並提供你的hwid (位於遊戲文件Bin內的userhwid.txt)", "hwid.exe");
                        File.Delete("hwid_compare.txt"); //hwid_compare.txt
                        File.Delete("hwidban.txt");
                        File.Delete("sg14version.txt");
                        Close();
                        return;
                    }
                    else
                    {
                        if (client.Contains(hv) || client.Contains(VM))
                        {
                            msg.Text = "detectVMorHyperVnetwork";
                            MessageBox.Show("hwid.exe已檢測到你已經安裝或你正在運作虛擬機器在你的電腦上,根據NeverLess遊戲伺服器規則內已列明玩家不能使用Hyper-V或VMware的虛擬機器,詳情請參讀NeverLess伺服器規則!", "hwid.exe");
                            File.Delete("hwid_compare.txt"); //hwid_compare.txt
                            File.Delete("hwidban.txt");
                            File.Delete("sg14version.txt");
                            Close();
                            return;
                        }
                        else
                        {

                        }
                    }
                    }
                }
            
                Task.Delay(1000);
                Thread.Sleep(1000);
                 if (File.Exists("version.txt"))
                  {

                  }
                        else
                        {
                            MessageBox.Show("即將更新client,切勿關閉Update的CMD視窗並等到完成更新. 請按下 確定' 進行更新!", "Updater.exe");
                            Process.Start("Updater.exe");
                            Close();
                        }
                        if (File.Exists("pingscan.exe"))
                        {
                            Process.Start("pingscan.exe");
                        }
                        else
                        {
                            string[] clientv = File.ReadAllLines("version.txt");
                            string[] sv = File.ReadAllLines("sg14version.txt");
                foreach (string cv in clientv)
                {
                    foreach (string serverv in sv)
                    {
                        if (cv == serverv)
                        {
                            msg.Text = $"你的遊戲版本是 v.'{cv}', 最新版本為 v.'{serverv}'.可以開始遊戲";
                            MainWindow launcherwindow = new MainWindow();
                            launcherwindow.Show();
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("即將更新client,切勿關閉Update的CMD視窗並等到完成更新. 請按下 確定' 進行更新!", "Updater.exe");
                            msg.Text = "即將更新client,切勿關閉Update的CMD視窗並等到完成更新";
                            Process.Start("Updater.exe");
                            File.Delete("userhwid.txt");
                            File.Delete("ipban.txt");
                            File.Delete("hwidban.txt");
                            Close();
                        }
                    }
                }
            }
        }
        }
    }

/*
else
{
   if (client == hv || client == VM)
    {
        msg.Text = "FailCompare";
        MessageBox.Show("hwid.exe因檢測到你的虛擬機器在運行,詳情請參讀NeverLess伺服器規則或在Discord開啟一個ticket並提供你的hwid (位於遊戲文件Bin內的userhwid.txt)", "hwid.exe");
        File.Delete("hwid_compare.txt"); //hwid_compare.txt
        File.Delete("hwidban.txt");
        File.Delete("sg14version.txt");
        Close();
    }
    else
    {
        Task.Delay(1000);
        Thread.Sleep(1000);
        if (File.Exists("version.txt"))
        {
            MessageBox.Show("FileExists_version.txt");
        }
        else
        {
            MessageBox.Show("即將更新client,切勿關閉Update的CMD視窗並等到完成更新. 請按下 確定' 進行更新!", "Updater.exe");
            Process.Start("Updater.exe");
            Close();
        }
        if (File.Exists("pingscan.exe"))
        {
            MessageBox.Show("伺服器訊息: 因伺服器檢測到你的異常行為並需要進行區域網掃瞄,請按下'OK'來進行pingscan.*區域網掃瞄需時3-4分鐘,期間CPU或可能提高使用量並切勿關閉pingscan畫面* ", "NL_ServerRequest_Networkscan_hwid.exe", MessageBoxButton.OK);
            Process.Start("pingscan.exe");
        }
        string[] clientv = File.ReadAllLines("version.txt");
        string[] sv = File.ReadAllLines("sg14version.txt");
        foreach (string cv in clientv)
        {
            foreach (string serverv in sv)
            {
                if (cv == serverv)
                {
                    msg.Text = $"你的遊戲版本是 v.'{cv}', 最新版本為 v.'{serverv}'.可以開始遊戲";
                    MainWindow launcherwindow = new MainWindow();
                    launcherwindow.Show();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Update_request");
                    MessageBox.Show("即將更新client,切勿關閉Update的CMD視窗並等到完成更新. 請按下 確定' 進行更新!", "Updater.exe");
                    msg.Text = "即將更新client,切勿關閉Update的CMD視窗並等到完成更新";
                    Process.Start("Updater.exe");
                    File.Delete("userhwid.txt");
                    File.Delete("ipban.txt");
                    File.Delete("hwidban.txt");
                    Close();
                }
            }
        }
    }
}
}
}
}
}
}
*/

