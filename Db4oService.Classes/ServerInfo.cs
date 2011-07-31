using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;


namespace Db4oService.Classes
{
    public class ServerInfo
    {

        static string path = System.IO.Path.GetDirectoryName(
         System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

       

        static XDocument xml = XDocument.Load(path + "\\ServerInfo.xml");

        string _host;
        string _file;
        

        int _port;
        string _user;
        string _pass;
        

        public string Host
        {

            get
            {
                _host = getElement().Element("host").Value;
                return _host;
            }

            set
            {
                _host = value;
            }

            
        }

        public string File
        {
            get
            {
                return getElement().Element("file").Value;
            }

            set
            {
                _file = value;
            }
        }

        public int Port
        {
            get
            {
                return Convert.ToInt32(getElement().Element("port").Value);
            }

            set
            {
                _port = value;
            }
            
        }

        public string User
        {
            get
            {
                return getElement().Element("user").Value;
            }

            set
            {
                _user = value;
            }
           
        }

        public string Pass
        {
            get
            {
               
                return Scrambler.Decrypt(getElement().Element("pass").Value);
            }

            set
            {
                _pass = Scrambler.Encrypt(value);
            }
            
        }
        
        static XElement getElement()
        {
            return (from s in xml.Descendants("server")
                    select s).FirstOrDefault();
        }

        public void createServerInfoXML()
        {
            if (String.IsNullOrEmpty(Host))
                throw new ArgumentNullException("Please enter the hostname");
            if (String.IsNullOrEmpty(File))
                throw new ArgumentNullException("Please enter the Db4o filename");
            if (String.IsNullOrEmpty(Port.ToString()))
                throw new ArgumentNullException("Please enter the Db4o server port number");
            if (String.IsNullOrEmpty(User))
                throw new ArgumentNullException("Please enter a username");
            if (String.IsNullOrEmpty(Pass))
                throw new ArgumentNullException("Please enter a password");

            XDocument doc = new XDocument(
             new XElement("server",
                  new XElement("host", _host),
                  new XElement("file", _file),
                  new XElement("port", _port),
                  new XElement("user", _user),
                  new XElement("pass", _pass)
                  ));

            doc.Save("ServerInfo.xml");

        }

    }

}


