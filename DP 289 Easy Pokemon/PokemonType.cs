using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DP_289_Easy_Pokemon
{
    class PokemonType
    {
        private string typeName;

        public Dictionary<string, float> DamageModify { get; set; }

        public PokemonType(string typeName)
        {
            this.typeName = typeName;

            DamageModify = FetchDamageValues(typeName);

        }

        public float CheckDamageVs(string opponentType)
        {
            float dmgMod = 1f;
            if (opponentType.Contains(" "))
            {
                String[] types = opponentType.Split(' ');
                foreach (string s in types)
                {
                    dmgMod *= DamageModify[s];
                }

            } 
            else
            {
                dmgMod *= DamageModify[opponentType];
            }
            return dmgMod;
        }

        public Dictionary<string, float> FetchDamageValues(string typeName)
        {
            Dictionary<string, float> damageValues = new Dictionary<string, float>()
            {
                { "normal", 1f },
                { "water", 1f },
                { "electric", 1f },
                { "grass", 1f },
                { "ice", 1f },
                { "fighting", 1f },
                { "poison",1f },
                { "ground", 1f },
                { "flying", 1f },
                { "psychic", 1f },
                { "bug", 1f },
                { "rock",1f },
                { "ghost", 1f },
                { "dragon", 1f },
                { "dark", 1f },
                { "steel", 1f },
                { "fairy", 1f }
            };
            Console.WriteLine("Fetching damage data for {0}",typeName);
            string baseUrl = @"http://pokeapi.co/api/v2/type/";
            string url = baseUrl + typeName + "/";
            string jsonString = new System.Net.WebClient().DownloadString(url);
            JObject jObject = (JObject) JsonConvert.DeserializeObject(jsonString);

            JObject damageRelationsObj = (JObject)jObject["damage_relations"];
            JArray noDamageArr = (JArray)damageRelationsObj["no_damage_to"];
            JArray halfDamageArr = (JArray)damageRelationsObj["half_damage_to"];
            JArray doubleDamageArr = (JArray)damageRelationsObj["double_damage_to"];

            foreach (JObject damObj in noDamageArr)
            {
                damageValues[(string)damObj["name"]] = 00f;
            }

            foreach (JObject damObj in halfDamageArr)
            {
                damageValues[(string)damObj["name"]] = 0.5f;
            }

            foreach (JObject damObj in doubleDamageArr)
            {
                damageValues[(string)damObj["name"]] = 2f;
            }

            return damageValues;
        }
    }
}
