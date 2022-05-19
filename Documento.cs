using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Documento
    {
        private string titolo;
        public string Titolo { get => titolo; set => titolo = value; }

        private int anno;
        public int Anno { get => anno; set => anno = value; }

        public enum Stato { Disponibile = 1, Indisponibile = 0 }

        private string scaffale;
        public string Scaffale { get => scaffale; set => scaffale = value; }

        private List<string> autori;

        public List<string> Autori { get => autori; set => autori = value; }



        public Documento(string titolo, int anno, string scaff, List<string> author )
        { 
            this.Titolo = titolo;
            this.Anno = anno;
            this.scaffale = scaff;
            this.Autori = author;
            //enum stato { Disponibile };

    }


        public override string ToString()
        {
            return string.Format("Codice:{0}\nTitolo:{1}\nSettore:{2}\nStato:{3}\nScaffale numero:{4}",

                this.Titolo,
                this.Anno,
                this.Scaffale,
                this.Autori);
        }


    }
}
