using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Custom;
using CariBengkel.Repository.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class MenuRoleMapServices : IMenuRoleMapServices {
        private static IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _accessor;
        public MenuRoleMapServices (IUnitOfWork unitOfWork, IHttpContextAccessor accessor) {
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }

        public BaseResponse<MenuRoleMap> CreateUpdateRemove (List<CustomMenuMap> modelList) {
            BaseResponse<MenuRoleMap> result = new BaseResponse<MenuRoleMap> ();
            Expression<Func<MenuRoleMap, bool>> predicate = null;

            try {
                foreach (var model in modelList) {
                    if (model.MenuRoleMap.Id == 0 && model.Checked) {
                        _unitOfWork.GetRepository<MenuRoleMap> ().Add (model.MenuRoleMap);
                    } else if (model.MenuRoleMap.Id != 0) {
                        predicate = src => src.Id.Equals (model.MenuRoleMap.Id);
                        var userRole = _unitOfWork.GetReadOnlyRepository<MenuRoleMap> ().Single (predicate);
                        if (userRole == null)
                            throw new Exception (Common.Constant.Message.ERR9998);

                        if (model.Checked) {
                            userRole.MenuId = model.MenuRoleMap.MenuId;
                            userRole.RoleId = model.MenuRoleMap.RoleId;

                            _unitOfWork.GetRepository<MenuRoleMap> ().Update (userRole);
                        } else {
                            _unitOfWork.GetRepository<MenuRoleMap> ().Delete (userRole.Id);
                        }
                    }
                }

                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Common.Constant.Message.INFO0000;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }

        public BaseResponse<MenuRoleMap> Get (long roleId) {
            BaseResponse<MenuRoleMap> result = new BaseResponse<MenuRoleMap> ();
            Expression<Func<MenuRoleMap, bool>> predicate = null;

            try {
                predicate = src => src.RoleId.Equals (roleId);
                var userRoleList = _unitOfWork.GetReadOnlyRepository<MenuRoleMap> ().GetList (predicate, include : src => src.Include (x => x.Role).Include (x => x.Menu));
                if (userRoleList == null)
                    throw new Exception (Common.Constant.Message.ERR9998);

                result.ListData = userRoleList;
                result.Status = true;
                result.Message = Common.Constant.Message.INFO9999;
            } catch (System.Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == true ? ex.Message : Common.Constant.Message.ERR0000;
            }

            return result;
        }
    }
}