using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_beadandó.Allapotter
{
    class Csomopont
    {
        Allapot allapot = new Allapot();
        Csomopont szulo;
        int koltseg;
        int operatorIndex;
        int heurisztika;
        int osszkoltseg;

        internal Allapot Allapot { get => allapot; set => allapot = value; }
        internal Csomopont Szulo { get => szulo; set => szulo = value; }
        public int Koltseg { get => koltseg; set => koltseg = value; }
        public int OperatorIndex { get => operatorIndex; set => operatorIndex = value; }
        public int Heurisztika { get => heurisztika; set => heurisztika = value; }
        public int Osszkoltseg { get => osszkoltseg; set => osszkoltseg = value; }

        public Csomopont(Allapot allapot, int operatorIndex)
        {
            this.allapot = allapot;
            this.operatorIndex = operatorIndex;
        }

        public Csomopont(Allapot allapot, Csomopont szulo)
        {
            this.allapot = allapot;
            this.szulo = szulo;

            if (szulo == null)
            {
                koltseg = 0;
            }
            else
            {
                koltseg = szulo.koltseg + 1;
            }

            this.heurisztika = 0;

            //Célsor és céloszlop
            int[] kiralyc = { 0, 2 };
            int[] futo1c = { 1, 1 };
            int[] futo2c = { 1, 0 };
            int[] bastya1c = { 0, 0 };
            int[] bastya2c = { 0, 1 };


            // Ha a király
            if (szulo != null && CélMezőnVanEaBábú(szulo.allapot.Babuk[0], kiralyc[0], kiralyc[1]))
            {
                // Ha a király a célmezőn van akkor a többi bábut mozgatjuk
                MinelKozelebbKerul(allapot.Babuk[1], kiralyc[0], kiralyc[1]);
                MinelKozelebbKerul(allapot.Babuk[2], futo2c[0], futo2c[1]);
                MinelKozelebbKerul(allapot.Babuk[3], bastya1c[0], bastya1c[1]);
                MinelKozelebbKerul(allapot.Babuk[4], bastya2c[0], bastya2c[1]);
                // Ha a királyal ellépünk a célmezőről
                if (!CélMezőnVanEaBábú(allapot.Babuk[0], kiralyc[0], kiralyc[1]))
                {
                    this.heurisztika -= 10;
                }
            }
            // Ha futó1
            else if (szulo != null && CélMezőnVanEaBábú(szulo.allapot.Babuk[1], futo1c[0], futo1c[1]))
            {
                MinelKozelebbKerul(allapot.Babuk[0], kiralyc[0], kiralyc[1]);
                MinelKozelebbKerul(allapot.Babuk[2], futo2c[0], futo2c[1]);
                MinelKozelebbKerul(allapot.Babuk[3], bastya1c[0], bastya1c[1]);
                MinelKozelebbKerul(allapot.Babuk[4], bastya2c[0], bastya2c[1]);

                if (!CélMezőnVanEaBábú(allapot.Babuk[1], futo1c[0], futo1c[1]))
                {
                    this.heurisztika -= 10;
                }
            }
            // Ha futó2
            else if (szulo != null && CélMezőnVanEaBábú(szulo.allapot.Babuk[2], futo2c[0], futo2c[1]))
            {
                MinelKozelebbKerul(allapot.Babuk[0], kiralyc[0], kiralyc[1]);
                MinelKozelebbKerul(allapot.Babuk[1], futo1c[0], futo1c[1]);
                MinelKozelebbKerul(allapot.Babuk[3], bastya1c[0], bastya1c[1]);
                MinelKozelebbKerul(allapot.Babuk[4], bastya2c[0], bastya2c[1]);

                if (!CélMezőnVanEaBábú(allapot.Babuk[2], futo2c[0], futo2c[1]))
                {
                    this.heurisztika -= 10;
                }
            }
            // Ha bastya1
            else if (szulo != null && CélMezőnVanEaBábú(szulo.allapot.Babuk[3], bastya1c[0], bastya1c[1]))
            {
                MinelKozelebbKerul(allapot.Babuk[0], kiralyc[0], kiralyc[1]);
                MinelKozelebbKerul(allapot.Babuk[1], futo1c[0], futo1c[1]);
                MinelKozelebbKerul(allapot.Babuk[2], futo2c[0], futo2c[1]);
                MinelKozelebbKerul(allapot.Babuk[4], bastya2c[0], bastya2c[1]);

                if (!CélMezőnVanEaBábú(allapot.Babuk[3], bastya1c[0], bastya1c[1]))
                {
                    this.heurisztika -= 10;
                }
            }
            // Ha bastya2
            else if (szulo != null && CélMezőnVanEaBábú(szulo.allapot.Babuk[4], bastya2c[0], bastya2c[1]))
            {
                MinelKozelebbKerul(allapot.Babuk[0], kiralyc[0], kiralyc[1]);
                MinelKozelebbKerul(allapot.Babuk[1], futo1c[0], futo1c[1]);
                MinelKozelebbKerul(allapot.Babuk[2], futo2c[0], futo2c[1]);
                MinelKozelebbKerul(allapot.Babuk[3], bastya1c[0], bastya1c[1]);

                if (!CélMezőnVanEaBábú(allapot.Babuk[4], bastya2c[0], bastya2c[1]))
                {
                    this.heurisztika -= 10;
                }
            }
            else
            {
                foreach (Babuk babu in allapot.Babuk)
                {
                    int célsor = 0;
                    int céloszlop = 0;

                    if(babu == allapot.Babuk[0])
                    {
                        célsor = kiralyc[0];
                        céloszlop = kiralyc[1];
                    }
                    else if (babu == allapot.Babuk[1])
                    {
                        célsor = futo1c[0];
                        céloszlop = futo1c[1];
                    }
                    else if(babu == allapot.Babuk[2])
                    {
                        célsor = futo2c[0];
                        céloszlop = futo2c[1];
                    }
                    else if(babu == allapot.Babuk[3])
                    {
                        célsor = bastya1c[0];
                        céloszlop = bastya1c[1];
                    }
                    else if (babu == allapot.Babuk[4])
                    {
                        célsor = bastya2c[0];
                        céloszlop = bastya2c[1];
                    }
                    MinelKozelebbKerul(babu, célsor, céloszlop);
                }
            }
            this.osszkoltseg = this.koltseg + (-1) * this.heurisztika;
        }

        // Célmezőn van-e a bábú
        bool CélMezőnVanEaBábú(Babuk babu, int cS, int cO)
        {
            for (int i = cS ; i <= cS; i++)
            {
                for (int j = cO ; j <= cO; j++)
                {
                    if (babu.Sor == i && babu.Oszlop == j)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Minél közelebb kerül a bábu a célmezőhöz
        void MinelKozelebbKerul(Babuk babu, int cS, int cO)
        {
            // Minél közelebb van a bábu sor a célmező sorához
            if (babu.Sor > cS)
            {
                this.heurisztika += (5 - (babu.Sor - cS));
            }
            else if (babu.Sor < cS)
            {
                this.heurisztika += (5 - (cS - babu.Sor));
            }
            else this.heurisztika += 5;

            // Minél közelebb van a bábu oszlop a célmező oszlopához
            if (babu.Oszlop > cO)
            {
                this.heurisztika += (5 - (babu.Oszlop - cO));
            }
            else if (babu.Oszlop < cO)
            {
                this.heurisztika += (5 - (cO - babu.Oszlop));
            }
            else this.heurisztika += 5;
        }

        // Egyenlőségvizsgálat 
        public override bool Equals(object obj)
        {
            Csomopont vizsgalandoCsomopont = (Csomopont)obj;
            return this.allapot.Equals(vizsgalandoCsomopont.Allapot);
        }
    }
}
