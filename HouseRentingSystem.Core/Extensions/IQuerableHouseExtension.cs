using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastucture.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    internal static class IQuerableHouseExtension
    {
        public static IQueryable<HouseServiceModel> ProjectToHouseServiceModel(this IQueryable<House> houses)
        {
            return houses
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId !=null,
                    PricePerMonth = h.PricePerMouth,
                    Title = h.Title
                });
        }
    }
}
