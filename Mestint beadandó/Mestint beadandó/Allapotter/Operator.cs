using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_beadandó.Allapotter
{
    class Operator
    {
        private int mit;
        private Babuk hova;

        public Babuk Hova { get => hova; set => hova = value; }
        public int Mit { get => mit; set => mit = value; }

        public Operator(int mit, Babuk hova)
        {
            this.Mit = mit;
            this.Hova = hova;
        }
        public Allapot BabuMozdit(Allapot allapot)
        {
            Allapot ujAllapot = new Allapot();
            //Console.WriteLine(allapot.ToString());
            for (int i = 0; i < Allapot.BABUKSZAMA; i++)
            {
                ujAllapot.Babuk[i] = allapot.Babuk[i];
            }
            ujAllapot.Babuk[mit] = hova;
            //Console.WriteLine(ujAllapot.ToString());
            //Console.WriteLine("------------");
            return ujAllapot;
        }

        // Előfeltétel
        public bool Elofeltetel(Allapot allapot)
        {
            // Sor
            for (int i = allapot.Babuk[mit].Sor - 1; i <= allapot.Babuk[mit].Sor + 1; i++)
            {
                // Oszlop
                for (int j = allapot.Babuk[mit].Oszlop - 1; j <= allapot.Babuk[mit].Oszlop + 1; j++)
                {
                    // Ha a vizsgált állapot nem esik a játéktáblán kívülre
                    if (i >= 0 && i <= 2 && j >= 0 && j <= 3)
                    {
                        // Ugyan az a sor || oszlop
                        if (i != allapot.Babuk[mit].Sor && j != allapot.Babuk[mit].Oszlop)
                        {
                            // Király
                            if (mit == 0)
                            {
                                if (allapot.Babuk[mit].Sor + 1 < hova.Sor || allapot.Babuk[mit].Sor - 1 > hova.Sor ||
                                    allapot.Babuk[mit].Oszlop + 1 < hova.Oszlop || allapot.Babuk[mit].Oszlop - 1 > hova.Oszlop)
                                {
                                    return false;
                                    
                                }
                            }
                            // Futó 1
                            if (mit == 1)
                            {
                                if (allapot.Babuk[mit].Sor == 1 && allapot.Babuk[mit].Oszlop == 0 ||
                                    allapot.Babuk[mit].Sor == 0 && allapot.Babuk[mit].Oszlop == 1 ||
                                    allapot.Babuk[mit].Sor == 1 && allapot.Babuk[mit].Oszlop == 2 ||
                                    allapot.Babuk[mit].Sor + 1 < hova.Sor || allapot.Babuk[mit].Sor - 1 > hova.Sor ||
                                    allapot.Babuk[mit].Oszlop + 1 < hova.Oszlop || allapot.Babuk[mit].Oszlop - 1 > hova.Oszlop)
                                {
                                    return false;
                                }
                                
                            }
                            // Futó 2
                            if (mit == 2)
                            {
                                if (allapot.Babuk[mit].Sor == 1 && allapot.Babuk[mit].Oszlop == 1 ||
                                    allapot.Babuk[mit].Sor == 0 && allapot.Babuk[mit].Oszlop == 0 ||
                                    allapot.Babuk[mit].Sor == 0 && allapot.Babuk[mit].Oszlop == 2 ||
                                    allapot.Babuk[mit].Sor + 1 < hova.Sor || allapot.Babuk[mit].Sor - 1 > hova.Sor ||
                                    allapot.Babuk[mit].Oszlop + 1 < hova.Oszlop || allapot.Babuk[mit].Oszlop - 1 > hova.Oszlop)
                                {
                                    return false;
                                }
                            }
                            // Bástya1 és Bástya2
                            if (mit == 3 || mit == 4)
                            {
                                if (
                                    allapot.Babuk[mit].Sor + 1 > hova.Sor && allapot.Babuk[mit].Oszlop == hova.Oszlop ||
                                    allapot.Babuk[mit].Sor - 1 < hova.Sor && allapot.Babuk[mit].Oszlop == hova.Oszlop ||
                                    allapot.Babuk[mit].Sor == hova.Sor && allapot.Babuk[mit].Oszlop + 1 > hova.Oszlop ||
                                    allapot.Babuk[mit].Sor == hova.Sor && allapot.Babuk[mit].Oszlop - 1 < hova.Oszlop &&
                                    hova.Sor != 2 && hova.Oszlop != 2
                                    )
                                {
                                    break;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                        }
                    }
                }
            }
            // Van ott valami
            for (int b = 0; b < Allapot.BABUKSZAMA; b++)
            {
                if (hova.Sor == allapot.Babuk[b].Sor && hova.Oszlop == allapot.Babuk[b].Oszlop)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
