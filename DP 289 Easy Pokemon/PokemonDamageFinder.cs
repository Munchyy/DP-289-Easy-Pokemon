using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_289_Easy_Pokemon
{
    class PokemonDamageFinder
    {
        public PokemonDamageFinder(string inputString)
        {
            List<string[]> inputList = new List<string[]>();
            string[] lines = System.Text.RegularExpressions.Regex.Split(inputString.Trim(), @"\n\s");
            foreach(string line in lines)
            {
                Console.WriteLine("line: {0}", line);
                string[] lineSplit = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s->\s");
                
                inputList.Add(lineSplit);
            }

            foreach(string[] types in inputList)
            {
                PokemonType pokemon = new PokemonType(types[0]);
                float damage = pokemon.CheckDamageVs(types[1]);
                Console.WriteLine("Damage modifier is: {0}", damage);
            }

            Console.ReadLine();
        }
    }
}
