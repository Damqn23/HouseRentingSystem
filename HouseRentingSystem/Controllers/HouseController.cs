﻿using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contract;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Extensions;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Controllers
{
	public class HouseController : BaseController
	{
		private readonly IHouseService houseService;

		private readonly IAgentService agentService;

		private readonly ILogger logger;

        public HouseController(IHouseService _houseService
			, IAgentService _agentService
			,ILogger<HouseController> _logger)
        {
			logger = _logger;
            houseService = _houseService;
            agentService = _agentService;
        }

        [HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery]AllHousesQueryModel model)
		{
			var houses = await houseService.AllAsync(
				model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.HousesPerPage);

            model.TotalHousesCount = houses.TotalHousesCount;
            model.Houses = houses.Houses;
            model.Categories = await houseService.AllCategoriesNamesAsync();

			return View(model);
		}
		[HttpGet]

		public async Task<IActionResult> Mine()
		{
			var userId = User.Id();
			IEnumerable<HouseServiceModel> model;

			if(await agentService.ExistByIdAsync(userId))
			{
				int agentId = await agentService.GetAgentIdAsync(userId)?? 0;
				model = await houseService.AllHousesByAgentIdAsync(agentId);
			}
			else
			{
				model = await houseService.AllHousesByUserIdAsync(userId);
			}

			return View(model);
		}
		[HttpGet]

		public async Task<IActionResult> Details(int id, string information)
		{
			if (await houseService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await houseService.HouseDetailsByIdASync(id);

			if(information != model.GetInformation())
			{
				return BadRequest();
			}

			return View(model);
		}
		[HttpGet]
		[MustBeAgent]
		public async Task<IActionResult> Add()
		{

			var model = new HouseFormModel()
			{
				Categories = await houseService.AllCategoriesAsync()
			};
			return View(model);
		}
		[HttpPost]
		[MustBeAgent]
		public async Task<IActionResult> Add(HouseFormModel model)
		{
			if(await houseService.CategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
			}

			if(ModelState.IsValid == false)
			{
				model.Categories = await houseService.AllCategoriesAsync();

				return View(model);
			}

			int? agentId = await agentService.GetAgentIdAsync(User.Id());

			int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);

			return RedirectToAction(nameof(Details), new { id = newHouseId, information = model.GetInformation()});
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{

			if(await houseService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if(await houseService.HasAgentWithIdAsync(id,User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = await houseService.GetHouseFormModelByIdAsync(id);
			
			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> Edit(int id,HouseFormModel model)
		{

            if (await houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

			if(ModelState.IsValid == false)
			{
				model.Categories = await houseService.AllCategoriesAsync();

				return View(model);
			}

			await houseService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation()});
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			

			if(await houseService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if(await houseService.HasAgentWithIdAsync(id,User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var house = await houseService.HouseDetailsByIdASync(id);

			var model = new HouseDetailsViewModel()
			{
				Id = id,
				Address = house.Address,
				ImageUrl = house.ImageUrl,
				Title = house.Title,
			};
				

            return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> Delete(HouseDetailsViewModel model)
		{

            if (await houseService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(model.Id, User.Id()) == false
				&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

			await houseService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
		}

		[HttpPost]

		public async Task<IActionResult> Rent(int id)
		{
			if(await houseService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if(await agentService.ExistByIdAsync(User.Id()))
			{
				return Unauthorized();
			}

			if(await houseService.IsRentedAsync(id))
			{
				return BadRequest();
			}

			await houseService.RentAsync(id, User.Id());

			return RedirectToAction(nameof(All));
		}

		[HttpPost]

		public async Task<IActionResult> Leave(int id)
		{
            if (await houseService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

			try
			{
                await houseService.LeaveAsync(id, User.Id());
            }
			catch (UnauthorizedActionException uae)
			{
				logger.LogError(uae, "HouseController/Leave");

				return Unauthorized();
			}

			

            return RedirectToAction(nameof(All));
		}
	}
}
