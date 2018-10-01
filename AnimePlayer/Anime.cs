using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AnimePlayer
{
    class Anime
    {
        public string Name { get; private set; }
        public string MaxEpisode { get; private set; }
        public Dictionary<string, string> Episodes { get; private set; }

        public Anime(string name, string maxEpisode, Dictionary<string, string> episodes)
        {
            Name = name;
            MaxEpisode = maxEpisode;
            Episodes = episodes;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
