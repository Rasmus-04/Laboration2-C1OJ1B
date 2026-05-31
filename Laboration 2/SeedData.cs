using Laboration_2.Data;
using Laboration_2.Model;
using System.Windows;

namespace Laboration_2
{
    internal class SeedData
    {
        public static async Task SeedAsync()
        {
            using var context = new ApplicationDbContext();

            if (!context.Members.Any())
            {
                context.Members.AddRange(
                    new Member(22, "Rasmus", "rasmus@test.se"),
                    new Member(25, "Anna", "anna@test.se"),
                    new Member(31, "Erik", "erik@test.se"),
                    new Member(28, "Lisa", "lisa@test.se"),
                    new Member(34, "Johan", "johan@test.se"),
                    new Member(19, "Emma", "emma@test.se"),
                    new Member(42, "Magnus", "magnus@test.se"),
                    new Member(27, "Sara", "sara@test.se")
                );
            }

            if (!context.Games.Any())
            {
                context.Games.AddRange(
                    new Game("Catan", 4, 3),
                    new Game("Carcassonne", 5, 2),
                    new Game("Ticket to Ride", 5, 2),
                    new Game("Azul", 4, 2),
                    new Game("Pandemic", 4, 2),
                    new Game("Terraforming Mars", 5, 1),
                    new Game("7 Wonders", 7, 3),
                    new Game("Wingspan", 5, 1)
                );
            }

            await context.SaveChangesAsync();

            if (!context.Events.Any())
            {
                var games = context.Games.ToList();

                context.Events.AddRange(
                    new Event(
                        "Fredagsspel",
                        DateTime.Today.AddDays(3),
                        games.First(g => g.Titel == "Catan"),
                        4),

                    new Event(
                        "Strategikväll",
                        DateTime.Today.AddDays(7),
                        games.First(g => g.Titel == "Terraforming Mars"),
                        5),

                    new Event(
                        "Familjespel",
                        DateTime.Today.AddDays(10),
                        games.First(g => g.Titel == "Ticket to Ride"),
                        5),

                    new Event(
                        "Co-op kväll",
                        DateTime.Today.AddDays(14),
                        games.First(g => g.Titel == "Pandemic"),
                        4)
                );

                await context.SaveChangesAsync();
            }
            if (!context.Events.Any())
            {
                var catan = context.Games.First(g => g.Titel == "Catan");
                var mars = context.Games.First(g => g.Titel == "Terraforming Mars");
                var ticket = context.Games.First(g => g.Titel == "Ticket to Ride");
                var pandemic = context.Games.First(g => g.Titel == "Pandemic");

                context.Events.AddRange(
                    new Event("Fredagsspel", DateTime.Today.AddDays(3), catan, 4),
                    new Event("Strategikväll", DateTime.Today.AddDays(7), mars, 5),
                    new Event("Familjespel", DateTime.Today.AddDays(10), ticket, 5),
                    new Event("Co-op kväll", DateTime.Today.AddDays(14), pandemic, 4)
                );

                await context.SaveChangesAsync();
            }

            if (!context.EventMembers.Any())
            {
                var members = context.Members.ToList();
                var events = context.Events.ToList();

                context.EventMembers.AddRange(

                    // Fredagsspel
                    new EventMember
                    {
                        EventId = events[0].Id,
                        MemberId = members[0].Id
                    },
                    new EventMember
                    {
                        EventId = events[0].Id,
                        MemberId = members[1].Id
                    },

                    // Strategikväll
                    new EventMember
                    {
                        EventId = events[1].Id,
                        MemberId = members[2].Id
                    },
                    new EventMember
                    {
                        EventId = events[1].Id,
                        MemberId = members[3].Id
                    },
                    new EventMember
                    {
                        EventId = events[1].Id,
                        MemberId = members[4].Id
                    },

                    // Familjespel
                    new EventMember
                    {
                        EventId = events[2].Id,
                        MemberId = members[5].Id
                    },
                    new EventMember
                    {
                        EventId = events[2].Id,
                        MemberId = members[6].Id
                    },

                    // Co-op kväll
                    new EventMember
                    {
                        EventId = events[3].Id,
                        MemberId = members[7].Id
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
