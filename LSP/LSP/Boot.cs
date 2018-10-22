using System;
using SQLite;

namespace LSP
{
    public class Boot
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nummer { get; set; }
        public string Art { get; set; }
        public DateTime startZeit { get; set; }
        public DateTime endZeit { get; set; }
        public bool Available { get; set; }

        public Boot(){}

        public Boot(string nummer, string art, bool available)
        {
            this.Nummer = nummer;
            this.Art = art;
            this.Available = available;
        }

       /* public void Start(double minutes)
        {
            this.startZeit = DateTime.Now;
            this.endZeit = startZeit.AddMinutes(minutes);
            this.Available = false;
        }*/

        /*public void End()
        {
            this.endZeit = DateTime.Now;
            this.Available = true;
        }*/

        public string FullInfo()
        {
            return Nummer + " | " + Art + " | " + Available.ToString() + " | " + startZeit.ToShortTimeString() + " | " + endZeit.ToShortTimeString();
        }

        public string DaInfo()
        {
            return Nummer + " | " + Art + " | " + startZeit.ToShortTimeString() + " | " + endZeit.ToShortTimeString();
        }

        public override string ToString()
        {
            return Nummer + " | " + Art + " | " + Available.ToString();
        }
    }
}
