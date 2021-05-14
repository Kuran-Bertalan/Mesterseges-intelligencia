using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_beadandó.Allapotter
{
    class Allapot
    {
        public static int BABUKSZAMA = 5;
        public Babuk[] Babuk = new Babuk[5];
        private Babuk[] celBabuk = new Babuk[] {
        new Babuk(0,2),//K
        new Babuk(1,1),//F1
        new Babuk(1,0),//F2
        new Babuk(0,0),//B1
        new Babuk(0,1)//B2
        };
     
        public Allapot()
        {
            Babuk[0] = new Babuk(1, 0); // K
            Babuk[1] = new Babuk(1, 1); // F
            Babuk[2] = new Babuk(1, 2); // F
            Babuk[3] = new Babuk(0, 0); // B
            Babuk[4] = new Babuk(0, 1); // B
        }

        public bool celfeltetel()
        {
            if (Babuk[0].Sor == celBabuk[0].Sor && Babuk[0].Oszlop == celBabuk[0].Oszlop &&
                Babuk[1].Sor == celBabuk[1].Sor && Babuk[1].Oszlop == celBabuk[1].Oszlop &&
                Babuk[2].Sor == celBabuk[2].Sor && Babuk[2].Oszlop == celBabuk[2].Oszlop &&
                Babuk[3].Sor == celBabuk[3].Sor && Babuk[3].Oszlop == celBabuk[3].Oszlop &&
                Babuk[4].Sor == celBabuk[4].Sor && Babuk[4].Oszlop == celBabuk[4].Oszlop)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string babu;
            StringBuilder builder = new StringBuilder();
            builder.Append("(");

            for (int i = 0; i < BABUKSZAMA; i++)
            {
                if (i == 0) babu = "K";
                else if(i == 1) babu = "F1";
                else if(i == 2) babu = "F2";
                else if(i == 3) babu = "B1";
                else babu = "B2";


                builder.Append(babu);
                builder.Append("-s");
                builder.Append(Babuk[i].Sor);
                builder.Append("-o");
                builder.Append(Babuk[i].Oszlop);
                builder.Append("; ");
            }

            builder.Append(")");
            return builder.ToString();
        }
        public override bool Equals(object obj)
        {
            Allapot vizsgaltAllapot = (Allapot)obj;

            for (int i = 0; i < this.Babuk.Length; i++)
            {
                if (this.Babuk[i] != vizsgaltAllapot.Babuk[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
