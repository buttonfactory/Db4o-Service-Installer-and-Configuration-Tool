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
using System.ServiceProcess;
using Db4oService.Classes;

namespace Db4oConfig
{
    /// <summary>
    /// Interaction logic for StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        public StatusPage()
        {
            InitializeComponent();

            try
            {
                ServerInfo info = new ServerInfo();
                string status;

                status = "Configuation: \r\n";
                status = status + "\r\n";
                status = status + "Host: " + info.Host + "\r\n";
                status = status + "With file: " + info.File + "\r\n";
                status = status + "On port: " + info.Port.ToString() + "\r\n";
                status = status + "With user: " + info.User + "\r\n";

                status = status + "\r\n";
                status = status + "\r\n";

                ServiceController byServiceName = new ServiceController();
                byServiceName.ServiceName = "Db4o";

                if (byServiceName.Status == ServiceControllerStatus.Running)
                    status = status + "The service is currently running.";

                if (byServiceName.Status == ServiceControllerStatus.Stopped)
                    status = status + "The service is currently stopped.";

                if (byServiceName.Status == ServiceControllerStatus.StopPending)
                    status = status + "The service is currently pending to stop.";

                textStatus.Text = status;
            } catch (Exception ex) {

                textStatus.Text = ex.Message;
            }


        }
    }
}
