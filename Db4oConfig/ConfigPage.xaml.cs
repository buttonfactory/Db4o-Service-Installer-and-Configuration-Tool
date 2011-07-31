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
using System.Xml;
using Db4oService.Classes;

namespace Db4oConfig
{
    /// <summary>
    /// Interaction logic for ConfigPage.xaml
    /// </summary>
    public partial class ConfigPage : Page
    {
        public ConfigPage()
        {
            InitializeComponent();
            ServerInfo info = new ServerInfo();
            txtFile.Text = info.File;
            txtPort.Text = info.Port.ToString();
            txtUser.Text = info.User;
            txtPass.Password = info.Pass;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            ServerInfo info = new ServerInfo();


            try
            {
                info.Host = "localhost";
                info.File = txtFile.Text;
                info.Port = Convert.ToInt32(txtPort.Text);
                info.User = txtUser.Text;
                if (txtPass.Password == "")
                {
                    info.Pass = "db4o";
                }
                else
                {
                    info.Pass = txtPass.Password;
                }
                info.createServerInfoXML();
                MessageBox.Show("Just created a new ServerInfo.xml settings file");
                HomePage home = new HomePage();
                this.NavigationService.Navigate(home);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           
        }
 
    }
}
