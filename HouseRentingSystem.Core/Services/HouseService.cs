﻿using HouseRentingSystem.Core.Contract;
using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastucture.Data.Common;
using HouseRentingSystem.Infrastucture.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
	{
		private readonly IRepository repository;

		public HouseService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
		{
			var housesToShow = repository.AllReadOnly<House>();

			if (category != null)
			{
				housesToShow = housesToShow
					.Where(h => h.Category.Name == category);
			}

			if (searchTerm != null)
			{
				string normalizedSearchTerm = searchTerm.ToLower();
				housesToShow = housesToShow
					.Where(h => (h.Title.ToLower().Contains(normalizedSearchTerm) ||
					h.Address.ToLower().Contains(normalizedSearchTerm) ||
					h.Description.ToLower().Contains(normalizedSearchTerm)));

			}

			housesToShow = sorting switch
			{
				HouseSorting.Price =>housesToShow
					.OrderBy(h => h.PricePerMouth),
				HouseSorting.NotRentedFirst => housesToShow
					.OrderBy(h => h.RenterId != null)
					.ThenByDescending(h => h.Id),
				_ => housesToShow
					.OrderByDescending(h=> h.Id)
			};

			var houses = await housesToShow
				.Skip((currentPage - 1) * housesPerPage)
				.Take(housesPerPage)
				.ProjectToHouseServiceModel()
				.ToListAsync();

			int totalHouses = await housesToShow.CountAsync();

			return new HouseQueryServiceModel()
			{
				Houses = houses,
				TotalHousesCount = totalHouses
			};
		}

		public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
		{
			return await repository.AllReadOnly<Category>()
				.Select(c => new HouseCategoryServiceModel()
				{
					Id = c.Id,
					Name = c.Name,
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
		{
			return await repository.AllReadOnly<Category>()
				.Select(c => c.Name)
				.Distinct()
				.ToListAsync();
		}

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<House>()
				.Where(h => h.AgentId == agentId)
				.ProjectToHouseServiceModel()
				.ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
        {
			return await repository.AllReadOnly<House>()
				.Where(h => h.RenterId == userId)
				.ProjectToHouseServiceModel()
				.ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
		{
			return await repository.AllReadOnly<Category>()
				.AnyAsync(c => c.Id == categoryId);
		}

		public async Task<int> CreateAsync(HouseFormModel model, int agentId)
		{
			House house = new House()
			{
				Address = model.Address,
				AgentId = agentId,
				CategoryId = model.CategoryId,
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				PricePerMouth = model.PricePerMonth,
				Title = model.Title,
			};

			await repository.AddAsync(house);
			await repository.SaveChangesAsync();

			return house.Id;
		}

        public async Task<bool> ExistsAsync(int id)
        {
			return await repository.AllReadOnly<House>()
				.AnyAsync(h => h.Id == id);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdASync(int id)
        {
            return await repository.AllReadOnly<House>()
				.Where(h => h.Id == id)
				.Select(h => new HouseDetailsServiceModel()
				{
					Id = h.Id,
					Address = h.Address,
					Agent = new Models.Agent.AgentServiceModel()
					{
						Email = h.Agent.User.Email,
						PhoneNumber = h.Agent.PhoneNumber,
					},
					Category = h.Category.Name, 
					Description = h.Description,
					ImageUrl = h.ImageUrl,
					IsRented = h.RenterId != null,
					PricePerMonth = h.PricePerMouth, 
					Title = h.Title,
				})
				.FirstAsync();
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
		{
			return await repository
				.AllReadOnly<Infrastucture.Data.Models.House>()
				.OrderByDescending(h => h.Id)
				.Take(3)
				.Select(h => new HouseIndexServiceModel()
				{
					Id = h.Id,
					ImageUrl = h.ImageUrl,
					Title = h.Title
				}).ToListAsync();

		}
	}
}
