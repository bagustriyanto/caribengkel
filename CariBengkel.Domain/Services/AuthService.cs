using System;
using System.Linq.Expressions;
using System.Security.Cryptography;
using CariBengkel.Common;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Core;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CariBengkel.Domain.Services {
    public class AuthService {
        private static IUnitOfWork _unitOfWork { get; set; }
        // private static Common _common = new Common();
        public AuthService (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse<Credentials> Login (Credentials model) {
            BaseResponse<Credentials> result = null;
            Expression<Func<Credentials, bool>> predicate = null;

            if (!string.IsNullOrEmpty (model.Email))
                predicate = x => x.Email.Equals (model.Email);

            if (!string.IsNullOrEmpty (model.Username))
                predicate = x => x.Username.Equals (model.Username);

            var credential = _unitOfWork.GetRepository<Credentials> ().Single (predicate, null, null);

            result.Data = credential;

            return result;
        }

        public BaseResponse<Credentials> Register (Credentials model) {
            BaseResponse<Credentials> result = null;
            Expression<Func<Credentials, bool>> predicate = null;

            if (!string.IsNullOrEmpty (model.Email)) {
                predicate = x => x.Email.Equals (model.Email);

                var credential = _unitOfWork.GetRepository<Credentials> ().Single (predicate, null, null);
                if (credential != null)
                    throw new Exception ("ERROR-0001");
            }

            if (!string.IsNullOrEmpty (model.Username)) {
                predicate = x => x.Username.Equals (model.Username);
                var credential = _unitOfWork.GetRepository<Credentials> ().Single (predicate, null, null);
                if (credential != null)
                    throw new Exception ("ERROR-0002");
            }

            model.Password = new Password ().PasswordEncrypt (model.Password);

            _unitOfWork.GetRepository<Credentials> ().Add (model);

            result.Status = true;
            result.Message = "REGISTER_SUCCESS";

            return result;
        }
    }
}