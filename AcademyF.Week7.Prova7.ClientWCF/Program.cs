using Avanade.Atcit.Framework.Core.Utils;
using Avanade.Atcit.Framework.Core.Utils.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week7.Prova7.ClientWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.RenderMenu("Gestione Clienti", new List<ConsoleMenuElement>
            {
                new ConsoleMenuElement("a", "Creare un nuovo cliente", ()=>CustomerManager.Create()),
                new ConsoleMenuElement("b","Visualizzare tutti i clienti", ()=>CustomerManager.ShowList()),
                new ConsoleMenuElement("c","Visualizzare dettaglio cliente", ()=>CustomerManager.GetCustomer()),
                new ConsoleMenuElement("d","Modificare un cliente", ()=>CustomerManager.UpdateCustomer()),
                new ConsoleMenuElement("e","Eliminare un cliente", ()=>CustomerManager.DeleteCustomer()),
            });
        }
    }
}
