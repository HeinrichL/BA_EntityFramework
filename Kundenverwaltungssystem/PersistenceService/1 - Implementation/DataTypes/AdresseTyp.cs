namespace PersistenceService._1___Implementation
{
    public partial class AdresseTyp
    {
        public AdresseTyp(string strasse, string hausnummer, string plz, string ort)
        {
            this.Strasse = strasse;
            this.Hausnummer = hausnummer;
            this.PLZ = plz;
            this.Ort = ort;
        }

        public AdresseTyp() { }
    }
}