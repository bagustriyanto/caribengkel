using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;

namespace CariBengkel.Domain.Cores {
    public interface IRoleServices {
        BaseResponse<Role> Create (Role model);
        BaseResponse<Role> Update (Role model);
        BaseResponse<Role> Delete (long id);
        BaseResponse<Role> Get (long id);
        BaseResponse<Role> GetAll (string name, int limit, int index);
    }
}