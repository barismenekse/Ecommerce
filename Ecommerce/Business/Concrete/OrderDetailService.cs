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
    public class OrderDetailService : IOrderDetailService
    {
        private IUnitOfWork _unitOfWork;
        [Inject]
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OrderDetail> GetAll()
        {
            return _unitOfWork.OrderDetailRepository.GetAll();
        }
        public OrderDetail GetById(params Object[] id)
        {
            return _unitOfWork.OrderDetailRepository.GetById(id);

        }

        public OrderDetail Insert(OrderDetail obj)
        {
            OrderDetail result = _unitOfWork.OrderDetailRepository.Insert(obj);
            _unitOfWork.Save();
            return result;

        }
        public void Update(OrderDetail obj)
        {
            _unitOfWork.OrderDetailRepository.Update(obj);
            _unitOfWork.Save();
        }


        public void Delete(params Object[] id)
        {
            _unitOfWork.OrderDetailRepository.Delete(id);
            _unitOfWork.Save();
        }


        public OrderDetail Select(Expression<Func<OrderDetail, bool>> predicate)
        {
            OrderDetail obj = _unitOfWork.OrderDetailRepository.Select(predicate);
            return obj;

        }
        public List<OrderDetail> SelectAll(Expression<Func<OrderDetail, bool>> predicate)
        {
            List<OrderDetail> obj = _unitOfWork.OrderDetailRepository.SelectAll(predicate);
            return obj;
        }
    }
}