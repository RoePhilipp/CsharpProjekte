using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FreshWall
{
    public static class Wallpaper
    {
        //Benutzen der WINAPI zum setzen des Hintergrundbilds
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(UAction action, int uParam, StringBuilder lpvParam, int fuWinIni);

        public enum UAction
        {
            SPI_SETDESKWALLPAPER = 0x0014,
            SPI_GETDESKWALLPAPER = 0x0073
        }
        
        public static string GetWallaper()
        {
            StringBuilder s = new StringBuilder(300);
            SystemParametersInfo(UAction.SPI_GETDESKWALLPAPER, 300, s, 0);
            return s.ToString();
        }

        public static bool SetWallpaper(string pathToFile)
        {
            bool result = false;
            int res = 0;
            if (File.Exists(pathToFile))
            {
                StringBuilder s = new StringBuilder(pathToFile);
                //gibt 1 zurück wenn erfolgreich
                res = SystemParametersInfo(UAction.SPI_SETDESKWALLPAPER, 0, s, 0x2);
            }

            if(res == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }

    public static class DownloadWallpaper
    {
        public static void Download(string filePath, string url)
        {
            if (!File.Exists(filePath + "ImageToday.jpg"))
            {
                Directory.CreateDirectory(filePath);
            }
            else
            {
                File.Delete(filePath + "ImageToday.jpg");
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filePath + "ImageToday.jpg");
            }
        }
    }
}
