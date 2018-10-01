using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AnimePlayer
{
    static class AnimeLoader
    {
        public static Dictionary<string, Anime> Animes = new Dictionary<string, Anime>();

        public static void Loadlist()
        {
            Animes = JsonConvert.DeserializeObject<Dictionary<string, Anime>>(File.ReadAllText("easyrp/animes.json"));
            foreach (var item in Animes)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static void UpdateList()
        {
            File.WriteAllText("easyrp/animes.json", JsonConvert.SerializeObject(Animes, Formatting.Indented));
        }

        public static void Add(Anime anime)
        {
            if (Animes.Count != 0)
            {
                if (Animes.ContainsKey(anime.Name))
                    return;
            }
            Animes.Add(anime.Name.Trim(), anime);
            UpdateList();
        }

        public static void Remove(string key)
        {
            if (Animes.ContainsKey(key))
            {
                Animes.Remove(key);
                UpdateList();
            }
            else
            {
                return;
            }
        }
    }
}