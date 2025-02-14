﻿using HouseRentingSystem.Core.Contract;
using HouseRentingSystem.Core.Models.Statistics;
using HouseRentingSystem.Infrastucture.Data.Common;
using HouseRentingSystem.Infrastucture.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;
        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalHouses = await repository.AllReadOnly<House>()
                .CountAsync();

            int totalRents = await repository.AllReadOnly<House>()
                .Where(h => h.RenterId != null)
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
