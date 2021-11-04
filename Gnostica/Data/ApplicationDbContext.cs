using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gnostica.Models;

namespace Gnostica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlayerGame>()
                .HasKey(pg => new { pg.PlayerID, pg.GameID });
            builder.Entity<PlayerGame>()
                .HasOne(pg => pg.Game)
                .WithMany(g => g.PlayerGames)
                .HasForeignKey(pg => pg.GameID);
            builder.Entity<PlayerGame>()
                .HasOne(pg => pg.Player)
                .WithMany(p => p.PlayerGames)
                .HasForeignKey(pg => pg.PlayerID);
            builder.Entity<PlayerGame>().Property(c => c.PieceColor)
                    .HasConversion(
                    c => c.ToHex(),
                    c => SixLabors.ImageSharp.Color.ParseHex(c));

            base.OnModelCreating(builder);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<CardList> Decks { get; set; }
        public DbSet<CardInCardList> DeckLists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Gnostica.Models.PlayerGame> PlayerGame { get; set; }
    }
}
