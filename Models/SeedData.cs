using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XKnows.Data;
using System;
using System.Linq;

namespace XKnows.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShareContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShareContext>>()))
            {
                // Look for any movies.
                if (context.Share.Any())
                {
                    return;   // DB has been seeded
                }

                context.Share.AddRange(
                    new Share
                    {
                        Title = "Watercolor Painting",
                        ReleaseDate = DateTime.Parse("2021-2-12"),
                        Skill = "Fine Arts",
                        Level = "Beginner",
                        Points = 3.99M
                    },

                    new Share
                    {
                        Title = "Logo Creation",
                        ReleaseDate = DateTime.Parse("2020-3-13"),
                        Skill = "Design",
                        Level = "Advanced",
                        Points = 8.99M
                    },

                    new Share
                    {
                        Title = "Basic Guitar Chords",
                        ReleaseDate = DateTime.Parse("2021-2-23"),
                        Skill = "Music",
                        Level = "Beginner",
                        Points = 9.99M
                    },

                    new Share
                    {
                        Title = "Bullet Journaling",
                        ReleaseDate = DateTime.Parse("2021-4-15"),
                        Skill = "Fine Arts",
                        Level = "Beginner",
                        Points = 7.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}