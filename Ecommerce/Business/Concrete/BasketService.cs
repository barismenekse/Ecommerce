using Ecommerce.Business.Abstract;
using Ecommerce.Context;
using Ecommerce.Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ecommerce.Business
{
    public class BasketService : IBasketService
    {
        private UnitOfWork _unitOfWork;
        IBasketItemService basketItemService;
        IProductService productService;
        [Inject]
        public BasketService(UnitOfWork unitOfWork, IBasketItemService basketItemService, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            this.basketItemService = basketItemService;
            this.productService = productService;
        }

        public void addItem(Basket basket, int? productId)
        {
            if (basket == null || productId == null) throw new Exception();
            BasketItem searchItem;
            Product product = productService.GetById(productId);
            if (basket.basketItems == null)
            {
                basket.basketItems = new List<BasketItem>();
                searchItem = null;
            }
            else searchItem = basket.basketItems.FirstOrDefault(x => x.productId == productId);

            if (searchItem == null && product != null)
            {
                BasketItem item = new BasketItem();
                item.basketId = basket.basketId;
                item.basket = basket;
                item.product = product;
                item.productId = product.productId;
                item.productQuantity = 1;
                item.totalPrice = item.productQuantity * item.product.unitPrice;
                basket.basketItems.Add(item);
                basketItemService.Insert(item);
                basket.totalPrice = basket.totalPrice + item.totalPrice;
                _unitOfWork.Save();
            }

        }

        public void removeItem(Basket basket, BasketItem item)
        {
            if (basket == null || item == null) throw new Exception();
            BasketItem searchItem = basket.basketItems.FirstOrDefault(x => x.productId == item.productId);
            if (searchItem != null)
            {
                basket.basketItems.Remove(searchItem);
                basketItemService.Delete(searchItem.basketItemId);
                basket.totalPrice = basket.totalPrice - searchItem.totalPrice;
                _unitOfWork.Save();
            }
        }

        public List<Basket> GetAll()
        {
            return _unitOfWork.BasketRepository.GetAll();
        }
        public Basket GetById(params Object[] id)
        {
            return _unitOfWork.BasketRepository.GetById(id);

        }

        public void Insert(Basket obj)
        {
            _unitOfWork.BasketRepository.Insert(obj);
            _unitOfWork.Save();

        }
        public void Update(Basket obj)
        {
            _unitOfWork.BasketRepository.Update(obj);
            _unitOfWork.Save();
        }


        public void Delete(params Object[] id)
        {
            _unitOfWork.BasketRepository.Delete(id);
            _unitOfWork.Save();
        }


        public Basket Select(Expression<Func<Basket, bool>> predicate)
        {
            Basket obj = _unitOfWork.BasketRepository.Select(predicate);
            return obj;

        }
        public List<Basket> SelectAll(Expression<Func<Basket, bool>> predicate)
        {
            List<Basket> obj = _unitOfWork.BasketRepository.SelectAll(predicate);
            return obj;
        }
    }
}