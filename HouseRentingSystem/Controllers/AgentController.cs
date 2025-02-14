﻿using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contract;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Controllers
{

	public class AgentController : BaseController
	{
		private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }
        [HttpGet]
		[NotAnAgent]
		public IActionResult Become()
		{
			
			var model = new BecomeAgentFormModel();
			return View(model);
		}

		[HttpPost]
		[NotAnAgent]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			if(await agentService.UserWithPhoneNumberExistAsync(User.Id()))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
			}

			if(await agentService.UserHasRentsAsync(model.PhoneNumber))
			{
				ModelState.AddModelError("Error", HasRent);
			}

			if (ModelState.IsValid == false)
			{
				return View(model);
			}
			await agentService.CreateAsync(User.Id(), model.PhoneNumber);

			return RedirectToAction(nameof(HouseController.All),"House");
		}
	}
}
