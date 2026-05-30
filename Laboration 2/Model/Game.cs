namespace Laboration_2.Model
{
    public class Game
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }
        public Game()
        {
        }
        public Game(
            string titel,
            int maxPlayers,
            int minPlayers)
        {
            if (string.IsNullOrWhiteSpace(titel))
                throw new Exception("Spelet måste ha en titel");

            if (minPlayers <= 0 || maxPlayers <= 0)
                throw new Exception("Antal spelare måste vara större än 0");

            if (minPlayers > maxPlayers)
                throw new Exception("MinPlayers kan inte vara större än MaxPlayers");

            Titel = titel;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        // LINQ - Gruppering
        public static List<IGrouping<int, Game>> GroupGamesByMaxPlayers(List<Game> games)
        {
            return games.GroupBy(g => g.MaxPlayers).ToList();
        }

        public override string ToString()
        {
            return $"{Titel}";
        }
    }
}