using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurplecometWebpage.Utils
{
    /**
     * Esta clase se utiliza como referencia de las rutas de configuracion
     */
    public static class Config
    {
        //private static string connectionString = @"Server=ADM-08\SQLEXPRESS; Database = purplecomet; Trusted_Connection = True;";
        private static string connectionString = @"Server=ADM-08\SQLEXPRESS; Database = purplecomet; uid=necromancer; password=abracadabra; Trusted_Connection = True;";
        private static string logsPath = @"D:\xampp\htdocs\purplecomet\logs";

        public static string ConnectionString { get => connectionString; set => connectionString = value; }
        public static string LogsPath { get => logsPath; set => logsPath = value; }
    }
}