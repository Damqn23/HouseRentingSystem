﻿using HouseRentingSystem.Core.Contract;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HouseRentingSystem.Controllers;

namespace HouseRentingSystem.Attributes
{
    public class MustBeAgent : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {

            IAgentService agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (agentService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (agentService != null
                && agentService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
            }



            base.OnActionExecuting(context);

        }
    }
}
