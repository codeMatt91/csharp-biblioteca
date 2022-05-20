using System;
using System.IO;


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

            // Definisco le librerie ed i Dizionari

            Dictionary<string, Dvd> Dictdvd = new Dictionary<string, Dvd>();
            Dictionary<string, Libro> Dictlibri = new Dictionary<string, Libro>();
            Dictionary<string, Utente> Dictutenti = new Dictionary<string, Utente>();
            List<Prestito> listPrestiti = new List<Prestito>();


            Biblioteca b = new Biblioteca("Civica", Dictlibri, Dictdvd, Dictutenti, listPrestiti);

           
            // Qui sto leggendo i dati dal file e ripopolando gli utenti

            //if (File.Exists("biblioteca.txt"))
            //    b.RestoreUtenti("biblioteca.txt");
            //else
            //    Console.WriteLine("Il file non esiste");

            

            Utente u1 = new Utente("Nome 1", "Cognome 1", "34234344", "Email 1", "Password 1");
            Utente u2 = new Utente("Nome 2", "Cognome 2", "78677867", "Email 2", "Password 2");
            Utente u3 = new Utente("Nome 3", "Cognome 3", "46797675", "Email 3", "Password 3");

            Libro l1 = new Libro("Harry Potter", 2000, "Scaffale A", "KJ Rowling", "3478974gggjjd", "Fantasy", 345);
            Dvd dvd1 = new Dvd("Queen", 1987, "Scaffale A", "Queen", "7689", "Rock", 3.35);
            

            

            b.AggiungiUtente(u1);
            b.AggiungiUtente(u2);
            b.AggiungiUtente(u3);

            // GESTIONE FILE DI CONFIGURAZIONE
            string vPublic = Environment.GetEnvironmentVariable("PUBLIC");
            if (vPublic != null)
                Console.WriteLine("variabile d'ambiente {0}", vPublic);

            vPublic += "\\Biblioteca";

            //Verifico se il file biblioteca esiste nella variabile d'ambiente, se non esiste creo la cartella Biblioteca

            

            if (!Directory.Exists(vPublic))
            {

                Console.WriteLine("Dove sono storati i file?");
                Console.WriteLine("Sul computer centrale (C3): premi 1");
                Console.WriteLine("Sul sul tuo computer: premi 2");

                string choise = Console.ReadLine();
                int chouseUser = Convert.ToInt32(choise);


                if (chouseUser == 1)
                {
                    Directory.CreateDirectory(vPublic);
                    Console.WriteLine("Ho creato la cartella");

                    string pathCompleto = vPublic + "\\biblioteca.txt";


                    //CREO IL FILE NELLA CARTELLA BIN DOVE MI SEGNO IL PATH DELLA CARTELLA DEL COMPUTER REMOTO
                    StreamWriter sr = new StreamWriter("biblioteca.txt");
                    sr.WriteLine("section:" + pathCompleto);

                    sr.Close();
                }
                else if (chouseUser == 2)
                {
                    //CREO IL FILE NEL MIO COMPUTER E LO USO COME DATABASE PER SCRIVERE I DATI 
                    StreamWriter sr = new StreamWriter("biblioteca.txt");
                    
                    foreach (KeyValuePair<string, Utente> entry in Dictutenti)
                    {
                        sr.WriteLine(entry.Value.Nome + ":" + entry.Value.Cognome + ":" +
                            entry.Value.Cell + ":" + entry.Value.Email + ":" + entry.Value.Password);

                    }
                    sr.Close();
                }
                
            }
            else
            {
                
                Console.WriteLine("la directory esiste");
                if (Directory.Exists(vPublic + "biblioteca.txt"))
                {
                    //QUI LEGGERO I DATI DAL FILE e mi estrapolo il percorso per andare a leggere i file
                


            }

            b.AggiungiDvd(dvd1);
            b.AggiungiLibro(l1);
           
            
            b.AggiungiPrestito(u1, l1);
            
            
            
            foreach (Prestito doc in listPrestiti)
            {
                Console.WriteLine("=========== Prestito =============");
                Console.WriteLine(doc.ToString());
                
            }
            

            //Console.WriteLine("\n\nSearchPrestiti: Nome 1, Cognome 1\n\n");
            //List<Prestito> prestiti = b.SearchPrestiti("Nome 1", "Cognome 1");
            //foreach (Prestito p in prestiti)
            //{
            //    Console.WriteLine(p.ToString());
            //    Console.WriteLine("--------------------------");
            //}
        }
    }
}