using Avanade.Atcit.Framework.Core.Utils;
using Avanade.Atcit.Framework.Core.Utils.Structures;
using System;
using System.Collections.Generic;

namespace AcademyF.Week7.Prova7.APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Week 4 - Test API ===");

            Console.WriteLine("Premi un tasto quando le API sono partite.");
            Console.ReadKey();

            Console.Clear();

            ConsoleUtils.RenderMenu("Gestione Ordini", new List<ConsoleMenuElement>
            {
                new ConsoleMenuElement("a", "Creare un nuovo ordine", ()=>OrderManager.Create()),
                new ConsoleMenuElement("b","Visualizzare tutti gli ordini", ()=> OrderManager.ShowList()),
                new ConsoleMenuElement("c","Visualizzare dettaglio ordine", ()=>OrderManager.GetOrder()),
                new ConsoleMenuElement("d","Modificare un ordine", ()=>OrderManager.UpdateOrder()),
                new ConsoleMenuElement("e","Eliminare un ordine", ()=>OrderManager.DeleteOrder()),
                new ConsoleMenuElement("f","Visualizzare ordini di un cliente", ()=>OrderManager.FetchCustomerOrders()),
            });
        }

        //TODO: Creare una vista su database per il report degli ordini
        //importare la vista nel dbContext e fare mapping con fluent api
        //nel BL creare un metodo Fetch che restituisca gli elementi della vista creata 
    }
}
