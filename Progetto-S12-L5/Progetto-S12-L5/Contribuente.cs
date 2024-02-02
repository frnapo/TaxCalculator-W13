using System;

namespace Progetto_S12_L5
{
    internal class Contribuente
    {
        public static string Nome { get; set; }
        public static string Cognome { get; set; }
        public static string DataNascita { get; set; }
        public static string CodiceFiscale { get; set; }
        public static char Sesso { get; set; }
        public static string Residenza { get; set; }
        public static decimal RedditoAnn { get; set; }


        // metodo per inserire un contribuente e calcolare l'imposta da pagare, avrei potuto scomporlo in piu metodi D: ma ho preferito tenerlo cosi' per praticita'
        public static void InserisciContribuenteECalcolaImposta()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // controllo che l'utente non lasci il campo nome vuoto
            Console.WriteLine("\n----- Inserisci il NOME del contribuente (eg. Mario) -----\n"); // non dichiaro il tipo di dato perche' sono static, aggiorno semplicemente le sue proprieta'
            Nome = Console.ReadLine();

            if (Nome == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Errore: Inserire un nome valido");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
                return;
            }


            // controllo che l'utente non lasci il campo cognome vuoto
            Console.WriteLine("\n----- Inserisci il COGNOME del contribuente (eg. Rossi) -----\n");
            Cognome = Console.ReadLine();

            if (Cognome == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Errore: Inserire un cognome valido");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
                return;
            }



            // la data formata da GG/MM/AAAA sono 10 caratteri, controllo che vengano inseriti correttamente leggendo la lunghezza
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n-----Inserisci la DATA DI NASCITA del contribuente formato GG/MM/AAAA (eg. 15/07/1961) -----\n");
                DataNascita = Console.ReadLine();

                if (DataNascita.Length != 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLa data dev'essere in formato GG/MM/AAAA. Riprovare.\n");
                }
            } while (DataNascita.Length != 10);



            // do while per ciclare almeno 1 volta e ripetere se il CF e' miner di 16 caratteri
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n----- Inserisci il CODICE FISCALE del contribuente (eg. MRORSI61LIKSNNNS) -----\n");
                CodiceFiscale = Console.ReadLine().ToUpper();

                if (CodiceFiscale.Length != 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nIl codice fiscale deve essere composto da 16 caratteri. Riprovare.\n");
                }
            } while (CodiceFiscale.Length != 16);


            // ho inserito il try catch dopo, perche' ho notato che se davo invio senza inserire nulla, il programma andava in errore
            try
            {
                // do while per ciclare almeno 1 volta e ripetere se l'input dell'utente non va bene
                do
                {
                    Console.WriteLine("\n----- Inserisci il GENERE del contribuente -----\n\nM = MASCHILE\n\nF = FEMMINILE\n\n-----SEGUITO DA INVIO-----\n");
                    Sesso = Convert.ToChar(Console.ReadLine().ToUpper());
                } while (Sesso != 'M' && Sesso != 'F');
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Errore: Inserire un valore valido");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
                return;
            }


            // controllo che l'utente non lasci il campo residenza vuoto
            Console.WriteLine("\n----- Inserisci il COMUNE DI RESIDENZA del contribuente (eg. Palermo)-----\n");
            Residenza = Console.ReadLine().ToUpper();

            if (Residenza == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Errore: Inserire un comune di residenza valido");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            // controllo se l'utente inserisce un valore numerico e in caso si restituisce un errore
            Console.WriteLine("\n----- Inserisci il REDDITO ANNUO del contribuente (eg. 17.850,00) -----\n");
            try
            {
                RedditoAnn = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Errore: Inserire un valore numerico valido");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
                return;
            }



            //calcolo dell'imposta in base al reddito annuo e la salvo in una variabile che mostre successivamente all'utente
            decimal imposta = 0;
            if (RedditoAnn <= 15000)
            {
                imposta = RedditoAnn * 0.23m;
            }
            else if (RedditoAnn > 15000 && RedditoAnn <= 28000)
            {
                imposta = 3450 + (RedditoAnn - 15000) * 0.27m; //m serve per convertire il valore in decimal, prima dava errore su operazioni
            }
            else if (RedditoAnn > 28000 && RedditoAnn <= 55000)
            {
                imposta = 6960 + (RedditoAnn - 28000) * 0.38m;
            }
            else if (RedditoAnn > 55000 && RedditoAnn <= 75000)
            {
                imposta = 17220 + (RedditoAnn - 55000) * 0.41m;
            }
            else if (RedditoAnn > 75000)
            {
                imposta = 25420 + ((RedditoAnn - 75000) * 0.43m);
            }


            Console.WriteLine("\nNome: " + Nome);
            Console.WriteLine("Cognome: " + Cognome);
            Console.WriteLine("Data di nascita: " + DataNascita);
            Console.WriteLine("Codice fiscale: " + CodiceFiscale);
            Console.WriteLine("Sesso: " + Sesso);
            Console.WriteLine("Residenza: " + Residenza);
            Console.WriteLine("Reddito annuo: Euro " + RedditoAnn);


            // mostro le informazioni all'utente e chiedo conferma per evitare errori
            // se l'utente conferma si procede al calcolo dell'imposta
            // se l'utente non conferma si ripete la procedura
            Console.WriteLine("Le informazioni fornite sono corrette? (Y/N)\n");
            string conferma = Console.ReadLine().ToUpper();

            if (conferma == "Y")
            {
                Console.Clear();
                Console.WriteLine("\n==================================================");
                Console.WriteLine("C A L C O L O   I M P O S T A   D A   P A G A R E");
                Console.WriteLine("==================================================\n");
                Console.WriteLine($"Contribuente: {Nome} {Cognome},\n");
                Console.WriteLine($"Nato il {DataNascita}({Sesso}),\n");
                Console.WriteLine($"Residente in {Residenza},\n");
                Console.WriteLine($"Codice fiscale: {CodiceFiscale}\n");
                Console.WriteLine($"Reddito dichiarato: Euro {RedditoAnn}\n");
                Console.WriteLine($"Imposta da versare: Euro {imposta} \n");
                Console.WriteLine("==================================================");
                Console.WriteLine("==================================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDacci i tuoi soldi :)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
            }
            else if (conferma == "N")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSi prega di ripetere la procedura e reinserire i dati.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPremere invio per continuare...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nScelta non valida, premi un tasto per continuare...");
                Console.ReadKey();
                Console.Clear();
            }

        }

    }

}
