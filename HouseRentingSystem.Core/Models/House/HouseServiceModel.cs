using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastucture.Constants.DataConstants;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using HouseRentingSystem.Core.Contract;

namespace HouseRentingSystem.Core.Models.House
{
	public class HouseServiceModel : IHouseModel
	{
        public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(50,
			MinimumLength = 10,
			ErrorMessage = LengthMessage)]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(150,
			MinimumLength = 30,
			ErrorMessage = LengthMessage)]
		public string Address { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Range(typeof(decimal),
			HouseRentingPriceMin,
			HouseRentingPriceMax,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = "Price per month must be a positive number and less than {2} leva")]
		[Display(Name = "Price Per Month")]
		
		public decimal PricePerMonth { get; set; }

		[Display(Name = "Is Rented")]
		public bool IsRented { get; set; }
    }
}