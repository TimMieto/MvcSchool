using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSchool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;


namespace MvcSchool.Authorization
{
    public class ContactAdministratorsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Student>
    {
        protected override Task HandleRequirementAsync(
                                      AuthorizationHandlerContext context,
                            OperationAuthorizationRequirement requirement,
                             Student resource)
        {
            if (context.User == null)
            {
                return Task.FromResult(0);
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.ContactAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
