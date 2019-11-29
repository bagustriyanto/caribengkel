using System;
using System.Linq;
using System.Linq.Expressions;
using CariBengkel.Common;
using CariBengkel.Common.Constant;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                predicateCredential = x => x.Email.Equals (model.IdCredentialNavigation.Email);
                var credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);
                if (credentialModel != null)
                    throw new Exception ("ERROR-0001");

                predicateCredential = x => x.Username.Equals (model.IdCredentialNavigation.Username);
                credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);
                if (credentialModel != null)
                    throw new Exception ("ERROR-0002");

                var password = new Password ();
                model.IdCredentialNavigation.Salt = password.Salt ();
                model.IdCredentialNavigation.Password = new Password ().PasswordEncrypt (model.IdCredentialNavigation.Password, model.IdCredentialNavigation.Salt);
                model.IdCredentialNavigation.Status = true;
                model.IdCredentialNavigation.CreatedBy = model.IdCredentialNavigation.Username;
                model.IdCredentialNavigation.CreatedOn = DateTime.Now;
                model.IdCredentialNavigation.CreatedHost = _accessor.HttpContext.Connection.RemoteIpAddress.ToString ();

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
                predicateCredential = x => x.Id.Equals (model.IdCredentialNavigation.Id);
                var credentialModel = _unitOfWork.GetRepository<Credentials> ().Single (predicateCredential);
                if (credentialModel == null)
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
                userModel.Phone = model.Phone;
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

        public BaseResponse<User> GetAll (string term, int limit, int index) {
            BaseResponse<User> result = new BaseResponse<User> ();
            Expression<Func<User, bool>> predicate = null;

            try {
                if (!string.IsNullOrEmpty (term)) {
                    predicate = prop => prop.FirstName.ToLower ().Contains (term) ||
                        prop.LastName.ToLower ().Contains (term) || prop.IdCredentialNavigation.Username.ToLower ().Contains (term) ||
                        prop.IdCredentialNavigation.Email.ToLower ().Contains (term);
                }

                result.ListData = _unitOfWork.GetReadOnlyRepository<User> ().GetList (predicate: predicate, orderBy: src => src.OrderBy (x => x.Id),
                    include: src => src.Include (x => x.IdCredentialNavigation), size: limit, index: index);
                result.Status = true;
                result.Message = Message.INFO9999;
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? Message.ERR0000 : ex.Message;
            }

            return result;
        }
    }
}