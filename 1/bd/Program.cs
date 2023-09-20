using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bd
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Avtor());
        }
    }
    static class Database
    {
        public static string connection = @"Data Source=db.db; Integrated Security=False; MultipleActiveResultSets=True";
    }
    static class Name_table
    {
        public static string main = "Name";
        public static string ID = "ID";
        public static string NmId = "NamId ";

    }
    static class Photo_table
    {
        public static string main = "Foto";
        public static string ID = "ID";
        public static string Foto1 = "Foto1";
        public static string Foto2 = "Foto2";
    }
    static class User_table
    {
        public static string main = "User";
        public static string ID = "ID";
        public static string Name = "Name";
        public static string Pass = "Pass";

    }
}
