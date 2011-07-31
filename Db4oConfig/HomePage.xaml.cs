using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Db4oConfig
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }


        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "installutil.exe";
            proc.StartInfo.Arguments = "Db4oService.exe";
            proc.Start();

        }

        private void btnUninstall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "installutil.exe";
                proc.StartInfo.Arguments = "-u Db4oService.exe";
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            
            proc.StartInfo.FileName = "net.exe";
            proc.StartInfo.Arguments = "start db4o";
            proc.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "net.exe";
            proc.StartInfo.Arguments = "stop db4o";
            proc.Start();
        }

        private void btnConf_Click(object sender, RoutedEventArgs e)
        {
            ConfigPage configPage = new ConfigPage();
            this.NavigationService.Navigate(configPage);

        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            StatusPage statusPage = new StatusPage();
            this.NavigationService.Navigate(statusPage);
        }
       
    }
}
