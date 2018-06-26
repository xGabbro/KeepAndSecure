using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.Reflection;
using System.IO;

namespace K33P3R
{
    class Updater
    {
        WebClient client = new WebClient();

        public void Main()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return;

            string _currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string _versionOnline = client.DownloadString("https://raw.githubusercontent.com/xGabbro/K33P3R/master/version_online.txt");

            if (!(Int32.Parse(_versionOnline.Replace(".", "")) > Int32.Parse(_currentVersion.Replace(".", "")))) return;
            string path = Directory.GetCurrentDirectory() + @"\K33PER.ex";

            client.DownloadFile("https://raw.githubusercontent.com/xGabbro/K33P3R/master/New.exe", path);

            
        }

    }
}
