using System;

namespace Avanade.Atcit.Framework.Core.Utils.Structures
{
    /// <summary>
    /// Elemento della menu di console
    /// </summary>
    public class ConsoleMenuElement
    {
        /// <summary>
        /// Selezione dell'elemento (ex. "a")
        /// </summary>
        public string Selection { get; }

        /// <summary>
        /// Descrizione per l'utente
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Azione da avviare
        /// </summary>
        public Action Action { get; }

        /// <summary>
        /// Inizializza l'elemento di menu
        /// </summary>
        /// <param name="selection">Selezione</param>
        /// <param name="description">Descrizione</param>
        /// <param name="action">Azione da avviare</param>
        public ConsoleMenuElement(string selection, string description, Action action)
        {
            //Validazione argomenti
            if (string.IsNullOrEmpty(selection)) throw new ArgumentNullException(nameof(selection));
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            if (action == null) throw new ArgumentNullException(nameof(action));

            //Assegnazione alle proprietà
            Selection = selection;
            Description = description;
            Action = action;
        }        
    }
}
