namespace Db4oService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Db4oProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.Db4oServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // Db4oProcessInstaller
            // 
            this.Db4oProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.Db4oProcessInstaller.Password = null;
            this.Db4oProcessInstaller.Username = null;
            // 
            // Db4oServiceInstaller
            // 
            this.Db4oServiceInstaller.Description = "Db4o open source object database, native to Java and .NET";
            this.Db4oServiceInstaller.DisplayName = "Db4o object database";
            this.Db4oServiceInstaller.ServiceName = "Db4o";
            this.Db4oServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.Db4oProcessInstaller,
            this.Db4oServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller Db4oProcessInstaller;
        private System.ServiceProcess.ServiceInstaller Db4oServiceInstaller;
    }
}