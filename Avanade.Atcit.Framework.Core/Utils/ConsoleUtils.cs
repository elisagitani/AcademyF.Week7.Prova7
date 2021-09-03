using Avanade.Atcit.Framework.Core.Utils.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.Atcit.Framework.Core.Utils
{
    /// <summary>
    /// Utilities per la gestione della console
    /// </summary>
    public static class ConsoleUtils
    {
        /// <summary>
        /// Richiede la conferma di invio all'utente prima di procedere
        /// </summary>
        public static void AskforConfirm() 
        {
            //Richiesta di continuazione
            Console.Write("Premi invio per continuare...");
            Console.ReadLine();
        }

        /// <summary>
        /// Mostra un feedback colorato all'utente
        /// </summary>
        /// <param name="message">Messaggio</param>
        /// <param name="color">Colore del messaggio (default Green)</param>
        public static void Feedback(string message, ConsoleColor color = ConsoleColor.Green)
        {
            //Salvo il colore corrente
            var current = Console.ForegroundColor;

            //Stampo il messaggio
            Console.WriteLine();
            Console.Write($">>> ");

            //Imposto il nuovo colore
            Console.ForegroundColor = color;

            //Stampo il messaggio con il nuovo colore
            Console.Write(message);

            //Riporto il colore originale
            Console.ForegroundColor = current;

            //Ritorno a capo
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Scrive un messaggio colorato nella console
        /// </summary>
        /// <param name="color">Colore del messaggio</param>
        /// <param name="message">Messaggio</param>
        public static void WriteColor(ConsoleColor color, string message)
        {
            //Salvo il colore corrente
            var current = Console.ForegroundColor;

            //Imposto il nuovo colore
            Console.ForegroundColor = color;

            //Stampo il messaggio con il nuovo colore
            Console.Write(message);

            //Riporto il colore originale
            Console.ForegroundColor = current;
        }

        /// <summary>
        /// Richiede un input da console mostrando un messaggio utente;
        /// l'input viene validato dal delegato di validazione ("Func")
        /// e viene riproposto l'inserimento finchè il valore fornito non è valido
        /// </summary>
        /// <param name="userMessage">Messaggio utente</param>
        /// <param name="validationFunction">Delegato di validazione</param>
        /// <returns>Ritorna il valore valido</returns>
        public static string ReadInput(string userMessage, Func<string, bool> validationFunction)
        {
            //Validazione argomenti
            if (string.IsNullOrEmpty(userMessage)) throw new ArgumentNullException(nameof(userMessage));
            if (validationFunction == null) throw new ArgumentNullException(nameof(validationFunction));

            //Predisposizione della validazione fallita
            bool isInputValid = false;
            string input = null;

            //Finchè l'input non è valido, iterazione
            while (!isInputValid) 
            {
                //Stampo un messaggio per l'utente
                Console.Write($"{userMessage} : ");

                //Richiedo un inserimento
                input = Console.ReadLine();

                //Determino se l'input è valido o meno
                isInputValid = validationFunction(input);
            }

            //Ritorno l'input
            return input;
        }

        /// <summary>
        /// Esegue la renderizzazione di un menu dinamico per console
        /// </summary>
        /// <param name="title">Titolo del menu</param>
        /// <param name="menuSelections">Selezioni del menu</param>
        public static void RenderMenu(string title, IList<ConsoleMenuElement> menuSelections) 
        {
            //Validazione argomenti
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            if (menuSelections == null) throw new ArgumentNullException(nameof(menuSelections));

            //Verifico se è presente una opzione "x" che è riservata
            //e quindi non può essere utilizzata
            if (menuSelections.Any(e => e.Selection == "x"))
                throw new InvalidProgramException("L'opzione 'x' non è utilizzabile perchè è stata " +
                    "riservata per l'uscita dal menu");

            //Continua sempre a mostrare il menu finchè non ci
            //sono delle condizioni di uscita dalla funzione corrente
            while (true)
            {
                //Pulizia della console
                Console.Clear();

                //Renderizzazione del titolo del menu
                RenderTitle(title);

                //Opzioni di scelta
                Console.WriteLine("*");
                foreach (var current in menuSelections) 
                {
                    //Scrivo la struttura iniziale, il messaggio colorato
                    //con l'opzione e la descrizione presente nel dizionario
                    Console.Write("* - ");
                    WriteColor(ConsoleColor.Cyan, current.Selection);
                    Console.Write(") ");
                    Console.WriteLine(current.Description);
                }

                //Opzione per uscita dal programma
                Console.Write("* - ");
                WriteColor(ConsoleColor.Cyan, "x");
                Console.WriteLine(") Exit");
                Console.WriteLine("*");
                Console.WriteLine("".PadLeft(title.Length + 4, '*'));

                //Lettura della selezione
                Console.Write(" selezione >>> ");
                string scelta = Console.ReadLine();

                //Definizione delle selezioni permesse
                var allOptions = menuSelections.Select(c => c.Selection).ToList();
                allOptions.Add("x");

                //Se la selezione non è tra quelle permesse, prossima iterazione
                if (string.IsNullOrWhiteSpace(scelta) || !allOptions.Contains(scelta))
                    continue;

                //Altrimenti, se la selezione è "x", esco
                if (scelta == "x")
                    return;

                //Selezione dell'elemento corrispondente
                ConsoleMenuElement selectedElement = menuSelections
                    .SingleOrDefault(e => e.Selection == scelta);

                //Se la selezione non è stata trovata nuova iterazione
                if (selectedElement == null)
                    continue;

                //Avvio della funzione di selezione
                selectedElement.Action();
            }
        }

        /// <summary>
        /// Renderizza un titolo per la schermata corrente
        /// </summary>
        /// <param name="title">Titolo</param>
        /// <param name="color">Colore del titolo</param>
        public static void RenderTitle(string title, ConsoleColor color = ConsoleColor.Magenta)
        {
            //Validazione argomenti
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));

            //Visualizzazione del menu principale
            Console.WriteLine("".PadLeft(title.Length + 4, '*'));
            Console.Write($"* ");
            WriteColor(color, title);
            Console.WriteLine(" *");
            Console.WriteLine("".PadLeft(title.Length + 4, '*'));
        }
    }
}
