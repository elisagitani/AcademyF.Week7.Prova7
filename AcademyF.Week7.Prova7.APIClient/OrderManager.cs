using Avanade.Atcit.Framework.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AcademyF.Week7.Prova7.APIClient
{
    public static class OrderManager
    {
        static HttpClient client = new HttpClient();
        internal async static void Create()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Creazione di un nuovo ordine");

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost:44333/api/order")
            };

            var code = Guid.NewGuid().ToString();
            string productCode;
            do
            {
                Console.Write("Codice Prodotto: ");
                productCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(productCode));

            decimal importo;
            do
            {
                Console.Write("Importo: ");
            } while (!decimal.TryParse(Console.ReadLine(), out importo));

            int idCliente;
            do
            {
                Console.Write("ID Cliente: ");
            } while (!int.TryParse(Console.ReadLine(), out idCliente));

            OrderContract newOrder = new OrderContract
            {
                OrderCode = code,
                ProductCode = productCode,
                OrderDate = DateTime.Now,
                Amount = importo,
                CustomerId = idCliente
            };

            string jsonBody = JsonConvert.SerializeObject(newOrder);
            request.Content = new StringContent(    //BODY
                jsonBody,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderContract>(jsonResponse);
                ConsoleUtils.Feedback("\nOrder successfully created");
            }
        }

        internal async static void FetchCustomerOrders()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Visualizzazione di tutti gli ordini di un cliente");

            Console.Write("ID Cliente: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44333/api/order/{id}/customer")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonResponse);
                var data = JsonConvert.DeserializeObject<List<OrderContract>>(jsonResponse);

                foreach (OrderContract order in data)
                    Console.WriteLine($"\n[{order.Id}] " +
                        $"ORDER CODE: {order.OrderCode} \nPRODUCT CODE: {order.ProductCode} \nORDER DATE: {order.OrderDate} \nAMOUNT: {order.Amount} euro");
            }
        }

        internal async static void ShowList()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Visualizzazione di tutti gli ordini");

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44333/api/order")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonResponse);
                var data = JsonConvert.DeserializeObject<List<OrderContract>>(jsonResponse);

                foreach (OrderContract order in data)
                    Console.WriteLine($"\n[{order.Id}] " +
                        $"ORDER CODE: {order.OrderCode} \nPRODUCT CODE: {order.ProductCode} \nORDER DATE: {order.OrderDate} \nAMOUNT: {order.Amount} euro");
            }
        }

        internal async static void GetOrder()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Visualizzazione dettaglio ordine");

         
            Console.Write("ID Ordine: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id); 

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44333/api/order/{id}")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonResponse);
                var order = JsonConvert.DeserializeObject<OrderContract>(jsonResponse);

                if(order!=null)
                    Console.WriteLine($"\n[{order.Id}] " +
                       $"ORDER CODE: {order.OrderCode} \nPRODUCT CODE: {order.ProductCode} \nORDER DATE: {order.OrderDate} \nAMOUNT: {order.Amount} euro");
            }
        }

        internal async static void UpdateOrder()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Modifica di un ordine");
            Console.Write("ID Ordine: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:44333/api/order/{id}")
            };


            string productCode;
            do
            {
                Console.Write("Codice Prodotto: ");
                productCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(productCode));

            string orderCode;
            do
            {
                Console.Write("Codice Ordine: ");
                orderCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(orderCode));


            DateTime orderDate;
            Console.Write("Data Ordine: ");
            orderDate =DateTime.Parse(Console.ReadLine());

            decimal importo;
            do
            {
                Console.Write("Importo: ");
            } while (!decimal.TryParse(Console.ReadLine(), out importo));

            int idCliente;
            do
            {
                Console.Write("ID Cliente: ");
            } while (!int.TryParse(Console.ReadLine(), out idCliente));


            OrderContract editedOrder = new OrderContract
            {
                Id = id,
                OrderCode = orderCode,
                ProductCode = productCode,
                OrderDate = orderDate,
                Amount = importo,
                CustomerId = idCliente
            };

            string jsonBody = JsonConvert.SerializeObject(editedOrder);
            request.Content = new StringContent(    //BODY
                jsonBody,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<OrderContract>(jsonResponse);
                Console.WriteLine($"\n[{order.Id}] " +
                       $"ORDER CODE: {order.OrderCode} \nPRODUCT CODE: {order.ProductCode} \nORDER DATE: {order.OrderDate} \nAMOUNT: {order.Amount} euro");

            }
        }

        internal async static void DeleteOrder()
        {
            Console.Clear();
            ConsoleUtils.RenderTitle("Eliminazione di un ordine");
            Console.Write("ID: ");
            string idVal = Console.ReadLine();
            int.TryParse(idVal, out int id);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:44343/api/book/{id}")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                ConsoleUtils.Feedback($"\nOrder with ID = {id} successfully deleted");
            }

        }
    }
}
