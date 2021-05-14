using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_beadandó.Allapotter
{
    class Babuk
    {
        private int sor;
        private int oszlop;

        public int Sor { get => sor; set => sor = value; }
        public int Oszlop { get => oszlop; set => oszlop = value; }

        public Babuk(int sor, int oszlop)
        {
            Sor = sor;
            Oszlop = oszlop;
        }
    }
}
