
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using System.IO;
using SQLite;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LSP.Fragments
{
    public class verlaufFrag : Android.Support.V4.App.Fragment
    {
        public List<string> lstVerlauf;
        ListView lstVwVerlauf;
        Button btnPrint;
        string dbPathDef = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteDefault.db3");
        string dbPathEnde = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteEnde.db3");
        string savePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Boote_vom_");

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.verlauf, container, false);
            lstVwVerlauf = view.FindViewById<ListView>(Resource.Id.lstVwVerlauf);
            btnPrint = view.FindViewById<Button>(Resource.Id.btnPrint);
            lstVerlauf = new List<string>();
            var dbDa = new SQLiteConnection(dbPathEnde);
            var table = dbDa.Table<Boot>();
            foreach(var item in table)
            {
                lstVerlauf.Add(item.DaInfo());
            }
            var laurapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, lstVerlauf.ToArray());
            lstVwVerlauf.Adapter = laurapter;
            btnPrint.Click += BtnPrint_Click;
            return view;
        }

        void BtnPrint_Click(object sender, EventArgs e)
        {
            int CountDa = 0;
            using(var streamWriter = new StreamWriter(savePath + DateTime.Now.ToShortDateString()+ ".txt", true))
            {
                foreach (var line in lstVerlauf)
                {
                    CountDa++;
                    streamWriter.WriteLine(CountDa + " | " + line);
                }
            }
            Toast.MakeText(Context, "Speicherort der Liste " + savePath + DateTime.Now.ToShortDateString() + ".txt", ToastLength.Short).Show();
        }

    }
}
