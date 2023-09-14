using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA230911
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public bool Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontszamok { get; set; }

        public int Osszpontszam 
        {
            get
            {
                Array.Sort(Pontszamok);
                int op = 0;
                if (Pontszamok[0] > 0) op += 10;
                if (Pontszamok[1] > 0) op += 10;
                for (int i = 2; i < Pontszamok.Length; i++)
                    op += Pontszamok[i];

                return op;
            }
        }

        public Versenyzo(string r)
        {
            var v = r.Split(';');
            Nev = v[0];
            Kategoria = v[1] == "Felnott ferfi";
            Egyesulet = v[2] == "n.a." ? null : v[2];
            Pontszamok = new int[8];
            for (int i = 3; i < v.Length; i++)
            {
                Pontszamok[i - 3] = int.Parse(v[i]);
            }

            //for (int i = 0; i < v.Length; i++)
            //{
            //    Pontszamok[i] = int.Parse(v[i + 3]);
            //}
        }

    }
}
