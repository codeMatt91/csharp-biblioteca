using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Utente : Persona
    {
        
        private string email;
        public string Email { get => email; set => email = value; }

        private string password;
        public string Password { get => password; set => password = value; }

        public Utente(string Nome, string Cognome, string Cell,string email, string password) : base(Nome,Cognome,Cell)
        { 
            Email = email;
            Password = password;

        }

        public bool CercaUtente(Utente utente, Dictionary<string, Utente> listaUtenti)
        { 
            
        }
    }
}
