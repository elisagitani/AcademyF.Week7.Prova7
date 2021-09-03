namespace Avanade.Atcit.Framework.Core.Utils
{
    /// <summary>
    /// Utilità per la gestione delle stringhe 
    /// la loro manipolazione
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Esegue la rimozione dalla stringa passata di tutti
        /// i caratteri non permessi in un valore intero
        /// </summary>
        /// <param name="source">Stringa sorgente</param>
        /// <returns>Ritorna una stringa pulita</returns>
        public static string CleanInvalidChars(string source)
        {
            //20€
            //[0] = "2"
            //[1] = "0"
            //[2] = "€"

            //Definizione dei caratteri permessi
            const string AllowedChars = "0123456789";

            //Stringa con i caratteri uscita
            string outputChars = "";

            //Scorro tutti i caratteri nella stringa e conservo
            //esclusivamente quelli che sono numeri
            for (int i = 0; i <= source.Length - 1; i++)
            {
                //Recupero il carattere corrente
                string currentChar = source.Substring(i, 1);

                //Se il carattere è ammesso (ovvero è tra 0 e 9)
                //lo mando in uscita, altrimenti passo al prossimo
                if (AllowedChars.Contains(currentChar))
                {
                    //Aggiungo il carattere corrente nella stringa di uscita
                    outputChars = outputChars + currentChar;
                }
            }

            //Mando in uscita solo i caratteri permessi
            return outputChars;
        }
    }
}
