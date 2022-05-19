using System;

/*
Si vuole progettare un sistema per la gestione di una biblioteca.
Gli utenti registrati al sistema, fornendo cognome, nome, email, password, recapito telefonico,
possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD).

I documenti sono caratterizzati da un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD), titolo, anno, settore (storia, matematica, economia, …),
stato (In Prestito, Disponibile), uno scaffale in cui è posizionato, un elenco di autori (Nome, Cognome).

Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
Il sistema per ogni prestito determina un numero progressivo di tipo alfanumerico.
Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.

*/
namespace csharp_biblioteca // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
                   
            
            Utente u1 = new Utente("Nome 1", "Cognome 1", "34234344", "Email 1", "Password 1");
           
            Libro l1 = new Libro("Harry Potter", 2000, "Scaffale A", "KJ Rowling", "3478974gggjjd", "Fantasy", 345);
            Dvd dvd1 = new Dvd("Queen", 1987, "Scaffale A", "Queen", "7689", "Rock", 3.35);
            
            Dictionary<string, Dvd> Dictdvd = new Dictionary<string, Dvd>();
            Dictionary<string, Libro> Dictlibri = new Dictionary<string, Libro>();
            Dictionary<string, Utente> Dictutenti = new Dictionary<string, Utente>();
            List<Prestito> listPrestiti = new List<Prestito>();

            
            Biblioteca b = new Biblioteca("Civica", Dictlibri, Dictdvd, Dictutenti, listPrestiti);
            
            ;
            dvd1.Autori.Add(a3);
            dvd1.Scaffale = s3;
            b.Documenti.Add(dvd1);
            #endregion
            b.Utenti.Add(u1);
            Prestito p1 = new Prestito("P00001", new DateTime(2019, 1, 20), new DateTime(2019, 2, 20), u1, l1);
            Prestito p2 = new Prestito("P00002", new DateTime(2019, 3, 20), new DateTime(2019, 4, 20), u1, l2);
            b.Prestiti.Add(p1);
            b.Prestiti.Add(p2);
            Console.WriteLine("\n\nSearchByCodice: ISBN1\n\n");
            List<Documento> results = b.SearchByCodice("ISBN1");
            foreach (Documento doc in results)
            {
                Console.WriteLine(doc.ToString());
                if (doc.Autori.Count > 0)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Autori");
                    Console.WriteLine("--------------------------");
                    foreach (Autore a in doc.Autori)
                    {
                        Console.WriteLine(a.ToString());
                        Console.WriteLine("--------------------------");
                    }
                }
            }
            Console.WriteLine("\n\nSearchPrestiti: Nome 1, Cognome 1\n\n");
            List<Prestito> prestiti = b.SearchPrestiti("Nome 1", "Cognome 1");
            foreach (Prestito p in prestiti)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("--------------------------");
            }
        }
    }
}