using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var daemons = Console.ReadLine();
            var daemonsWithProperties = new List<string>();
            foreach(var daemon in daemons.Split(','))
            {
                if(IsDaemonValid(daemon))
                {
                    var daemonWithProperties = CalculateDaemonProperties(daemon.Trim());
                    daemonsWithProperties.Add(daemonWithProperties);
                }
            }
            daemonsWithProperties.Sort();
            foreach (var daemon in daemonsWithProperties)
            {
                Console.WriteLine(daemon);
            }
            Console.ReadKey();
        }

        private static bool IsDaemonValid(string daemonName)
        {
            return !string.IsNullOrEmpty(daemonName) && daemonName.Length > 1;
        }

        private static string CalculateDaemonProperties(string daemon)
        {
            int health = CalculateHealth(daemon);
            double damage = CalculateDamage(daemon);
            return $"{daemon} - {health} health, {damage.ToString("F2")} damage";
        }

        private static double CalculateDamage(string daemon)
        {
            double damange = 0;
            foreach (var number in Regex.Matches(daemon, @"[-+]?[0-9]+(\.[0-9]+)?"))
            {
                double parsedNumber = 0;
                if (double.TryParse(number.ToString(), out parsedNumber))
                    damange += parsedNumber;
            }
            for (int counter = 0; counter < Regex.Matches(daemon, @"\*").Count; counter++)
            {
                damange = damange * 2;
            }
            for (int counter = 0; counter < Regex.Matches(daemon, @"\\").Count; counter++)
            {
                damange = damange / 2;
            }
            //Alternative
            //var power = Regex.Matches(daemon, @"\*").Count - Regex.Matches(daemon, @"\\").Count;
            //damange = damange * Math.Pow(2, power);
            
            return damange;
        }

        private static int CalculateHealth(string daemon)
        {
            int health = 0;
            foreach (var character in Regex.Matches(daemon, @"[^\.\+\-\*\/0-9]"))
            {
                health += Char.Parse(character.ToString());
            }
            return health;
        }
    }
}
