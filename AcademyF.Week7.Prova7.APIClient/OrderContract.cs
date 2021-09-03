using System;

namespace AcademyF.Week7.Prova7.APIClient
{
    public class OrderContract
    {

        public int Id { get; set; }


        public DateTime OrderDate { get; set; }


        public string OrderCode { get; set; }


        public string ProductCode { get; set; }


        public decimal Amount { get; set; }


        public int CustomerId { get; set; }
    }
}