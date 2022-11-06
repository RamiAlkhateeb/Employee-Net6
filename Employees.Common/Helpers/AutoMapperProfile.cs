using AutoMapper;
using Employees.Common.Models.API;
using Employees.Common.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<EmployeeRequest, Employee>();

            // UpdateRequest -> User
            //CreateMap<UpdateRequest, User>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //            // ignore both null & empty string properties
            //            if (prop == null) return false;
            //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            // ignore null role
            //            if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
