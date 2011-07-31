using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.CS.Config;
using System.Threading;
using Db4objects.Db4o.Messaging;
using Db4objects.Db4o;
using Db4oService.Classes;
using System.IO;
using System.Reflection;

namespace Db4oService
{
    public partial class Db4oService : ServiceBase
    {
        private Thread workerThread;

        public Db4oService()
        {
            InitializeComponent();
        }

        public void StartServert()
        {
            System.Threading.Thread.Sleep(10000);
           
            ServerInfo info = new ServerInfo();


                try
                {
                    string filepath =
                        Path.GetDirectoryName(
                     Assembly.GetAssembly(typeof(Scrambler)).CodeBase)
                         + "\\" + info.File;

                    string test = filepath.Remove(0,6);


                    IServerConfiguration config = Db4oClientServer.NewServerConfiguration();
                    IObjectServer db4oServer = Db4oClientServer.OpenServer(config, test, info.Port);
                    db4oServer.GrantAccess(info.User, info.Pass);
                    EventLog.WriteEntry("Db4o", "Starting the Db4o server with this file:" + filepath, EventLogEntryType.Information);


                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Db4o", "Failed to start the Db4o server." + info.File + ". Reason: " + ex.Message, EventLogEntryType.Error);
                    this.Stop();
                }
            }
       
     
        protected override void OnStart(string[] args)
        {
            ThreadStart thread = new ThreadStart(StartServert);
            workerThread = new Thread(thread);
         
            workerThread.Start();

        }

        protected override void OnStop()
        {
            //
            workerThread.Join(new TimeSpan(0, 0, 30));
            EventLog.WriteEntry("Db4o", "The Db4o Server has stopped", EventLogEntryType.Warning);
           
        }

    }
}
