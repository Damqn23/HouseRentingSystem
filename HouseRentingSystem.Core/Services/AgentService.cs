using HouseRentingSystem.Core.Contract;
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
	public class AgentService : IAgentService
	{
		private readonly IRepository repository;
        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

		public Task CreateAsync(string userId, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> ExistByIdAsync(string userId)
		{
			return await repository.AllReadOnly<Agent>()
				.AnyAsync(a => a.UserId == userId);
		}

		public Task<bool> UserHasRentsAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
		{
			throw new NotImplementedException();
		}
	}
}
