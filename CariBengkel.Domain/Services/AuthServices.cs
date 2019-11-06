using System;
using System.Linq.Expressions;
using System.Security.Cryptography;
using CariBengkel.Common;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Dto;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class AuthServices : IAuthServices {
        private static IUnitOfWork _unitOfWork { get; set; }

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

        public BaseResponse<Credentials> ResetPassword (DtoCredential model) {
            BaseResponse<Credentials> result = new BaseResponse<Credentials> ();
            Expression<Func<Credentials, bool>> predicate = null;

            try {
                predicate = x => x.Email.Contains (model.Email);
                var modelCredential = _unitOfWork.GetRepository<Credentials> ().Single (predicate);
                if (modelCredential == null)
                    throw new Exception ("ERROR-0005");

                var password = new Password ();
                var passEncrypt = password.PasswordEncrypt (model.Password, modelCredential.Salt);
                if (passEncrypt != modelCredential.Password)
                    throw new Exception ("ERROR-0004");

                var confirmPassSalt = password.Salt ();
                var confirmPassEncrypt = password.PasswordEncrypt (model.ConfirmPassword, confirmPassSalt);
                modelCredential.Password = confirmPassEncrypt;
                modelCredential.Salt = confirmPassSalt;

                _unitOfWork.GetRepository<Credentials> ().Update (modelCredential);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0003";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Credentials> ForgotPassword (Credentials model) {
            BaseResponse<Credentials> result = new BaseResponse<Credentials> ();
            Expression<Func<Credentials, bool>> predicate = null;

            try {
                predicate = x => x.Email.Contains (model.Email);
                var modelCredential = _unitOfWork.GetRepository<Credentials> ().Single (predicate);
                if (modelCredential == null)
                    throw new Exception ("ERROR-0005");

                // sent reset password link, link route /auth/newpassword

                result.Status = true;
                result.Message = "INFO-0004";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Credentials> NewPassword (Credentials model) {
            BaseResponse<Credentials> result = new BaseResponse<Credentials> ();
            Expression<Func<Credentials, bool>> predicate = null;

            try {
                predicate = x => x.Email.Contains (model.Email);
                var modelCredential = _unitOfWork.GetRepository<Credentials> ().Single (predicate);
                if (modelCredential == null)
                    throw new Exception ("ERROR-0005");

                var password = new Password ();
                modelCredential.Salt = password.Salt ();
                modelCredential.Password = password.PasswordEncrypt (model.Password, modelCredential.Salt);

                _unitOfWork.GetRepository<Credentials> ().Update (modelCredential);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0003";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }
    }
}