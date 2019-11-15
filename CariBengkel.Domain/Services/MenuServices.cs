using System;
using System.Linq.Expressions;
using CariBengkel.Common.Constant;
using CariBengkel.Domain.Cores;
using CariBengkel.Domain.Responses;
using CariBengkel.Repository.Entity.Model;
using Threenine.Data;

namespace CariBengkel.Domain.Services {
    public class MenuServices : IMenuServices {
        private readonly IUnitOfWork _unitOfWork;
        public MenuServices (IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public BaseResponse<Menu> Create (Menu model) {
            BaseResponse<Menu> result = new BaseResponse<Menu> ();

            try {
                _unitOfWork.GetRepository<Menu> ().Add (model);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Message.INFO0000;
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? Message.ERR0000 : ex.Message;
            }

            return result;
        }

        public BaseResponse<Menu> Update (Menu model) {
            BaseResponse<Menu> result = new BaseResponse<Menu> ();
            Expression<Func<Menu, bool>> predicate = null;

            try {
                predicate = x => x.Id.Equals (model.Id);
                var menuModel = _unitOfWork.GetRepository<Menu> ().Single (predicate);
                if (menuModel == null)
                    throw new Exception (Message.ERR9999);

                menuModel.Title = model.Title;
                menuModel.Status = model.Status;
                menuModel.Url = model.Url;
                menuModel.Parent = model.Parent;

                _unitOfWork.GetRepository<Menu> ().Update (menuModel);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Message.INFO0000;
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? Message.ERR0000 : ex.Message;
            }

            return result;
        }

        public BaseResponse<Menu> Delete (Menu model) {
            BaseResponse<Menu> result = new BaseResponse<Menu> ();
            Expression<Func<Menu, bool>> predicate = null;

            try {
                predicate = x => x.Id.Equals (model.Id);
                var menuModel = _unitOfWork.GetRepository<Menu> ().Single (predicate);
                if (menuModel == null)
                    throw new Exception (Message.ERR9999);

                _unitOfWork.GetRepository<Menu> ().Delete (menuModel);
                _unitOfWork.SaveChanges ();

                result.Status = true;
                result.Message = Message.INFO0008;
            } catch (Exception ex) {
                result.Message = ex.Message.Contains ("ERROR-") == false ? Message.ERR0000 : ex.Message;
            }

            return result;
        }
    }
}