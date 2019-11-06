using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;

namespace CariBengkel.Domain.Cores {
    public interface IRoleServices {
        BaseResponse<Role> Create (Role model);
        BaseResponse<Role> Update (Role model);
        BaseResponse<Role> Delete (Role model);
        BaseResponse<Role> Get (Role model);
        BaseResponse<Role> GetAll (Role model);
    }
}