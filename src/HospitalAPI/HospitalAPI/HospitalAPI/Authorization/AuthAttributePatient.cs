using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Authorization
{
    public class AuthAttributePatient : TypeFilterAttribute
    {
        public AuthAttributePatient(string actionName, string roleType) : base(typeof(AuthorizeActionPatient))
        {
            Arguments = new object[] {
            actionName,
            roleType
        };
        }
    }
}
