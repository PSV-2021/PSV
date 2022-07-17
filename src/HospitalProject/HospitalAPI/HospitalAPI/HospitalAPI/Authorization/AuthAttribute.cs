using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HospitalAPI.Authorization
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(string actionName, string roleType) : base(typeof(AuthorizeAction))
        {
            Arguments = new object[] {
            actionName,
            roleType
        };
        }
    }
}
