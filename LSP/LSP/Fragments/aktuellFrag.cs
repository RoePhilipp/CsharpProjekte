
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
using System.Threading;
using Android.Widget;

namespace LSP.Fragments
{
    public class aktuellFrag : Android.Support.V4.App.Fragment
    {
        ListView lstVwBooteAktuell;
        List<string> booteUsed;
        List<Boot> booteUsedClass;
        List<Boot> helperList;
        string dbPathDef = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteDefault.db3");
        string dbPathEnde = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteEnde.db3");

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.aktuell, container, false);
            Thread.Sleep(10);
            booteUsed = new List<string>();
            booteUsedClass = new List<Boot>();
            helperList = new List<Boot>();
            var db = new SQLiteConnection(dbPathDef);
            var table = db.Table<Boot>();
            foreach(var item in table)
            {
                if(!item.Available)
                {
                    booteUsed.Add(item.FullInfo());
                    booteUsedClass.Add(item);
                }
                helperList.Add(item);
                Thread.Sleep(3);
            }
            lstVwBooteAktuell = view.FindViewById<ListView>(Resource.Id.lstVwBooteAktuell);
            var adapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, booteUsed.ToArray());
            lstVwBooteAktuell.Adapter = adapter;
            RegisterForContextMenu(lstVwBooteAktuell);
            return view;
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if(v.Id == Resource.Id.lstVwBooteAktuell)
            {
                var info = (AdapterView.AdapterContextMenuInfo)menuInfo;
                menu.SetHeaderTitle(booteUsedClass[info.Position].Nummer + " ," + booteUsedClass[info.Position].Nummer);
                menu.Add(Menu.None, 0, 0, "Löschen");
                menu.Add(Menu.None, 1, 1, "Wieder da");
            }
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
            var menuIndex = item.ItemId;
            var db = new SQLiteConnection(dbPathDef);
            var dbDa = new SQLiteConnection(dbPathEnde);
            if(menuIndex == 0)
            {
                Boot bootDa = booteUsedClass[info.Position];
                int index = helperList.FindIndex(x => x == bootDa);
                var bootSkrrt = db.Table<Boot>().ElementAt(index);
                Toast.MakeText(Context, bootSkrrt.Nummer + " gelöscht!", ToastLength.Short).Show();
                bootSkrrt.Available = true;
                db.InsertOrReplace(bootSkrrt, typeof(Boot));
                db.Commit();
                db.Close();
                dbDa.Close();
                booteUsed.RemoveAt(info.Position);
                booteUsedClass.RemoveAt(info.Position);
                lstVwBooteAktuell.DeferNotifyDataSetChanged();
                var frag = new bootRausFrag();
                FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, frag).CommitNow();
            }else if(menuIndex == 1)
            {
                Boot bootDa = booteUsedClass[info.Position];
                //Toast.MakeText(Context, bootDa.FullInfo(), ToastLength.Short).Show();
                int index = helperList.FindIndex(x => x.ID == bootDa.ID);
                //Toast.MakeText(Context, index.ToString(), ToastLength.Short).Show();
                var bootSkkrt = db.Table<Boot>().ElementAt(index);
                Toast.MakeText(Context, bootSkkrt.Nummer + " ist wieder da!", ToastLength.Short).Show();
                bootSkkrt.Available = true;
                bootSkkrt.endZeit = DateTime.Now;
                dbDa.Insert(bootSkkrt);
                db.Table<Boot>().Delete(x => x.Nummer == bootSkkrt.Nummer);
                db.Insert(bootSkkrt);
                dbDa.Commit();
                db.Commit();
                dbDa.Close();
                db.Close();
                booteUsed.RemoveAt(info.Position);
                booteUsedClass.RemoveAt(info.Position);
                lstVwBooteAktuell.DeferNotifyDataSetChanged();
                var frag = new bootRausFrag();
                FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, frag).CommitNow();
            }
            return true;
        }
    }
}
