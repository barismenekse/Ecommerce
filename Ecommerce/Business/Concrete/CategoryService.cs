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
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        [Inject]
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }
        public Category GetById(params Object[] id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);

        }

        public void Insert(Category obj)
        {
            _unitOfWork.CategoryRepository.Insert(obj);
            _unitOfWork.Save();

        }
        public void Update(Category obj)
        {
            Category exist = this.GetById(obj.categoryId);
            exist.name = obj.name;
            exist.parentCategoryId = obj.parentCategoryId;
            exist.parentCategory = this.GetById(obj.parentCategoryId);
            _unitOfWork.CategoryRepository.Update(exist);
            _unitOfWork.Save();
        }


        public void Delete(params Object[] id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Save();
        }


        public Category Select(Expression<Func<Category, bool>> predicate)
        {
            Category obj = _unitOfWork.CategoryRepository.Select(predicate);
            return obj;

        }
        public List<Category> SelectAll(Expression<Func<Category, bool>> predicate)
        {
            List<Category> obj = _unitOfWork.CategoryRepository.SelectAll(predicate);
            return obj;
        }
    }
}