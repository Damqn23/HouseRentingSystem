using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contract
{
	public interface IAgentService
	{
		Task<bool> ExistByIdAsync(string userId);

		Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber);

		Task<bool> UserHasRentsAsync(string userId);

		Task CreateAsync(string userId, string phoneNumber);

		Task<int?> GetAgentIdAsync(string userId);

	}
}
