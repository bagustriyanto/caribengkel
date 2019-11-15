using CariBengkel.Domain.Dto;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;

namespace CariBengkel.Domain.Cores {
    public interface IAuthServices {
        BaseResponse<Credentials> Login (Credentials model);
        BaseResponse<Credentials> Register (Credentials model);
        BaseResponse<Credentials> ResetPassword (DtoCredential model);
        BaseResponse<Credentials> ForgotPassword (Credentials model);
        BaseResponse<Credentials> NewPassword (Credentials model);
        BaseResponse<Credentials> Verification (Credentials model);
    }
}