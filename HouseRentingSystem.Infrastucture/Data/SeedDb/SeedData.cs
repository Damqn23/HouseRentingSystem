﻿using HouseRentingSystem.Infrastucture.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Infrastucture.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser AgentUser { get; set; }
        public ApplicationUser GuestUser { get; set; }

		public ApplicationUser AdminUser { get; set; }


		public Agent Agent { get; set; }
		public Agent AdminAgent { get; set; }

		public Category CottageCategory {  get; set; }
        public Category SingleCategory { get; set; }
        public Category DuplexCategory { get; set; }
        public House FirstHouse { get; set; }
        public House SecondHouse { get; set; }
        public House ThirdHouse { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAgent();
            SeedCategories();
            SeedHouses();
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AgentUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Agent",
				LastName = "Agentov",
            };
            AgentUser.PasswordHash = hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new ApplicationUser()
			{
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov"
            };
            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");

            AdminUser = new ApplicationUser()
            {
                Id = "3f4631bd-f907-4409-b416-ba356312e659",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIN.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIN.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };
			AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };

            AdminAgent = new Agent()
			{
				Id = 7,
				PhoneNumber = "+359999999999",
				UserId = AdminUser.Id
			};
        }

        private void SeedCategories()
        {
            CottageCategory = new Category()
            {
                Id = 1,
                Name = "Cottage"
            };
            SingleCategory = new Category()
            {
                Id = 2,
                Name = "Single-Family"
            };
            DuplexCategory = new Category()
            {
                Id = 3,
                Name = "Duplex"
            };
        }

        private void SeedHouses()
        {
            FirstHouse = new House()
            {
                Id = 1,
                Title = "Big House Marina",
                Address = "North London, UK (near the border)",
                Description = "A big house for your whole family",
                ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                PricePerMouth = 2100.00M,
                CategoryId = DuplexCategory.Id,
                AgentId = Agent.Id,
                RenterId = GuestUser.Id
            };

            SecondHouse = new House()
            {
                Id = 2,
                Title = "Family House Comfort",
                Address = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for.",
                ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                PricePerMouth = 1200.00M,
                AgentId = Agent.Id
            };

            ThirdHouse = new House()
            {
                Id = 3,
                Title = "Grand House",
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This luxurious house is everything you will need",
                ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                PricePerMouth = 2000.00M,
                CategoryId = SingleCategory.Id,
                AgentId = Agent.Id
            };
        }

    }
}
