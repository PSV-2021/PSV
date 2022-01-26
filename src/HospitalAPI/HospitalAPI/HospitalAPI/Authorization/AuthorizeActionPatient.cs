using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Authorization
{
    public class AuthorizeActionPatient : IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly string _roleType;
        public AuthorizeActionPatient(string actionName, string roleType)
        {
            _actionName = actionName;
            _roleType = roleType;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string _roleType = context.HttpContext.Request?.Headers["role"].ToString();
            switch (_actionName)
            {
                case "Get":
                    if (!_roleType.Contains("patient")) context.Result = new UnauthorizedResult();
                    break;
                case "Post":
                    if (!_roleType.Contains("patient")) context.Result = new UnauthorizedResult();
                    break;
            }
        }
    }
}
