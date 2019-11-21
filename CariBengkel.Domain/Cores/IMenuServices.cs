using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;

namespace CariBengkel.Domain.Cores {
    public interface IMenuServices {
        BaseResponse<Menu> Create (Menu model);
        BaseResponse<Menu> Update (Menu model);
        BaseResponse<Menu> Delete (Menu model);
        BaseResponse<Menu> Get (Menu model);
        BaseResponse<Menu> GetList (string title, int index, int limit);
    }
}