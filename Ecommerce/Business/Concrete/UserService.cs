using Ecommerce.Business.Abstract;
using Ecommerce.Context;
using Ecommerce.Context.Abstract;
using Ecommerce.Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ecommerce.Business
{
    public class UserService:IUserService
    {
        private IUnitOfWork _unitOfWork;
        [Inject]
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll();
        }
        public User GetById(params Object[] id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }

        public void Insert(User obj)
        {
            _unitOfWork.UserRepository.Insert(obj);
            _unitOfWork.Save();

        }
        public void Update(User obj)
        {
            _unitOfWork.UserRepository.Update(obj);
            _unitOfWork.Save();
        }

        public void Delete(params Object[] id)
        {
            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Save();
        }

        public User Select(Expression<Func<User, bool>> predicate)
        {
            User obj = _unitOfWork.UserRepository.Select(predicate);
            return obj;
        }
        public List<User> SelectAll(Expression<Func<User, bool>> predicate)
        {
            List<User> obj = _unitOfWork.UserRepository.SelectAll(predicate);
            return obj;
        }
    }
}