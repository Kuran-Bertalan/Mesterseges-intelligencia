using Mestint_beadandó.Allapotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_beadandó.Keresok
{
    class Melysegi :Kereso
    {
        public Melysegi()
        {
            Kereses();
        }

        // Keresés
        public override void Kereses()
        {
            Stack<Csomopont> nyiltCsucsok = new Stack<Csomopont>();
            List<Csomopont> zartCsucsok = new List<Csomopont>();

            nyiltCsucsok.Push(new Csomopont(new Allapot(), null));

            while (nyiltCsucsok.Count > 0 && !nyiltCsucsok.Peek().Allapot.celfeltetel())
            {
                Csomopont aktualisCsomopont = nyiltCsucsok.Pop();
                foreach (Operator op in Operatorok)
                {
                    if (op.Elofeltetel(aktualisCsomopont.Allapot))
                    {
                        Allapot ujAllapot = op.BabuMozdit(aktualisCsomopont.Allapot);
                        //szülő beállítása
                        Csomopont ujCsomopont = new Csomopont(ujAllapot, aktualisCsomopont);

                        if (!nyiltCsucsok.Contains(ujCsomopont) && !zartCsucsok.Contains(ujCsomopont))
                        {
                            nyiltCsucsok.Push(ujCsomopont);
                        }
                    }
                }
                zartCsucsok.Add(aktualisCsomopont);
            }

            if (nyiltCsucsok.Count > 0)
            {
                Csomopont celCsomopont = nyiltCsucsok.Peek();

                while (celCsomopont != null)
                {
                    this.Utvonal.Add(celCsomopont.Allapot);
                    celCsomopont = celCsomopont.Szulo;
                }

                this.Utvonal.Reverse();
            }
        }
    }
}
