using AcademyF.Week7.Prova7.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week7.Prova7.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(CommerceService)))
            {
                host.Open();

                Console.WriteLine("--------WCF RUNNING-------");
                Console.WriteLine("\nPress any key to end....");
                Console.ReadKey();

            }
        }
    }
}
