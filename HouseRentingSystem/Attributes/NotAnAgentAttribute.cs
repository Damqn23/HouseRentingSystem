﻿using HouseRentingSystem.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HouseRentingSystem.Attributes
{
	public class NotAnAgentAttribute : ActionFilterAttribute
	{

		
		public override void OnActionExecuting(ActionExecutingContext context)
		{

			IAgentService agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

			if (agentService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (agentService != null 
				&& agentService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
			}



			base.OnActionExecuting(context);

		}
	}
}
