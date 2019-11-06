using System;
using System.Linq.Expressions;
using System.Security.Cryptography;
using CariBengkel.Common;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class AuthServices : IAuthServices {
        private static IUnitOfWork _unitOfWork { get; set; }
        // private static Common _common = new Common();
        public AuthServices (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse<Credentials> Login (Credentials model) {
            BaseResponse<Credentials> result = new BaseResponse<Credentials> ();
            Expression<Func<Credentials, bool>> predicate = null;

            try {
                if (!string.IsNullOrEmpty (model.Username))
                    predicate = x => x.Username.Equals (model.Username) || x.Email.Equals (model.Username);

                var credential = _unitOfWork.GetRepository<Credentials> ().Single (predicate, null, null);

                if (credential == null)
                    throw new Exception ("ERROR-0003");

                var password = new Password ();
                var passEncrypt = password.PasswordEncrypt (model.Password, credential.Salt);

                if (credential.Password != passEncrypt)
                    throw new Exception ("ERROR-0004");

                credential.Password = null;

                result.Data = credential;
                result.Message = "INFO-0002";
                result.Status = true;
            } catch (Exception ex) {
                result.Status = false;
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Credentials> Register (Credentials model) {
            BaseResponse<Credentials> result = new BaseResponse<Credentials> ();
            Expression<Func<Credentials, bool>> predicate = null;

            try {
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

                var password = new Password ();
                model.Salt = password.Salt ();
                model.Password = new Password ().PasswordEncrypt (model.Password, model.Salt);

                _unitOfWork.GetRepository<Credentials> ().Add (model);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0001";
            } catch (Exception ex) {
                result.Status = false;
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }
            return result;
        }
    }
}