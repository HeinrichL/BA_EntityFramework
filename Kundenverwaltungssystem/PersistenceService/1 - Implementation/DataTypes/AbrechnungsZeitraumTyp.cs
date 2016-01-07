using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceService._1___Implementation;

namespace PersistenceService._1___Implementation
{
    public partial class AbrechnungsZeitraumTyp
    {
        public AbrechnungsZeitraumTyp(int monat, int jahr)
        {
            this.Monat = monat;
            this.Jahr = jahr;
        }

        public AbrechnungsZeitraumTyp() { }
    }
}
