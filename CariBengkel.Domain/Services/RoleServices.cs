using System;
using System.Linq.Expressions;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class RoleServices : IRoleServices {
        private static IUnitOfWork _unitOfwork;
        public RoleServices (IUnitOfWork unitOfWork) {
            _unitOfwork = unitOfWork;
        }
        public BaseResponse<Role> Create (Role model) {
            BaseResponse<Role> result = new BaseResponse<Role> ();
            Expression<Func<Role, bool>> predicate = null;

            try {
                predicate = x => x.Name.Contains (model.Name);
                var roleModel = _unitOfwork.GetRepository<Role> ().Single (predicate);
                if (roleModel != null)
                    throw new Exception ("ERROR-0006");

                _unitOfwork.GetRepository<Role> ().Add (model);
                _unitOfwork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0000";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Role> Update (Role model) {
            BaseResponse<Role> result = new BaseResponse<Role> ();
            Expression<Func<Role, bool>> predicate = null;

            try {
                predicate = x => x.Id.Equals (model.Id);
                var roleModel = _unitOfwork.GetRepository<Role> ().Single (predicate);
                if (roleModel != null)
                    throw new Exception ("ERROR-0006");
                roleModel.Name = model.Name;
                roleModel.Status = model.Status;

                _unitOfwork.GetRepository<Role> ().Update (roleModel);
                _unitOfwork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0000";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Role> Delete (Role model) {
            BaseResponse<Role> result = new BaseResponse<Role> ();
            Expression<Func<Role, bool>> predicate = null;

            try {
                predicate = x => x.Id.Equals (model.Id);
                var roleModel = _unitOfwork.GetRepository<Role> ().Single (predicate);
                if (roleModel != null)
                    throw new Exception ("ERROR-0006");

                _unitOfwork.GetRepository<Role> ().Delete (roleModel);
                _unitOfwork.SaveChanges ();

                result.Status = true;
                result.Message = "INFO-0000";
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Role> Get (Role model) {
            BaseResponse<Role> result = new BaseResponse<Role> ();
            Expression<Func<Role, bool>> predicate = null;

            try {
                predicate = x => x.Id.Equals (model.Id);
                var roleModel = _unitOfwork.GetRepository<Role> ().Single (predicate);
                if (roleModel != null)
                    throw new Exception ("ERROR-0006");

                result.Status = true;
                result.Message = "INFO-0000";
                result.Data = roleModel;
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }

        public BaseResponse<Role> GetAll (Role model) {
            BaseResponse<Role> result = new BaseResponse<Role> ();
            Expression<Func<Role, bool>> predicate = null;

            try {
                var listRole = _unitOfwork.GetRepository<Role> ().GetList (predicate);

                result.Status = true;
                result.Message = "INFO-0000";
                result.ListData = listRole;
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? "ERROR-0000" : ex.Message;
            }

            return result;
        }
    }
}