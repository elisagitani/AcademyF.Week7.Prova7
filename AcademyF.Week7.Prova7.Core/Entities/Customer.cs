using AcademyF.Week7.Prova7.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AcademyF.Week7.Prova7.Core.Entities
{
    [DataContract]
    public class Customer: IEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}
