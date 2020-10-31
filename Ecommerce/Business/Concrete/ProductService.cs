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
    public class ProductService:IProductService
    {
        private IUnitOfWork _unitOfWork;
        private ICategoryService categoryService;
        [Inject]
        public ProductService(IUnitOfWork unitOfWork,ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            this.categoryService = categoryService;
        }
        public List<Product> GetAll()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }
        public Product GetById(params Object[] id)
        {
            return _unitOfWork.ProductRepository.GetById(id);

        }

        public void Insert(Product obj)
        {
            _unitOfWork.ProductRepository.Insert(obj);
            _unitOfWork.Save();

        }
        public void Update(Product obj)
        {
            if (obj.stockQuantity < 0) throw new Exception("Stok adedi 0 dan büyük olmalı");

            Product exist = this.GetById(obj.productId);
            if (exist == null) throw new Exception();

            exist.description = obj.description;
            exist.name = obj.name;
            exist.stockQuantity = obj.stockQuantity;
            exist.unitPrice = obj.unitPrice;
            exist.categoryId = obj.categoryId;
            exist.category = categoryService.GetById(obj.categoryId);
          
            _unitOfWork.ProductRepository.Update(exist);
            _unitOfWork.Save();
        }


        public void Delete(params Object[] id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Save();
        }


        public Product Select(Expression<Func<Product, bool>> predicate)
        {
            Product obj = _unitOfWork.ProductRepository.Select(predicate);
            return obj;

        }
        public List<Product> SelectAll(Expression<Func<Product, bool>> predicate)
        {
            List<Product> obj = _unitOfWork.ProductRepository.SelectAll(predicate);
            return obj;
        }
    }
}