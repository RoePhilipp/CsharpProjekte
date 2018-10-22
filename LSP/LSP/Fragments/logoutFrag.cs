using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LSP.Fragments
{
    public class logoutFrag : Android.Support.V4.App.Fragment
    {
        string dbPathDef = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteDefault.db3");
        string dbPathEnde = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteEnde.db3");
        SeekBar funBar;
        Button btnLogout;
        //LinearLayout relLayout;
        View view;
        Android.Graphics.Color color;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.logout, container, false);
            funBar = view.FindViewById<SeekBar>(Resource.Id.seekBarFun);
            btnLogout = view.FindViewById<Button>(Resource.Id.btnLogout);
            //relLayout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            funBar.ProgressChanged += FunBar_ProgressChanged;
            btnLogout.Click += BtnLogout_Click;
            return view;
        }

        void BtnLogout_Click(object sender, EventArgs e)
        {
            File.Delete(dbPathDef);
            File.Delete(dbPathEnde);
            var db = new SQLiteConnection(dbPathDef);
            var db2 = new SQLiteConnection(dbPathEnde);
            db2.CreateTable<Boot>();
            db.CreateTable<Boot>();
            db.DeleteAll<Boot>();
            db2.DeleteAll<Boot>();
            db.Insert(new Boot("23", "Tretboot", true));
            db.Insert(new Boot("25", "Tretboot", true));
            db.Insert(new Boot("31", "Tretboot", true));
            db.Insert(new Boot("32", "Tretboot", true));
            db.Insert(new Boot("33", "Tretboot", true));
            db.Insert(new Boot("34", "Tretboot", true));
            db.Insert(new Boot("35", "Tretboot", true));
            db.Insert(new Boot("36", "Tretboot", true));
            db.Insert(new Boot("13", "Ruderboot", true));
            db.Insert(new Boot("7", "Ruderboot", true));
            db.Insert(new Boot("9", "Ruderboot", true));
            db.Insert(new Boot("10", "Ruderboot", true));
            db.Insert(new Boot("-", "Ruderboot", true));
            db.Commit();
            db2.Commit();
            db.Close();
            db2.Close();
        }


        void FunBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            color = new Android.Graphics.Color(e.Progress, 50, e.Progress, 255);
            view.SetBackgroundColor(color);
        }

    }
}
