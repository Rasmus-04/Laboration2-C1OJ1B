using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboration_2
{
    public class Spel
    {
        public int Id { get; }

        public string Titel { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public Spel(
            string titel,
            int maxPlayers,
            int minPlayers,
            int id = 0)
        {
            if (string.IsNullOrWhiteSpace(titel))
                throw new Exception("Spelet måste ha en titel");

            if (minPlayers <= 0 || maxPlayers <= 0)
                throw new Exception("Antal spelare måste vara större än 0");

            if (minPlayers > maxPlayers)
                throw new Exception("MinPlayers kan inte vara större än MaxPlayers");

            Id = id;
            Titel = titel;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        // LINQ - Gruppering
        public static List<IGrouping<int, Spel>> GroupGamesByMaxPlayers(List<Spel> games)
        {
            return games.GroupBy(g => g.MaxPlayers).ToList();
        }

        public override string ToString()
        {
            return $"{Titel}";
        }
    }
}