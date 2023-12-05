
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSnooker
{
    public class Versenyzo
    {
        int helyezes;
        string nev;
        string orszag;
        int nyeremeny;


       
        public Versenyzo(int helyezes, string nev, string orszag, int nyeremeny)
        {
            this.helyezes = helyezes;
            this.nev = nev;
            this.orszag = orszag;
            this.nyeremeny = nyeremeny;
        }

        public int Helyezes { get => helyezes; }
        public string Nev { get => nev; }
        public string Orszag { get => orszag; }
        public int Nyeremeny { get => nyeremeny; }
    }
}
