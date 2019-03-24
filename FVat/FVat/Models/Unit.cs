using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    //Don't modify unless you know, what you're doing
    enum Unit
    {
        NoUnit = 0,
        Meter = 1,
        Meter2 = 2,
        Meter3 = 3,
        Gramme = 4,
        Kilogramme = 5,
        Tone = 6,
        Apiece = 7
    }

    static class UnitConverter
    {
        private const string NoUnitText = "";
        private const string MeterText = "m";
        private const string Meter2Text = "m^2";
        private const string Meter3Text = "m^3";
        private const string GrammeText = "g";
        private const string KilogrammeText = "kg";
        private const string ToneText = "t";
        private const string ApieceText = "szt.";

        public static string ToString(Unit unit)
        {
            switch(unit)
            {
                case Unit.NoUnit:
                    return NoUnitText;

                case Unit.Meter:
                    return MeterText;

                case Unit.Meter2:
                    return Meter2Text;

                case Unit.Meter3:
                    return Meter3Text;

                case Unit.Gramme:
                    return GrammeText;

                case Unit.Kilogramme:
                    return KilogrammeText;

                case Unit.Tone:
                    return ToneText;

                case Unit.Apiece:
                    return ApieceText;
            }

            throw new Exception("Unit value out of range.");
        }
    }
}
