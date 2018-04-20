namespace Tecwi1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tecwi1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TecwiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tecwi1.Models.TecwiDbContext context)
        {
            Random rnd = new Random(1);
            Random ageRnd = new Random(1);
            new List<Employee>
            {
                new  Employee
                {
                    Name = "Airi Satou",
                    Position = "Accountant",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Angelica Ramos",
                    Position= "Chief Executive Officer (CEO)",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25, 60)
                },
                new  Employee
                {
                    Name= "Ashton Cox",
                    Position= "Junior Technical Author",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Bradley Greer",
                    Position= "Software Engineer",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Brenden Wagner",
                    Position= "Software Engineer",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Brielle Williamson",
                    Position= "Integration Specialist",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Bruno Nash",
                    Position= "Software Engineer",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Caesar Vance",
                    Position= "Pre-Sales Support",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Cara Stevens",
                    Position= "Sales Assistant",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                },
                new  Employee
                {
                    Name= "Cedric Kelly",
                    Position= "Senior Javascript Developer",
                    StartDate = DateTime.Today.AddDays(-1*rnd.Next(100, 5000)),
                    Age = ageRnd.Next(25,60)
                }
            }.ForEach(e => context.Employees.Add(e));

            context.SaveChanges();
        }
    }
}
