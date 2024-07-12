using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contract
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(HouseFormModel model,int agentId);

        Task<HouseQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        
        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);

        Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int id);

        Task<HouseDetailsServiceModel> HouseDetailsByIdASync(int id);

        Task EditAsync(int houseId, HouseFormModel model);

        Task<bool> HasAgentWithIdAsync(int houseId, string userId);

        Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id);
    }
}
