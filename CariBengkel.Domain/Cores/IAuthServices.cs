using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;

namespace CariBengkel.Domain.Cores {
    public interface IAuthServices {
        BaseResponse<Credentials> Login (Credentials model);

        BaseResponse<Credentials> Register (Credentials model);
    }
}