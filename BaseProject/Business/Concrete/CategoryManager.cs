using Business.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.ItemRemoved);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var categories = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(categories,Messages.AllCategoriesTaken);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var category = _categoryDal.Get(c => c.CategoryId == categoryId);
            return new SuccessDataResult<Category>(category);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
