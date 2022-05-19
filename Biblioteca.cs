using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Biblioteca
    {
        private string nome;
        public string Nome { get => nome; set => nome = value; }
        public Dictionary<string, Documento> Documenti { get; set; }
        public Dictionary<string, Utente> Utenti { get; set; }


        public Biblioteca(string Nome, Dictionary<string, Documento> documenti, Dictionary<string, Utente> utenti)
        {
            this.Nome = Nome;
            this.Documenti = documenti;
            this.Utenti = utenti;
        }
        


    }
}
