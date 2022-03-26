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
    public partial class Hwid : Window
    {
        public Hwid()
        {
            InitializeComponent();
            this.Show();
            hwidtxt.Text = "";
            if (File.Exists("userhwid.txt"))
            {
                File.Delete("hwid_compare.txt");
                File.Delete("hwidban.txt");
                File.Delete("userhwid.txt");
                File.Delete("clientip.txt");
                Process.Start("hwid.exe");
            }
            MessageBoxResult JPN = MessageBox.Show("啟動器開啟前會先收集你的電腦硬件資訊,請按下'確定''繼續", "hwid.exe", MessageBoxButton.OKCancel); //throw the agreement to user
            if (JPN == MessageBoxResult.Cancel)
            {
                MessageBox.Show("由於閣下不同意我們收集你的電腦硬件資訊,啟動器即會關閉", "hwid", MessageBoxButton.OK); //if result return failed
                Close();
            }
            else
            {
                verify();
            }
            //Fix Virtual Ram Overflow throw 0xffff

        }
        private void verify()
        {
            hwidtxt.Text = "清除舊有資料";
            if (File.Exists("userhwid.txt"))
            {
                File.Delete("hwid_compare.txt");
                File.Delete("userhwid.txt");
                File.Delete("clientip.txt");
                Process.Start("hwid.exe");
            }
            else
            {

            }
            hwidtxt.Text = "正在讀取hwid資料並進行驗證";
            //File Check_hwid and updater.exe
            Task.Delay(1500);
            Thread.Sleep(1500);
            //download file
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            /*
            WebClient webcom = new WebClient();
            string comparetxt = "https://drive.google.com/uc?export=download&id=12pCIm5H1pVj8YTCvE23FBkGmBiJUdUsx"; //hwidban.txt, normalserver_filereadheader
            webcom.DownloadFile(comparetxt, "hwidban.txt");
            */
             // 1/4/22 2022Q2 inuse
                  WebClient webcom = new WebClient();
                string comparetxt = "https://drive.google.com/uc?export=download&id=1JP0fB65r0nj1pRXYVp7gf3PtRAzUUttI"; //hwid_compare.txt , PaymentServer_FileReadHeader
                webcom.DownloadFile(comparetxt, "hwid_compare.txt");
            Task.Delay(1000);
            Thread.Sleep(1000);
            //download file
            // string[] bannedhwid = File.ReadAllLines("hwidban.txt"); //server
            if (File.Exists("userhwid.txt"))
            {
                if (File.Exists("hwid_compare.txt"))
                {

                }
                else
                {
                    hwidtxt.Text = "webliect_error_googledriver_return_403";
                    MessageBox.Show("你無法連接至Google Drive伺服器或被Google Drive拒絕連線,請等候15分鐘再點擊Launcher再次進入遊戲");
                    Close();
                }
            }
            else
            {
                hwidtxt.Text = "notfound_userhwid_planning_restart_hwid.exe";
                Task.Delay(1000);
                Thread.Sleep(1000);
            }
               // string[] serverip = File.ReadAllLines("ipban.txt"); //server
                string[] userhwid = File.ReadAllLines("userhwid.txt"); //client
                string[] comparehwid = File.ReadAllLines("hwid_compare.txt"); //PaymentServer_FileReadHeader

            foreach (string client in userhwid)
            {
                foreach (string compare in comparehwid)
                {
                    /*
                  foreach (string compare in bannedhwid)
                {
                    string hv = "Hyper-V";
                    string VM = "VMware";
                    //CheckVM
                    if (client.Contains(compare))
                    {
                        File.Delete("hwidban.txt");
                        hwidtxt.Text = "FailCompare";
                        MessageBox.Show("你因違反NeverLess遊戲伺服器規則而被管理員hwid封鎖,詳情請參讀NeverLess伺服器規則或在Discord開啟一個ticket並提供你的hwid (位於遊戲文件Bin內的userhwid.txt)", "hwid.exe");
                        Close();
                        return;
                    }
                    else
                    {
                        if (client.Contains(hv) || client.Contains(VM))
                        {
                            File.Delete("hwidban.txt");
                            hwidtxt.Text = "detectVMorHyperVnetwork";
                            MessageBox.Show("hwid.exe已檢測到你已經安裝或你正在運作虛擬機器在你的電腦上,根據NeverLess遊戲伺服器規則內已列明玩家不能使用Hyper-V或VMware的虛擬機器,詳情請參讀NeverLess伺服器規則!", "hwid.exe");
                            Close();
                            return;
                        }
                        else
                        {

                        }
                    }
                    //this is compare ban list
                    */
                    if (client.Contains(compare))
                    {
                        string hostname= System.Environment.GetEnvironmentVariable("COMPUTERNAME");
                        if (hostname.Contains(compare))
                        {
                            File.Delete("hwid_compare.txt");
                        }
                        else
                        {
                            hwidtxt.Text = "user_hwid_or_userhostname_not_compare";
                            File.Delete("hwid_compare.txt");
                            MessageBox.Show("由於此伺服器只限 NeverLess VIP/VVIP進入,你的hwid並沒有列入VIP伺服器的hwid上,因此你無法進入. 更多詳情請參考Discord的 'payment-and-donate'獲得更多資訊. 如你已經購買VVIP權限後無法進入伺服器,請在你的ticket上載你的userhwid.txt以及clientip.txt進行hwid註冊", "hwid.exe");
                            return;
                            Close();
                        }

                    }
                    else
                    {
                        hwidtxt.Text = "user_hwid_or_userhostname_not_compare";
                        MessageBox.Show("由於此伺服器只限 NeverLess VIP/VVIP進入,你的hwid並沒有列入VIP伺服器的hwid上,因此你無法進入. 更多詳情請參考Discord的 'payment-and-donate'獲得更多資訊. 如你已經購買VVIP權限後無法進入伺服器,請在你的ticket上載你的userhwid.txt以及clientip.txt進行hwid註冊", "hwid.exe");
                        return;
                        Close();
                    }
                }
            }
            //start launcher
            File.Delete("hwid_compare.txt");
            File.Delete("userhwid.txt");
            File.Delete("clientip.txt");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
/*
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
                    /*   foreach (string payment in comparehwid)
                       {
                           if (client.Contains(payment)
                            {

                            }
                            else
                             {
                                        MessageBox.Show("因NeverLess營運資金短缺,由4月1日起,NeverLess伺服器會向玩家收取 300元台幣 / 84元港幣 作為伺服器營運資金,玩家需要到Discord或點擊這個視窗進行付款,完成付款後請到提問區開啟一張ticket並上載你的userhwid.txt,clientip.txt並等待NeverLess管理員加入你的hwid資料後,即可再次進入伺服器", "hwid.exe"); //payment server msg
                                        Process.Start(new ProcessStartInfo
                                         {
                                                    FileName = "https://trade.i7391.com/GoodsDetail_S08-220326-0035256167.shtml",
                                                     UseShellExecute = true
                                         });
                                        return;
                                        Close();
                             }
                       }
                    */