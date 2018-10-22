using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FreshWall
{
    public static class ReadWriteToFile
    {
        //Nicht mehr gebraucht
        public static string ReadFileDate(string fileName, string filePath)
        {
            if(!File.Exists(filePath + fileName))
            {
                File.Create(filePath + fileName);
                WriteDateToFile(filePath, fileName, true);
            }
            StreamReader sr = new StreamReader(filePath + fileName, Encoding.UTF8, false, 4096);
            string time = sr.ReadLine();
            sr.Close();
            return time;
        }

        public static List<string> ReadFileKeywords(string fileName, string filePath)
        {
            List<string> lstKeywords = new List<string>();
            if(File.Exists(filePath + fileName))
            {
                StreamReader sr = new StreamReader(filePath + fileName, Encoding.UTF8, false, 4096);
                string line = string.Empty;
                while((line = sr.ReadLine()) != null)
                 {
                    lstKeywords.Add(line);
                 }
                sr.Close();
            }
            else
            {
                lstKeywords.Add("NO");
            }
            return lstKeywords;
        }

        //Nichtmehr gebraucht
        public static void WriteDateToFile(string fileName, string filePath, bool firstStart)
        {
            string time = "";
            if (firstStart)
            {
                time = DateTime.Parse("12:06:00").ToShortTimeString();
            }
            else
            {
                time = DateTime.Now.ToShortTimeString();
            }
        
             if (!File.Exists(filePath + fileName))
             {
                 File.Create(filePath + fileName).Close();
             }
             else
             {
                 File.Delete(filePath + fileName);
                 File.Create(filePath + fileName).Close();
             }
             StreamWriter sw = new StreamWriter(filePath + fileName, true, Encoding.UTF8, 4096);
             sw.Write(time);
             sw.Flush();
             sw.Close();
        }

        public static void WriteListToFile(List<string> m_lst, string fileName, string filePath)
        {
            if (!File.Exists(filePath + fileName))
            {
                Directory.CreateDirectory(filePath);
                File.Create(filePath + fileName).Close();
            }
            else
            {
                string backupFileName = CreateBackup();
                File.Copy(filePath + fileName, filePath + backupFileName);
                File.Create(filePath + fileName).Close();
            }
            StreamWriter sw = new StreamWriter(filePath + fileName, true, Encoding.UTF8, 4096);
            foreach(var word in m_lst)
            {
                sw.Write(word + Environment.NewLine);
            }
            sw.Flush();
            sw.Close();
        }

        public static string CreateBackup()
        {
            string backupFileName = "keywords.txt.BAK" + DateTime.Now.ToShortDateString();
            return backupFileName;
        }
    }
}
