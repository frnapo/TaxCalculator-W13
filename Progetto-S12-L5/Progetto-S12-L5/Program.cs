using System;

namespace Progetto_S12_L5
{
    internal class Program
    {
        static bool esci = false;
        static void Main(string[] args)
        {
            while (!esci)
            {
                // switch con menu principale
                Console.WriteLine("====================================================================");
                Console.WriteLine("               A G E N Z I A   D E L L E   E N T R A T E            ");
                Console.WriteLine("====================================================================");
                Console.WriteLine("\nBenvenuto nel programma di gestione dei contribuenti\n");
                Console.WriteLine("Premi 1 per inserire contribuente e calcolare l'imposta da pagare");
                Console.WriteLine("Premi 2 per effettuare altre operazioni");
                Console.WriteLine("Premi 3 per uscire\n");
                Console.WriteLine("====================================================================");
                Console.WriteLine("    P R E M I   U N   T A S T O   S E G U I T O   D A   I N V I O   ");
                Console.WriteLine("====================================================================\n");
                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        Contribuente.InserisciContribuenteECalcolaImposta();
                        break;
                    case "2":
                        Console.WriteLine("\nAl momento non sono disponibili altre operazioni, premi un tasto per continuare...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        esci = true;
                        break;
                    default:
                        Console.WriteLine("\nScelta non valida, premi un tasto per continuare...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
