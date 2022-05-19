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
        public Dictionary<string, Libro> Libri { get; set; }
        public Dictionary<string, Dvd> Dvd { get; set; }
        public Dictionary<string, Utente> Utenti { get; set; }


        public Biblioteca(string Nome, Dictionary<string, Libro> libri, Dictionary<string, Dvd> dvd, Dictionary<string, Utente> utenti)
        {
            this.Nome = Nome;
            this.Libri = libri;
            this.Dvd = dvd;
            this.Utenti = utenti;
        }


        public void AggiungiUtente(Utente utente)
        { 
            string nome = utente.Nome;
            string cognome = utente.Cognome;
            string email = utente.Email;

            string key = nome + ";" + cognome + ";" + email;

            Utenti.Add(key, utente);
        }


        public void CercaUtente(Utente utente)
        {
            string key = utente.Nome + ";" + utente.Cognome + ";" + utente.Email;

            try
            {
                if (Utenti.ContainsKey(key))
                    Console.WriteLine("L'utente e presente nel sistema");
                else
                    Console.WriteLine("L'utente non e presente nel sistema");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
