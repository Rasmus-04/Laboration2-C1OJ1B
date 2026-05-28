using System.Collections.ObjectModel;

namespace Laboration_2
{
    static class TestData
    {
        public static void GenerateAllData(ObservableCollection<Medlem> members, ObservableCollection<Spel> games, ObservableCollection<Aktivitet> aktiviteter)
        {
            GenerateMembers(members);
            GenerateGames(games);
            GenerateActivities(aktiviteter, games);
            GenerateParticipants(aktiviteter, members);
        }

        public static void GenerateMembers(ObservableCollection<Medlem> members)
        {
            members.Clear();
            members.Add(new Medlem(22, "Lisa", "lisa@gmail.com"));
            members.Add(new Medlem(25, "Erik", "erik@gmail.com"));
            members.Add(new Medlem(31, "Anna", "anna@gmail.com"));
            members.Add(new Medlem(28, "Johan", "johan@gmail.com"));
            members.Add(new Medlem(19, "Emma", "emma@gmail.com"));
            members.Add(new Medlem(35, "Karl", "karl@gmail.com"));
            members.Add(new Medlem(27, "Sara", "sara@gmail.com"));
            members.Add(new Medlem(24, "David", "david@gmail.com"));
            members.Add(new Medlem(29, "Maja", "maja@gmail.com"));
            members.Add(new Medlem(33, "Oscar", "oscar@gmail.com"));
            members.Add(new Medlem(21, "Elin", "elin@gmail.com"));
            members.Add(new Medlem(26, "Victor", "victor@gmail.com"));
            members.Add(new Medlem(30, "Felicia", "felicia@gmail.com"));
            members.Add(new Medlem(23, "Lucas", "lucas@gmail.com"));
            members.Add(new Medlem(40, "Maria", "maria@gmail.com"));
            members.Add(new Medlem(18, "Hugo", "hugo@gmail.com"));
            members.Add(new Medlem(32, "Nora", "nora@gmail.com"));
            members.Add(new Medlem(27, "Albin", "albin@gmail.com"));
            members.Add(new Medlem(36, "Sofia", "sofia@gmail.com"));
            members.Add(new Medlem(20, "Anton", "anton@gmail.com"));
        }

        public static void GenerateGames(ObservableCollection<Spel> games)
        {
            games.Clear();
            games.Add(new Spel("Catan", 4, 3));
            games.Add(new Spel("Chess", 2, 2));
            games.Add(new Spel("Carcassonne", 5, 2));
            games.Add(new Spel("Ticket to Ride", 5, 2));
            games.Add(new Spel("Pandemic", 4, 2));
            games.Add(new Spel("Monopoly", 6, 2));
            games.Add(new Spel("Terraforming Mars", 5, 1));
            games.Add(new Spel("Azul", 4, 2));
            games.Add(new Spel("Wingspan", 5, 1));
            games.Add(new Spel("7 Wonders", 7, 3));
            games.Add(new Spel("Exploding Kittens", 5, 2));
            games.Add(new Spel("Uno", 10, 2));
            games.Add(new Spel("Risk", 6, 2));
            games.Add(new Spel("Dominion", 4, 2));
            games.Add(new Spel("The Crew", 5, 3));
            games.Add(new Spel("Splendor", 4, 2));
            games.Add(new Spel("Dixit", 8, 3));
            games.Add(new Spel("Root", 4, 2));
            games.Add(new Spel("Gloomhaven", 4, 1));
            games.Add(new Spel("Codenames", 8, 4));
        }

        public static void GenerateActivities(ObservableCollection<Aktivitet> aktiviteter, ObservableCollection<Spel> games)
        {
            aktiviteter.Clear();

            aktiviteter.Add(new Aktivitet(
                "Strategikväll",
                DateTime.Now.AddDays(3),
                games[0],
                8));

            aktiviteter.Add(new Aktivitet(
                "Familjespelkväll",
                DateTime.Now.AddDays(5),
                games[1],
                6));

            aktiviteter.Add(new Aktivitet(
                "Turnering i Chess",
                DateTime.Now.AddDays(14),
                games[2],
                10));

            aktiviteter.Add(new Aktivitet(
                "Nybörjarkväll",
                DateTime.Now.AddDays(22),
                games[3],
                12));

            aktiviteter.Add(new Aktivitet(
                "Co-op kväll",
                DateTime.Now.AddDays(7),
                games[4],
                5));

            aktiviteter.Add(new Aktivitet(
                "Kortspelsafton",
                DateTime.Now.AddDays(17),
                games[5],
                16));

            aktiviteter.Add(new Aktivitet(
                "Eurogame Night",
                DateTime.Now.AddDays(20),
                games[6],
                8));

            aktiviteter.Add(new Aktivitet(
                "Festspel Fredag",
                DateTime.Now.AddDays(10),
                games[7],
                20));

            aktiviteter.Add(new Aktivitet(
                "Söndagsshuffle",
                DateTime.Now.AddDays(25),
                games[8],
                10));

            aktiviteter.Add(new Aktivitet(
                "Brädhörnans Stormatch",
                DateTime.Now.AddDays(30),
                games[9],
                24));
        }

        public static void GenerateParticipants(ObservableCollection<Aktivitet> aktiviteter, ObservableCollection<Medlem> members)
        {
            aktiviteter[0].AddDeltagare(members[0]);
            aktiviteter[0].AddDeltagare(members[1]);
            aktiviteter[0].AddDeltagare(members[2]);

            aktiviteter[1].AddDeltagare(members[3]);
            aktiviteter[1].AddDeltagare(members[4]);

            aktiviteter[2].AddDeltagare(members[5]);
            aktiviteter[2].AddDeltagare(members[6]);
            aktiviteter[2].AddDeltagare(members[7]);
            aktiviteter[2].AddDeltagare(members[8]);

            aktiviteter[3].AddDeltagare(members[9]);

            aktiviteter[4].AddDeltagare(members[10]);
            aktiviteter[4].AddDeltagare(members[11]);

            aktiviteter[5].AddDeltagare(members[12]);
            aktiviteter[5].AddDeltagare(members[13]);
            aktiviteter[5].AddDeltagare(members[14]);

            aktiviteter[6].AddDeltagare(members[15]);

            aktiviteter[7].AddDeltagare(members[16]);
            aktiviteter[7].AddDeltagare(members[17]);

            aktiviteter[8].AddDeltagare(members[18]);

            aktiviteter[9].AddDeltagare(members[19]);
        }
    }
}
