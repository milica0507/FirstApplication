using Aplikacija;
using Aplikacija.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace Application_tests
{
    public class PublishersServiceTest
    {

        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "BookDbTest")
            .Options;
        ApplicationDbContext context;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

        }

       [OneTimeTearDown]
       public void CleanUp()
       {
            context.Database.EnsureDeleted();
       }


        private void SeedDatabase()
        {
            var publishers = new List<Publisher>
            {
                new Publisher()
                {
                    PublisherId="1",
                    Name="Publisher 1"
                },
                   new Publisher()
                {
                    PublisherId="2",
                    Name="Publisher 2"
                }

            };
        }
    }
}