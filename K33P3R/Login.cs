using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace K33P3R
{
    class Login
    {
        Core core = new Core();
        Updater updater = new Updater();

        public void Main()
        {
            string _version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.Clear();
            Console.Title = "Password K33PER - Login";

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine(" << Keep & Secure by xGabbro & Aspired v." + _version + " >> ");
            Console.WriteLine("-----------------------------------------------------------" + "\n");

            Console.Write("Inserisci la password per accedere: ");
            string _pass = Console.ReadLine(); 

            if (_pass == Properties.Settings.Default.LoginPassword) core.Main();
            else if (_pass == "" || _pass == null) Console.WriteLine("\n" + "Errore! Inserire una password!");
            else Console.WriteLine("\n" + "ERRORE! Password errata!");      

            Console.ReadKey();
            Main();
        }


    }
}
