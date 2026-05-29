using Laboration_2.Model;
using System.Collections.ObjectModel;

namespace Laboration_2
{
    static class TestData
    {
        public static void GenerateAllData(ObservableCollection<Member> members, ObservableCollection<Game> games, ObservableCollection<Event> aktiviteter)
        {
            GenerateMembers(members);
            GenerateGames(games);
            GenerateActivities(aktiviteter, games);
            GenerateParticipants(aktiviteter, members);
        }

        public static void GenerateMembers(ObservableCollection<Member> members)
        {
            members.Clear();
            members.Add(new Member(22, "Lisa", "lisa@gmail.com"));
            members.Add(new Member(25, "Erik", "erik@gmail.com"));
            members.Add(new Member(31, "Anna", "anna@gmail.com"));
            members.Add(new Member(28, "Johan", "johan@gmail.com"));
            members.Add(new Member(19, "Emma", "emma@gmail.com"));
            members.Add(new Member(35, "Karl", "karl@gmail.com"));
            members.Add(new Member(27, "Sara", "sara@gmail.com"));
            members.Add(new Member(24, "David", "david@gmail.com"));
            members.Add(new Member(29, "Maja", "maja@gmail.com"));
            members.Add(new Member(33, "Oscar", "oscar@gmail.com"));
            members.Add(new Member(21, "Elin", "elin@gmail.com"));
            members.Add(new Member(26, "Victor", "victor@gmail.com"));
            members.Add(new Member(30, "Felicia", "felicia@gmail.com"));
            members.Add(new Member(23, "Lucas", "lucas@gmail.com"));
            members.Add(new Member(40, "Maria", "maria@gmail.com"));
            members.Add(new Member(18, "Hugo", "hugo@gmail.com"));
            members.Add(new Member(32, "Nora", "nora@gmail.com"));
            members.Add(new Member(27, "Albin", "albin@gmail.com"));
            members.Add(new Member(36, "Sofia", "sofia@gmail.com"));
            members.Add(new Member(20, "Anton", "anton@gmail.com"));
        }

        public static void GenerateGames(ObservableCollection<Game> games)
        {
            games.Clear();
            games.Add(new Game("Catan", 4, 3));
            games.Add(new Game("Chess", 2, 2));
            games.Add(new Game("Carcassonne", 5, 2));
            games.Add(new Game("Ticket to Ride", 5, 2));
            games.Add(new Game("Pandemic", 4, 2));
            games.Add(new Game("Monopoly", 6, 2));
            games.Add(new Game("Terraforming Mars", 5, 1));
            games.Add(new Game("Azul", 4, 2));
            games.Add(new Game("Wingspan", 5, 1));
            games.Add(new Game("7 Wonders", 7, 3));
            games.Add(new Game("Exploding Kittens", 5, 2));
            games.Add(new Game("Uno", 10, 2));
            games.Add(new Game("Risk", 6, 2));
            games.Add(new Game("Dominion", 4, 2));
            games.Add(new Game("The Crew", 5, 3));
            games.Add(new Game("Splendor", 4, 2));
            games.Add(new Game("Dixit", 8, 3));
            games.Add(new Game("Root", 4, 2));
            games.Add(new Game("Gloomhaven", 4, 1));
            games.Add(new Game("Codenames", 8, 4));
        }

        public static void GenerateActivities(ObservableCollection<Event> aktiviteter, ObservableCollection<Game> games)
        {
            aktiviteter.Clear();

            aktiviteter.Add(new Event(
                "Strategikväll",
                DateTime.Now.AddDays(3),
                games[0],
                8));

            aktiviteter.Add(new Event(
                "Familjespelkväll",
                DateTime.Now.AddDays(5),
                games[1],
                6));

            aktiviteter.Add(new Event(
                "Turnering i Chess",
                DateTime.Now.AddDays(14),
                games[2],
                10));

            aktiviteter.Add(new Event(
                "Nybörjarkväll",
                DateTime.Now.AddDays(22),
                games[3],
                12));

            aktiviteter.Add(new Event(
                "Co-op kväll",
                DateTime.Now.AddDays(7),
                games[4],
                5));

            aktiviteter.Add(new Event(
                "Kortspelsafton",
                DateTime.Now.AddDays(17),
                games[5],
                16));

            aktiviteter.Add(new Event(
                "Eurogame Night",
                DateTime.Now.AddDays(20),
                games[6],
                8));

            aktiviteter.Add(new Event(
                "Festspel Fredag",
                DateTime.Now.AddDays(10),
                games[7],
                20));

            aktiviteter.Add(new Event(
                "Söndagsshuffle",
                DateTime.Now.AddDays(25),
                games[8],
                10));

            aktiviteter.Add(new Event(
                "Brädhörnans Stormatch",
                DateTime.Now.AddDays(30),
                games[9],
                24));
        }

        public static void GenerateParticipants(ObservableCollection<Event> aktiviteter, ObservableCollection<Member> members)
        {
            aktiviteter[0].AddParticipant(members[0]);
            aktiviteter[0].AddParticipant(members[1]);
            aktiviteter[0].AddParticipant(members[2]);

            aktiviteter[1].AddParticipant(members[3]);
            aktiviteter[1].AddParticipant(members[4]);

            aktiviteter[2].AddParticipant(members[5]);
            aktiviteter[2].AddParticipant(members[6]);
            aktiviteter[2].AddParticipant(members[7]);
            aktiviteter[2].AddParticipant(members[8]);

            aktiviteter[3].AddParticipant(members[9]);

            aktiviteter[4].AddParticipant(members[10]);
            aktiviteter[4].AddParticipant(members[11]);

            aktiviteter[5].AddParticipant(members[12]);
            aktiviteter[5].AddParticipant(members[13]);
            aktiviteter[5].AddParticipant(members[14]);

            aktiviteter[6].AddParticipant(members[15]);

            aktiviteter[7].AddParticipant(members[16]);
            aktiviteter[7].AddParticipant(members[17]);

            aktiviteter[8].AddParticipant(members[18]);

            aktiviteter[9].AddParticipant(members[19]);
        }
    }
}
