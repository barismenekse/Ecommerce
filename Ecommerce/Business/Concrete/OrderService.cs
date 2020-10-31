using Ecommerce.Business.Abstract;
using Ecommerce.Context;
using Ecommerce.Context.Abstract;
using Ecommerce.Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Ecommerce.Business
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IBasketService basketService;
        private IBasketItemService basketItemService;
        private IOrderDetailService orderDetailService;
        private IUserService userService;
        private IProductService productService;
        [Inject]
        public OrderService(IUnitOfWork unitOfWork, IBasketService basketService, IBasketItemService basketItemService, IOrderDetailService orderDetailService, IUserService userService, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            this.basketService = basketService;
            this.basketItemService = basketItemService;
            this.orderDetailService = orderDetailService;
            this.userService = userService;
            this.productService = productService;

        }
        public List<Order> GetAll()
        {
            return _unitOfWork.OrderRepository.GetAll();
        }
        public Order GetById(params Object[] id)
        {
            return _unitOfWork.OrderRepository.GetById(id);
        }


        public void Create(Basket currentBasket)
        {
            BaseEcommerceContext context = _unitOfWork.Context;



            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order order = new Order();
                    order.paymentType = "nakit";
                    order.shipAdress = "istanbul";
                    order.user = currentBasket.user;
                    order.userId = currentBasket.userId;
                    order.date = DateTime.Now;
                    order.totalPrice = currentBasket.totalPrice;
                    order = this.Insert(order);

                    foreach (var item in currentBasket.basketItems)
                    {
                        Product product = productService.GetById(item.productId);
                        if (product.stockQuantity - item.productQuantity >= 0)
                        {
                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.order = order;
                            orderDetail.product = item.product;
                            orderDetail.productId = item.productId;
                            orderDetail.quantity = item.productQuantity;
                            orderDetail.unitPrice = item.product.unitPrice;
                            orderDetail.order = order;
                            orderDetail.orderId = order.orderId;
                            product.stockQuantity = product.stockQuantity - item.productQuantity;
                            productService.Update(product);
                            orderDetail = orderDetailService.Insert(orderDetail);
                            order.orderDetails.Add(orderDetail);
                        }
                        else
                        {
                            throw new Exception(String.Format("%s isimli üründen yeterli adet yok", item.product.name));
                        }

                    }
                    this.Update(order);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred.");
                    throw ex;
                }

            }




        }

        public Order Insert(Order obj)
        {
            Order result = _unitOfWork.OrderRepository.Insert(obj);
            _unitOfWork.Save();
            return result;
        }
        public void Update(Order obj)
        {
            _unitOfWork.OrderRepository.Update(obj);
            _unitOfWork.Save();
        }


        public void Delete(params Object[] id)
        {
            _unitOfWork.OrderRepository.Delete(id);
            _unitOfWork.Save();
        }


        public Order Select(Expression<Func<Order, bool>> predicate)
        {
            Order obj = _unitOfWork.OrderRepository.Select(predicate);
            return obj;

        }
        public List<Order> SelectAll(Expression<Func<Order, bool>> predicate)
        {
            List<Order> obj = _unitOfWork.OrderRepository.SelectAll(predicate);
            return obj;
        }
    }
}