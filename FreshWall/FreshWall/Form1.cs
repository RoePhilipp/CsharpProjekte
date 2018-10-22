using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.Win32.TaskScheduler;
using Unsplasharp;

namespace FreshWall
{
    public partial class Form1 : MetroForm
    {
        public const string access_key = "XXXXXXXXX-AccessKey für Unsplash";
        public string fileNameDate = "date.txt";
        public string fileName = "keywords.txt";
        public string filePath = "C:\\Users\\" + Environment.UserName + "\\Desktop\\FreshWall\\";
        public string filePathPics = "C:\\Users\\" + Environment.UserName + "\\Desktop\\FreshWall\\Pics\\";
        UnsplasharpClient client = new UnsplasharpClient(access_key);
        List<string> lstKeywords;

        public Form1()
        {
            InitializeComponent();
            lstKeywords = ReadWriteToFile.ReadFileKeywords(fileName, filePath);
            SetWallpaper();
            CheckIfScheduled();
        }

        private void CheckIfScheduled()
        {
            using(TaskService ts = new TaskService())
            {
                var task = ts.FindTask(@"FreshWall");
                if(task != null)
                {
                    chkBxAutomatic.Checked = true;
                }
                else
                {
                    chkBxAutomatic.Checked = false;
                }
            }
        }

        private async void SetWallpaper()
        {
            Random rand = new Random();
            if(lstKeywords[0] == "NO")
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't fetch Wallpaper please input at least one Keyword and press [Save Keywords]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstKeywords.Clear();
            }
            else
            {
                try
                {
                    var indexRand = rand.Next(0, lstKeywords.Count - 1);
                    var photo = await client.GetRandomPhoto(count: 1, query: lstKeywords[indexRand]);
                    pictureBox1.ImageLocation = photo[0].Links.Download;
                    DownloadWallpaper.Download(filePathPics, photo[0].Links.Download);
                    Wallpaper.SetWallpaper(filePathPics + "ImageToday.jpg");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //MetroFramework.MetroMessageBox.Show(this, "Please input at least one Keyword and press [Save Keywords]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveKeywords_Click(object sender, EventArgs e)
        {
            lstKeywords = KeywordAnalyzer.Analyze(txtBxKeywords.Text);
            //MessageBox.Show(lstKeywords[0]); - FÜR DEBUGGING
            ReadWriteToFile.WriteListToFile(lstKeywords, fileName, filePath);
        }

        private void chkBxAutomatic_CheckStateChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroCheckBox checkBox = (MetroFramework.Controls.MetroCheckBox)sender;
            //Setzt windows TaskSchedule und startet Programm stündlich = neues Hintergrundbild jede Stunde
            if(checkBox.Checked == true)
            {
                using(TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Changes Wallpaper automatically";
                    var trigger = new TimeTrigger();
                    trigger.Repetition.Interval = TimeSpan.FromHours(1);
                    td.Triggers.Add(trigger);
                    td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetExecutingAssembly().Location));
                    ts.RootFolder.RegisterTaskDefinition(@"FreshWall", td);
                }
            }
            else
            {
                using(TaskService ts = new TaskService())
                {
                    ts.RootFolder.DeleteTask(@"FreshWall");
                }
            }
        }
    }
}
