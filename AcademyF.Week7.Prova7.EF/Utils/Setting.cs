using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week7.Prova7.EF.Utils
{
    public static class Setting
    {
        public static string GetConnectionString()
        {
            return @"Data Source= (localdb)\mssqllocaldb;" +
                                            "Initial Catalog = E-Commerce;" +
                                            "Integrated Security=true;";
        }
    }
}
