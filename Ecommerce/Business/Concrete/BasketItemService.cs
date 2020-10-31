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
    public class BasketItemService : IBasketItemService
    {
        private IUnitOfWork _unitOfWork;
        [Inject]
        public BasketItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<BasketItem> GetAll()
        {
            return _unitOfWork.BasketItemRepository.GetAll();
        }
        public BasketItem GetById(params Object[] id)
        {
            return _unitOfWork.BasketItemRepository.GetById(id);

        }

        public void Insert(BasketItem obj)
        {
            _unitOfWork.BasketItemRepository.Insert(obj);
            _unitOfWork.Save();

        }
        public void Update(BasketItem obj)
        {
            _unitOfWork.BasketItemRepository.Update(obj);
            _unitOfWork.Save();
        }


        public void Delete(params Object[] id)
        {
            _unitOfWork.BasketItemRepository.Delete(id);
            _unitOfWork.Save();
        }


        public BasketItem Select(Expression<Func<BasketItem, bool>> predicate)
        {
            BasketItem obj = _unitOfWork.BasketItemRepository.Select(predicate);
            return obj;

        }
        public List<BasketItem> SelectAll(Expression<Func<BasketItem, bool>> predicate)
        {
            List<BasketItem> obj = _unitOfWork.BasketItemRepository.SelectAll(predicate);
            return obj;
        }
    }
}