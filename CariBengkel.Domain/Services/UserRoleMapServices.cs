using System;
using System.Linq;
using System.Linq.Expressions;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class UserRoleMapServices : IUserRoleMapServices {
        private static IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _accessor;
        public UserRoleMapServices (IUnitOfWork unitOfWork, IHttpContextAccessor accessor) {
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }

        public BaseResponse<RoleMap> Create (RoleMap model) {
            BaseResponse<RoleMap> result = new BaseResponse<RoleMap> ();
            Expression<Func<RoleMap, bool>> predicate = null;

            try {
                predicate = src => src.CredentialId.Equals (model.CredentialId) && src.RoleId.Equals (model.RoleId);
                var userRole = _unitOfWork.GetRepository<RoleMap> ().Single (predicate);
                if (userRole != null)
                    throw new Exception (Common.Constant.Message.ERR9997);

                _unitOfWork.GetRepository<RoleMap> ().Add (model);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Common.Constant.Message.INFO0000;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }

        public BaseResponse<RoleMap> Update (RoleMap model) {
            BaseResponse<RoleMap> result = new BaseResponse<RoleMap> ();
            Expression<Func<RoleMap, bool>> predicate = null;

            try {
                predicate = src => src.Id.Equals (model.Id);
                var userRole = _unitOfWork.GetReadOnlyRepository<RoleMap> ().Single (predicate);
                if (userRole == null)
                    throw new Exception (Common.Constant.Message.ERR9998);

                userRole.CredentialId = model.CredentialId;
                userRole.RoleId = model.RoleId;

                _unitOfWork.GetRepository<RoleMap> ().Update (userRole);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Common.Constant.Message.INFO0000;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }

        public BaseResponse<RoleMap> Delete (long id) {
            BaseResponse<RoleMap> result = new BaseResponse<RoleMap> ();
            Expression<Func<RoleMap, bool>> predicate = null;

            try {
                predicate = src => src.Id.Equals (id);
                var userRoleMap = _unitOfWork.GetRepository<RoleMap> ().Single (predicate);
                if (userRoleMap == null)
                    throw new Exception (Common.Constant.Message.ERR9998);

                _unitOfWork.GetRepository<RoleMap> ().Delete (id);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Common.Constant.Message.INFO0008;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }

        public BaseResponse<RoleMap> Get (long id) {
            BaseResponse<RoleMap> result = new BaseResponse<RoleMap> ();
            Expression<Func<RoleMap, bool>> predicate = null;

            try {
                predicate = src => src.Id.Equals (id);
                var userRole = _unitOfWork.GetReadOnlyRepository<RoleMap> ().Single (predicate);
                if (userRole == null)
                    throw new Exception (Common.Constant.Message.ERR9998);

                result.Data = userRole;
                result.Status = true;
                result.Message = Common.Constant.Message.INFO0008;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }

        public BaseResponse<RoleMap> GetAll (string searchTerm, int limit, int index) {
            BaseResponse<RoleMap> result = new BaseResponse<RoleMap> ();
            Expression<Func<RoleMap, bool>> predicate = null;

            try {
                if (!string.IsNullOrEmpty (searchTerm))
                    predicate = src => src.Credential.Username.Contains (searchTerm) || src.Role.Name.Contains (searchTerm);

                result.ListData = _unitOfWork.GetReadOnlyRepository<RoleMap> ().GetList (predicate: predicate, orderBy: src => src.OrderBy (x => x.Id), include: src => src.Include (x => x.Credential).Include (x => x.Role), size: limit, index: index);
                result.Status = true;
                result.Message = Common.Constant.Message.INFO9999;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }
    }
}