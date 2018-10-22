using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using static Android.Widget.RadioGroup;

namespace LSP.Fragments
{
    public class bootRausFrag : Android.Support.V4.App.Fragment
    {
        Button btnStart;
        Spinner selBoote;
        RadioButton rdBtnHalf;
        RadioButton rdBtnFull;
        RadioButton rdBtnCustom;
        List<Boot> boote;
        EditText edtTxtCustomTime;
        string choice = "half";
        string dbPathDef = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteDefault.db3");
        string dbPathEnde = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBooteEnde.db3");

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.bootRaus, container, false);
            boote = new List<Boot>();

            var db = new SQLiteConnection(dbPathDef);
            var table = db.Table<Boot>();
            foreach(var item in table)
            {
                boote.Add(item);
            }
            btnStart = view.FindViewById<Button>(Resource.Id.btnStart);
            selBoote = view.FindViewById<Spinner>(Resource.Id.selBoote);
            rdBtnHalf = view.FindViewById<RadioButton>(Resource.Id.rdBtnHalf);
            rdBtnFull = view.FindViewById<RadioButton>(Resource.Id.rdBtnFull);
            rdBtnCustom = view.FindViewById<RadioButton>(Resource.Id.rdBtnCustom);
            selBoote = view.FindViewById<Spinner>(Resource.Id.selBoote);
            edtTxtCustomTime = view.FindViewById<EditText>(Resource.Id.edtTextCustomTimeMinutes);
            var viewBoote = new List<string>();
            foreach(var boot in boote)
            {
                viewBoote.Add(boot.ToString());
            }
            ISpinnerAdapter adapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, viewBoote.ToArray());
            selBoote.Adapter = adapter;
            btnStart.Click += BtnStart_Click;
            rdBtnHalf.Click += rdBtnClick_Handler;
            rdBtnFull.Click += rdBtnClick_Handler;
            rdBtnCustom.Click += rdBtnClick_Handler;
            return view;
        }

        void rdBtnClick_Handler(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if(rb.Text == "Halbe Stunde")
            {
                choice = "half";
            }else if(rb.Text == "Ganze Stunde")
            {
                choice = "full";
            }else if(rb.Text == "Eigene Zeit")
            {
                choice = "custom";
            }
        }

        void BtnStart_Click(object sender, EventArgs e)
        {
            double min = 0;
            var db = new SQLiteConnection(dbPathDef);
            var table = db.Table<Boot>();
            if(choice == "half")
            {
                min = 30;
                var Skkrt = table.ElementAt(selBoote.SelectedItemPosition);
                if(Skkrt.Available)
                {
                    Skkrt.Available = false;
                    Skkrt.startZeit = DateTime.Now;
                    Skkrt.endZeit = Skkrt.startZeit.AddMinutes(min);
                    db.InsertOrReplace(Skkrt, typeof(Boot));
                    db.Commit();
                }else
                {
                    AlertDialog alert = new AlertDialog.Builder(Context)
                                                       .SetTitle("Schon draußen!")
                                                       .SetMessage("Jaala, dass Boot ist schon draußen. \n " +
                                                                   "Wenn wieder da: ->aktuell draußen->lang auf item in der liste drücken->wieder da")
                                                       .SetPositiveButton("Hell, Yeah!", (sendar, ev) => { }).Create();
                    alert.Show();
                }

            }
            else if(choice == "full")
            {
                min = 60;
                var Skkrt = table.ElementAt(selBoote.SelectedItemPosition);
                if (Skkrt.Available)
                {
                    Skkrt.Available = false;
                    Skkrt.startZeit = DateTime.Now;
                    Skkrt.endZeit = Skkrt.startZeit.AddMinutes(min);
                    db.InsertOrReplace(Skkrt, typeof(Boot));
                    db.Commit();
                }
                else
                {
                    AlertDialog alert = new AlertDialog.Builder(Context)
                                                       .SetTitle("Schon draußen!")
                                                       .SetMessage("Jaala, dass Boot ist schon draußen. \n " +
                                                                   "Wenn wieder da: ->aktuell draußen->lang auf item in der liste drücken->wieder da")
                                                       .SetPositiveButton("Hell, Yeah!", (sendar, ev) => { }).Create();
                    alert.Show();
                }
            }
            else if(choice == "custom")
            {
                if(edtTxtCustomTime.Text != string.Empty)
                {
                    min = Convert.ToDouble(edtTxtCustomTime.Text);
                    var Skkrt = table.ElementAt(selBoote.SelectedItemPosition);
                    if (Skkrt.Available)
                    {
                        Skkrt.Available = false;
                        Skkrt.startZeit = DateTime.Now;
                        Skkrt.endZeit = Skkrt.startZeit.AddMinutes(min);
                        db.InsertOrReplace(Skkrt, typeof(Boot));
                        db.Commit();
                    }
                    else
                    {
                        AlertDialog alert = new AlertDialog.Builder(Context)
                                                           .SetTitle("Schon draußen!")
                                                           .SetMessage("Jaala, dass Boot ist schon draußen. \n " +
                                                                       "Wenn wieder da: ->aktuell draußen->lang auf item in der liste drücken->wieder da")
                                                           .SetPositiveButton("Hell, Yeah!", (sendar, ev) => { }).Create();
                        alert.Show();
                    }
                }
                else
                {
                    AlertDialog alertBuilder = new AlertDialog.Builder(Context)
                        .SetTitle("!LSP!")
                        .SetMessage("Bitte gebe die Anzahl der Minuten ein \n Gruß der mystische Chiller von nebenan!")
                        .SetPositiveButton("Ok", (object senda, DialogClickEventArgs ea) => edtTxtCustomTime.RequestFocus()).Create();
                    alertBuilder.Show();
                }
            }
            db.Close();
            var fragment = new aktuellFrag();
            FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment).Commit();
        }

    }
}
