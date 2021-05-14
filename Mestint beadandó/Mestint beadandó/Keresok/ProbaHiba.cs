using Mestint_beadandó.Allapotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint_beadandó.Keresok
{
    class ProbaHiba : Kereso
    {
        public ProbaHiba()
        {
            Kereses();
        }

        // Keresés
        public override void Kereses()
        {
            Allapot kezdoAllapot = new Allapot();
            List<Allapot> ut = new List<Allapot>();
            ut.Add(kezdoAllapot);
            Random random = new Random();

            // Meddig
            while (!ut.Last().celfeltetel())
            {
                int randomIndex = random.Next(0, Operatorok.Count);
                Operator valasztottOperator = Operatorok[randomIndex];

                if (valasztottOperator.Elofeltetel(ut.Last()))
                {
                    Allapot ujAllapot = valasztottOperator.BabuMozdit(ut.Last());
                    ut.Add(ujAllapot);
                }
            }

            // Állapotok hozzáadása az útvonalhoz
            foreach (Allapot allapot in ut)
            {
                Utvonal.Add(allapot);
            }

        }
    }
}
