using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleviproject
{
    class Tanulo
    {
        public string Nev { get; set; }
        public string Azonosito { get; set; }
        public List<int> Jegyek { get; set; }
        public double TanuloAtlag { get; set; }

        public Tanulo(string sor)
        {
            var v = sor.Split("\t");
            this.Nev = v[0];
            this.Azonosito = v[1];
            this.Jegyek = new List<int>();
            for (int i = 2; i < v.Length; i++)
            {
                this.Jegyek.Add(int.Parse(v[i]));
            }
            this.TanuloAtlag = this.Jegyek.Average();
            

        }

        public override string ToString()
        {
            return $"{Nev} | {TanuloAtlag}";
        }
    }

}
