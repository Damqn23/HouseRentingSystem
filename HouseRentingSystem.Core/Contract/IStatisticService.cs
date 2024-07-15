using HouseRentingSystem.Core.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contract
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
