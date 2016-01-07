using System;

namespace PersistenceService._1___Implementation
{
    public partial class VeranstaltungszeitTyp
    {
        public VeranstaltungszeitTyp(DateTime start, DateTime end) : this()
        {
            StartZeitpunkt = start;
            EndZeitpunkt = end;
        }

        public VeranstaltungszeitTyp() { }
    }
}