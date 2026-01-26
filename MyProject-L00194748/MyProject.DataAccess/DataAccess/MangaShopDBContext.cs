using Microsoft.EntityFrameworkCore;
using MyProject.Models.Models;

namespace MyProject.DataAccess.DataAccess
{
    public class MangaShopDBContext: DbContext
    {

        public MangaShopDBContext(DbContextOptions<MangaShopDBContext> options) : base(options)
        {
        }
        public DbSet<BookDetails> Books { get; set; }
        public DbSet<Themes> Themes { get; set; }
        public DbSet<BookTypes> BookTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed(); // ✅ Call your seed method here
        }
    }
    internal static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<BookTypes>()
                .HasData(
                new BookTypes { Id = 1, Name = "Light Novel" },
                new BookTypes { Id = 2, Name = "Manga" },
                new BookTypes { Id = 3, Name = "Manwha" },
                new BookTypes { Id = 4, Name = "Web Novel" }

                );
            builder.Entity<Themes>()
                .HasData(
                new Themes { Id = 1, Name = "Fantasy" },
                new Themes { Id = 2, Name = "Science Fiction" },
                new Themes { Id = 3, Name = "Action" },
                new Themes { Id = 4, Name = "Horror" },
                new Themes { Id = 5, Name = "Shonen" },
                new Themes { Id = 6, Name = "Adventure" },
                new Themes { Id = 7, Name = "Comedy" },
                new Themes { Id = 8, Name = "Drama" },
                new Themes { Id = 9, Name = "Mystery" },
                new Themes { Id = 10, Name = "Romance" }




                );
            builder.Entity<BookDetails>()
                .HasMany(b => b.Themes)
                .WithMany(t => t.Books)
                .UsingEntity(j =>
                {
                    j.ToTable("BookThemes");

                    j.HasData(
                        new { BooksId = 1, ThemesId = 1 },
                        new { BooksId = 1, ThemesId = 2 },

                        new { BooksId = 2, ThemesId = 1 },
                        new { BooksId = 2, ThemesId = 6 },
                        new { BooksId = 2, ThemesId = 8 },
                        new { BooksId = 2, ThemesId = 10 },

                        new { BooksId = 3, ThemesId = 3 },

                        new { BooksId = 4, ThemesId = 1 },
                        new { BooksId = 4, ThemesId = 3 },
                        new { BooksId = 4, ThemesId = 9 },

                        new { BooksId = 5, ThemesId = 1 },
                        new { BooksId = 5, ThemesId = 3 },
                        new { BooksId = 5, ThemesId = 6 }






                    );
                });

            builder.Entity<BookDetails>()
                .HasData(
                new BookDetails
                {
                    Id = 1,
                    Title = "Chainsaw Man Vol. 1",
                    Author = "Tatsuki Fujimoto",
                    Description = "Denji was a small-time devil hunter just trying to survive in a harsh world. After being killed on a job, he is revived by his pet devil Pochita and becomes something new and dangerous—Chainsaw Man!\r\n\r\nDenji’s a poor young man who’ll do anything for money, even hunting down devils with his pet devil Pochita. He’s a simple man with simple dreams, drowning under a mountain of debt. But his sad life gets turned upside down one day when he’s betrayed by someone he trusts. Now with the power of a devil inside him, Denji’s become a whole new man—Chainsaw Man!",
                    Price = 15,
                    ReleaseDate = new DateTime(2020, 10, 20),
                    BookTypeID = 2,
                    CoverImage = @"\images\book\Chainsaw Man Vol. 1 (Manga).jpg"
                },
                new BookDetails
                {
                    Id = 2,
                    Title = "Spice and Wolf Vol. 1",
                    Author = "Isuna Hasekura",
                    Description = "The life of a traveling merchant is a lonely one, a fact with which Kraft Lawrence is well acquainted. Wandering from town to town with just his horse, cart, and whatever wares have come his way, the peddler has pretty well settled into his routine-that is, until the night Lawrence finds a wolf goddess asleep in his cart. Taking the form of a fetching girl with wolf ears and a tail, Holo has wearied of tending to harvests in the countryside and strikes up a bargain with the merchant to lend him the cunning of Holo the Wisewolf to increase his profits in exchange for taking her along on his travels. What kind of businessman could turn down such an offer? Lawrence soon learns, though, that having an ancient goddess as a traveling companion can be a bit of a mixed blessing. Will this wolf girl turn out to be too wild to tame?",
                    Price = 12,
                    ReleaseDate = new DateTime(2006, 2, 10),
                    BookTypeID = 1,
                    CoverImage = @"\images\book\Spice and Wolf Vol. 1 (Light Novel).jpg"
                },
                new BookDetails
                {
                    Id = 3,
                    Title = "Jujutsu Kaisen Vol. 1",
                    Author = "Gege Akutami",
                    Description = "To gain the power he needs to save his friend from a cursed spirit, Yuji Itadori swallows a piece of a demon, only to find himself caught in the midst of a horrific war of the supernatural!\r\n\r\nIn a world where cursed spirits feed on unsuspecting humans, fragments of the legendary and feared demon Ryomen Sukuna have been lost and scattered about. Should any demon consume Sukuna’s body parts, the power they gain could destroy the world as we know it. Fortunately, there exists a mysterious school of jujutsu sorcerers who exist to protect the precarious existence of the living from the supernatural!\r\n\r\nAlthough Yuji Itadori looks like your average teenager, his immense physical strength is something to behold! Every sports club wants him to join, but Itadori would rather hang out with the school outcasts in the Occult Research Club. One day, the club manages to get their hands on a sealed cursed object. Little do they know the terror they’ll unleash when they break the seal…",
                    Price = 15,
                    ReleaseDate = new DateTime(2018, 7, 4),
                    BookTypeID = 2,
                    CoverImage = @"\images\book\Jujutsu Kaisen Vol. 1 (Manga).jpg"
                },
                new BookDetails
                {
                    Id = 4,
                    Title = "Lord of Mysteries Vol. 1: The Clown, Part I",
                    Author = "Yuan Ye",
                    Description = "In the storm of steam and machinery, who can achieve the extraordinary? In the fog of history and darkness, who whispers? When Zhou Mingrui wakes up bloody and dazed, he finds himself in a world of guns, factories, airships, and difference engines. But underneath the surface of all this industry, there exists a secret society revolving around potions, divination, sealed artifacts, and much more. As Zhou Mingrui tries to find out what brought him to this place, he quickly learns that mystery is lurking around every corner—and danger is never far behind! This is the legend of the Fool…",
                    Price = 20,
                    ReleaseDate = new DateTime(2025, 7, 29),
                    BookTypeID = 4,
                    CoverImage = @"\images\book\Lord of Mysteries, Vol. 1, The Clown, Part I (Web Novel).jpg"
                },
                new BookDetails
                {
                    Id = 5,
                    Title = "Solo Leveling Vol. 1",
                    Author = "Kisoryong Chugong",
                    Description = "E-class hunter Jinwoo Sung is the weakest of them all. Looked down on by everyone, he has no money, no abilities to speak of, and no other job prospects. So when his party finds a hidden dungeon, he's determined to use this chance to change his life for the better...but the opportunity he finds is a bit different from what he had in mind!",
                    Price = 18,
                    ReleaseDate = new DateTime(2019, 9, 26),
                    BookTypeID = 3,
                    CoverImage = @"\images\book\Solo Leveling Vol. 1 (Manwha).jpg"
                }
                );


        }

    }
}
