namespace AngularWebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AngularWebApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularWebApplication.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularWebApplication.Data.ApplicationDbContext context)
        {

            context.PlayerRecords.AddOrUpdate(x => x.PlayerId,

                new PlayerRecord { PlayerId = 1, PlayerName = "Mezut Ozil", Club = "Arsenal", Position = "Midfielder", JoinedClubOn = new DateTime(2019, 6, 18) },
                new PlayerRecord { PlayerId = 2, PlayerName = "Lionel Messi", Club = "Barcelona", Position = "Midfielder", JoinedClubOn = new DateTime(2005, 6, 18) },
                new PlayerRecord { PlayerId = 3, PlayerName = "Cristiano Ronaldo", Club = "Juventus", Position = "Forward", JoinedClubOn = new DateTime(2018, 6, 18) },
                new PlayerRecord { PlayerId = 4, PlayerName = "Bernd Leno", Club = "Arsenal", Position = "Goal Keeper", JoinedClubOn = new DateTime(2018, 6, 18) },
                new PlayerRecord { PlayerId = 5, PlayerName = "Virgil van Dijk", Club = "Liverppool", Position = "Defender", JoinedClubOn = new DateTime(2018, 1, 18) },
                new PlayerRecord { PlayerId = 6, PlayerName = "Mohamed Salah", Club = "Liverpool", Position = "Forward", JoinedClubOn = new DateTime(2017, 6, 18) }

                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
