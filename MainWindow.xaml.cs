using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net;

namespace CSNPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           string[] serververion = File.ReadAllLines("version.txt");
            foreach (string msg in serververion)
            {
                vermsg.Text = $"遊戲版本: v.{msg}";
             } 
            
        }

            private void rules(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://docs.google.com/document/d/1JVvl6e6ufxgaoLU_fqHqfgBZzwA_WkIf/edit?usp=sharing&ouid=108461446636375036931&rtpof=true&sd=true",
                UseShellExecute = true
            });
        }

        //  private void startgame(object sender, MouseButtonEventArgs e)

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            verify();
        }

       
        private void verify()
        {
        }

        private void startgame(object sender, MouseButtonEventArgs e)
        {
            if ((bool)CheckBox.IsChecked)
            {

                if (File.Exists("CSOLauncher_Exe.exe"))
                {
                    if(File.Exists("CSOLauncher.dll"))
                    {
                        Process.Start("CSOLauncher_Exe.exe", "-ip 26.5.86.41 -port 20022");
                        Close();
                    }
                }
                else
                {
                    WebClient NGS = new WebClient();
                    string file = "NGSBypass.exe";
                    string ads = "https://cdn.discordapp.com/attachments/816288519496138802/944063917871734805/CSOLauncher_Exe.exe";
                    NGS.DownloadFile(ads, file);
                     if (File.Exists("CSOLauncher.dll"))
                    {
                        Process.Start("CSOLauncher_Exe.exe", "-ip 26.5.86.41 -port 20022");
                        Close();
                    }
                     else
                    {
                        WebClient DLL = new WebClient();
                        string Dllfile = "CSOLauncher.dll";
                        string ads2 = "https://cdn.discordapp.com/attachments/816288519496138802/957082655814451230/CSOLauncher.dll";
                        NGS.DownloadFile(ads, file);
                        Process.Start("CSOLauncher_Exe.exe", "-ip 26.5.86.41 -port 20022");
                        Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("請先同意伺服器規則", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                using (StreamWriter log = new StreamWriter("Logfile.txt"))
                {
                    log.WriteLine($"{ DateTime.Now} : FailOnPressServerRule");
                }
            }
        }

        /*
        //OpenVPN By Nekomeow
                    if ((bool)CheckBox.IsChecked)
            {
                
                if (File.Exists("cstrike-online.exe"))
                {
                    Process.Start("cstrike-online.exe" , "-ip 26.5.86.41 -port 20214");
                    Process.Start("Corsshair.exe");
                    Close();
                }
                else
                {
                    WebClient csodownloadhearder = new WebClient();
                    string address = "https://cdn.discordapp.com/attachments/816288519496138802/950236603454980226/cstrike-online.exe";
                    csodownloadhearder.DownloadFile(address, "cstrike-online.exe");
                    Process.Start("cstrike-online.exe", "-ip 26.5.86.41 -port 20214");
                    Process.Start("Corsshair.exe");
                    Close();
                }

            }
            else
            {
                MessageBox.Show("請先同意伺服器規則", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                using (StreamWriter log = new StreamWriter("Logfile.txt"))
                {
                    log.WriteLine($"{ DateTime.Now} : FailOnPressServerRule");
                }
            }
        }
        //OpenVPN bool, .net5 connection via the server
        */


        private void ExitLauncher(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("是否要退出？", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                File.Delete("hwid_compare.txt");
                File.Delete("userhwid.txt");
                File.Delete("clientip.txt");
                Close();

            }
        }

    private void nerverless(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/TeamNeverLess/",
                UseShellExecute = true
            });
        }

        private void donate(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://discord.com/channels/786603618849259561/844936070784745492/876514051826548737",
                UseShellExecute = true
            });
        }

        private void nekopaypal(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.paypal.com/paypalme/nkmeow",
                UseShellExecute = true
            });
        }
    }
    }
