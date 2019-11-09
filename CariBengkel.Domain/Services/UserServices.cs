using System;
using System.Linq.Expressions;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Http;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class UserServices : IUserServices {
        private static IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _accessor;

        public UserServices (IUnitOfWork unitOfWork, IHttpContextAccessor accessor) {
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }
        public BaseResponse<User> Create (User model) {
            BaseResponse<User> result = new BaseResponse<User> ();
            Expression<Func<Credentials, bool>> predicateCredential = null;

            try {
                predicateCredential = x => x.Email.Contains (model.IdCredentialNavigation.Email);
                var credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);
                if (credentialModel != null)
                    throw new Exception ("ERROR-0001");

                predicateCredential = x => x.Username.Contains (model.IdCredentialNavigation.Username);
                credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);
                if (credentialModel != null)
                    throw new Exception ("ERROR-0002");

                model.IdCredentialNavigation.CreatedBy = model.IdCredentialNavigation.Username;
                model.IdCredentialNavigation.CreatedOn = DateTime.Now;
                model.IdCredentialNavigation.CreatedHost = _accessor.HttpContext.Connection.RemoteIpAddress.ToString ();

                // _unitOfWork.GetRepository<Credentials> ().Add (model.IdCredentialNavigation);

                model.CreatedBy = model.IdCredentialNavigation.Username;
                model.CreatedOn = DateTime.Now;
                model.CreatedHost = _accessor.HttpContext.Connection.RemoteIpAddress.ToString ();

                _unitOfWork.GetRepository<User> ().Add (model);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0005";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<User> Update (User model) {
            BaseResponse<User> result = new BaseResponse<User> ();
            Expression<Func<User, bool>> predicate = null;
            Expression<Func<Credentials, bool>> predicateCredential = null;

            try {
                predicateCredential = x => x.Email.Contains (model.IdCredentialNavigation.Email) || x.Username.Contains (model.IdCredentialNavigation.Username);
                var credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);
                if (credentialModel != null)
                    throw new Exception ("ERROR-0003");

                credentialModel.Username = model.IdCredentialNavigation.Username;
                credentialModel.Status = model.IdCredentialNavigation.Status;
                credentialModel.ModifiedBy = model.IdCredentialNavigation.Username;
                credentialModel.ModifiedOn = DateTime.Now;
                credentialModel.ModifiedHost = _accessor.HttpContext.Connection.RemoteIpAddress.ToString ();

                _unitOfWork.GetRepository<Credentials> ().Update (credentialModel);

                predicate = x => x.IdCredential.Equals (credentialModel.Id);
                var userModel = _unitOfWork.GetRepository<User> ().Single (predicate);
                if (userModel == null)
                    throw new Exception ("ERROR-0003");

                userModel.FirstName = model.FirstName;
                userModel.LastName = model.LastName;
                userModel.IdCredential = credentialModel.Id;
                userModel.ModifiedBy = model.IdCredentialNavigation.Username;
                userModel.ModifiedOn = DateTime.Now;
                userModel.ModifiedHost = _accessor.HttpContext.Connection.RemoteIpAddress.ToString ();

                _unitOfWork.GetRepository<User> ().Update (userModel);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0006";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<User> Delete (User model) {
            BaseResponse<User> result = new BaseResponse<User> ();
            Expression<Func<User, bool>> predicate = null;
            Expression<Func<Credentials, bool>> predicateCredential = null;

            try {
                predicateCredential = x => x.Id.Equals (model.IdCredentialNavigation.Id);
                var credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);

                _unitOfWork.GetRepository<Credentials> ().Delete (credentialModel);

                predicate = x => x.IdCredential.Equals (model.IdCredentialNavigation.Id);
                var userModel = _unitOfWork.GetRepository<User> ().Single (predicate);

                _unitOfWork.GetRepository<User> ().Delete (userModel);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0007";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<User> Get (User model) {
            BaseResponse<User> result = new BaseResponse<User> ();

            return result;
        }

        public BaseResponse<User> GetAll (User model) {
            BaseResponse<User> result = new BaseResponse<User> ();

            return result;
        }
    }
}