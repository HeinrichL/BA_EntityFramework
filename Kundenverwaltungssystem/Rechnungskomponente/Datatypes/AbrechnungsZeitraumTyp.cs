﻿using System;

namespace Rechnungskomponente.DataAccessLayer.Datatypes
{
    public class AbrechnungsZeitraumTyp
    {
        public int Monat { get; private set; }
        public int Jahr { get; private set; }

        public AbrechnungsZeitraumTyp(int monat, int jahr)
        {
            if (IstGueltigerMonat(monat) && IstGueltigesJahr(jahr))
            {
                Monat = monat;
                Jahr = jahr;
            }
            else
            {
                throw new ArgumentException($"{monat}/{jahr} ist kein gültiger Abrechnungszeitraum");
            }
        }

        private AbrechnungsZeitraumTyp() { }

        public static bool IstGueltigerMonat(int monat)
        {
            return monat > 0 && monat <= 12;
        }

        public static bool IstGueltigesJahr(int jahr)
        {
            return jahr >= DateTime.MinValue.Year && jahr <= DateTime.MaxValue.Year;
        }

    }
}