using AcademyF.Week7.Prova7.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyF.Week7.Prova7.Core.Entities
{
    [DataContract]
    public class Order:IEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public string OrderCode { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
