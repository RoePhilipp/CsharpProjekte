using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using SQLite;
using System.IO;

namespace LSP
{
    [Activity(Label = "LSP", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        ActionBarDrawerToggle actionBarDrawerToggle;
        string dbPathDef = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteDefault.db3");
        string dbPathEnde = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteEnde.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            var lstVwMenu = FindViewById<ListView>(Resource.Id.lstVwMenuItems);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            var listMenuItems = new List<string>();
            listMenuItems.Add("Boot raus");
            listMenuItems.Add("Aktuell draußen");
            listMenuItems.Add("Tagesverlauf");
            listMenuItems.Add("LOGOUT");
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, listMenuItems.ToArray());
            lstVwMenu.Adapter = adapter;
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "LSP";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            actionBarDrawerToggle = new ActionBarDrawerToggle(this, drawerLayout, Resource.String.openDrawer, Resource.String.closeDrawer);
            drawerLayout.AddDrawerListener(actionBarDrawerToggle);
            actionBarDrawerToggle.SyncState();
            lstVwMenu.ItemClick += LstVwMenu_ItemSelected;
            //SetupDB();
        }

        void SetupDB()
        {
            /*if(boote == null)
            {WICHTIG FÜR DATEN WEGEN LAZY
                boote = new List<Boot>();
                boote.Add(new Boot("23", "Tretboot", true));
                boote.Add(new Boot("25", "Tretboot", true));
                boote.Add(new Boot("31", "Tretboot", true));
                boote.Add(new Boot("32", "Tretboot", true));
                boote.Add(new Boot("33", "Tretboot", true));
                boote.Add(new Boot("34", "Tretboot", true));
                boote.Add(new Boot("35", "Tretboot", true));
                boote.Add(new Boot("36", "Tretboot", true));
                boote.Add(new Boot("13", "Ruderboot", true));
                boote.Add(new Boot("7", "Ruderboot", true));
                boote.Add(new Boot("9", "Ruderboot", true));
                boote.Add(new Boot("10", "Ruderboot", true));
            }*/
            /*File.Delete(dbPathDef);
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
            db.Commit();
            db2.Commit();
            db.Close();
            db2.Close();*/
        }

        void LstVwMenu_ItemSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            switch(e.Position)
            {
                case 0:
                    var fragment = new Fragments.bootRausFrag();
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
                    break;
                case 1:
                    var fragment1 = new Fragments.aktuellFrag();
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment1).Commit();
                    break;
                case 2:
                    var fragment2 = new Fragments.verlaufFrag();
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment2).Commit();
                    break;
                case 3:
                    var fragment3 = new Fragments.logoutFrag();
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment3).Commit();
                    break;
            }

            drawerLayout.CloseDrawers();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Android.Resource.Id.Home:
                    if(drawerLayout.IsDrawerOpen((int)GravityFlags.Start))
                    {
                        drawerLayout.CloseDrawer((int)GravityFlags.Start);
                    }else
                    {
                        drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    }
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if(drawerLayout.IsDrawerOpen((int)GravityFlags.Start))
            {
                drawerLayout.CloseDrawer((int)GravityFlags.Start);
            }else
            {
               base.OnBackPressed();
            }
        }

    }
}

