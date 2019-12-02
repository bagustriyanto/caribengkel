using System.Collections.Generic;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Custom;
using CariBengkel.Repository.Entity.Model;

namespace CariBengkel.Domain.Cores {
    public interface IMenuRoleMapServices {
        BaseResponse<MenuRoleMap> CreateUpdateRemove (List<CustomMenuMap> model);
        BaseResponse<MenuRoleMap> Get (long roleId);
    }
}