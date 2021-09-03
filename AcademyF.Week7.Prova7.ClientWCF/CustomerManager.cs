using AcademyF.Week7.Prova7.Core.Entities;
using Avanade.Atcit.Framework.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week7.Prova7.ClientWCF
{
    public static class CustomerManager
    {
        internal static void Create()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Creazione di un nuovo cliente");
            CommerceReference.CommerceServiceClient client = new CommerceReference.CommerceServiceClient();
            string name;
            string lastName;
            do
            {
                Console.Write("\nNome: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("Cognome: ");
                lastName = Console.ReadLine();
            } while (string.IsNullOrEmpty(lastName));

            var code = Guid.NewGuid().ToString();

            bool result = client.CreateCustomer(new CommerceReference.Customer
            {

                CustomerCode = code,
                FirstName = name,
                LastName = lastName

            });

            if (result)
            {
                ConsoleUtils.Feedback("Cliente aggiunto correttamente", ConsoleColor.Green);
                ConsoleUtils.AskforConfirm();
            }
            else
            {
                ConsoleUtils.Feedback("ERRORE- Invalid Operation", ConsoleColor.Red);
                ConsoleUtils.AskforConfirm();
            }
        }

        internal static void ShowList()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Visualizzazione lista clienti");
            CommerceReference.CommerceServiceClient client = new CommerceReference.CommerceServiceClient();

            List<CommerceReference.Customer> list = client.FetchAllCustomers();

            Console.WriteLine();
            foreach (var item in list)
                Console.WriteLine($"[{item.Id}] \nCustomer Code: {item.CustomerCode} \nName: {item.FirstName} {item.LastName}");
            Console.WriteLine();
            ConsoleUtils.AskforConfirm();
        }

        internal static void GetCustomer()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Visualizza dettaglio cliente");

            Console.Write("ID Cliente: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            CommerceReference.CommerceServiceClient client = new CommerceReference.CommerceServiceClient();

            var customer = client.GetCustomerById(id);
            if (customer == null)
            {
                ConsoleUtils.Feedback("Customer NOT FOUND", ConsoleColor.Red);
                Console.WriteLine();
                ConsoleUtils.AskforConfirm();
            }
            else
            {
                Console.WriteLine($"\n[{customer.Id}] \nCustomer Code: {customer.CustomerCode} \nName: {customer.FirstName} {customer.LastName}");
                Console.WriteLine();
                ConsoleUtils.AskforConfirm();
            }

        }

        internal static void UpdateCustomer()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Modifica i dati di un cliente");

            Console.Write("ID Cliente: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            CommerceReference.CommerceServiceClient client = new CommerceReference.CommerceServiceClient();

            var customer = client.GetCustomerById(id);
            if (customer == null)
            {
                ConsoleUtils.Feedback("Customer NOT FOUND", ConsoleColor.Red);
                Console.WriteLine();
                ConsoleUtils.AskforConfirm();
            }
            else
            {
                ConsoleUtils.Feedback("Dati Cliente selezionato");
                Console.WriteLine($"[{customer.Id}] \nCustomer Code: {customer.CustomerCode} \nName: {customer.FirstName} {customer.LastName}");


                Console.Write("\nNome: ");
                string updatedName = Console.ReadLine();
                string name = (updatedName == "") ? customer.FirstName : updatedName;
                Console.Write("Cognome: ");
                string updatedLastname = Console.ReadLine();
                string lastName = (updatedLastname == "") ? customer.LastName : updatedLastname;


                bool result = client.UpdateCustomer(new CommerceReference.Customer
                {

                    Id = id,
                    CustomerCode = customer.CustomerCode,
                    FirstName = name,
                    LastName = lastName
                });

                if (result)
                {
                    ConsoleUtils.Feedback("Cliente modificato correttamente", ConsoleColor.Green);
                    ConsoleUtils.AskforConfirm();
                }
                else
                {
                    ConsoleUtils.Feedback("ERRORE- Invalid Operation", ConsoleColor.Red);
                    ConsoleUtils.AskforConfirm();
                }
            }

        }

        internal static void DeleteCustomer()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Eliminare un cliente");

            Console.Write("ID Cliente: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            CommerceReference.CommerceServiceClient client = new CommerceReference.CommerceServiceClient();

            var customer = client.GetCustomerById(id);
            if (customer == null)
            {
                ConsoleUtils.Feedback("Customer NOT FOUND", ConsoleColor.Red);
                Console.WriteLine();
                ConsoleUtils.AskforConfirm();
            }
            else
            {
                ConsoleUtils.Feedback("Dati Cliente selezionato");
                Console.WriteLine($"[{customer.Id}] \nCustomer Code: {customer.CustomerCode} \nName: {customer.FirstName} {customer.LastName}");

                bool result = client.DeleteCustomerById(id);

                if (result)
                {
                    ConsoleUtils.Feedback("Cliente eliminato correttamente", ConsoleColor.Green);
                    ConsoleUtils.AskforConfirm();
                }
                else
                {
                    ConsoleUtils.Feedback("ERRORE- Invalid Operation", ConsoleColor.Red);
                    ConsoleUtils.AskforConfirm();
                }

            }
        }
    }
}
