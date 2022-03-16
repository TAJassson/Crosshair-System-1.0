using CSNPS;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace CSCPS
{
    /// <summary>
    /// login.xaml 的互動邏輯
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void start(object sender, MouseButtonEventArgs e)
        {
            string ac = user_login.Text.ToString();
            string pw = user_password.Password.ToString();
            if (user_login.Text == "")
            {
                MessageBox.Show("請輸入帳號", "login", MessageBoxButton.OK);
                return;
            }
            if (user_password.Password == "")
            {
                MessageBox.Show("請輸入密碼", "login", MessageBoxButton.OK);
                return;
            }
            string loginnz = $"-ip 26.5.86.41 -port 20020 -login {ac} -password {pw} -disableauthui -dev ";
            Process.Start("NGSBypass.exe", loginnz);
            Close();
        }

        private void exitapp(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("是否要退出？", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
