using Business.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
         private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if(product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ItemNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ItemRemoved);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var products = _productDal.GetAll();    
           return new SuccessDataResult<List<Product>>(products, Messages.AllItems);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            var products = _productDal.GetAll(p => p.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var product = _productDal.Get(p => p.ProductId == productId);
            if(product !=null) return new SuccessDataResult<Product>(product);
            else return new ErrorDataResult<Product>(null, Messages.ErrorItem);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();
            if(result != null)
            return new SuccessDataResult<List<ProductDetailDto>>(result,Messages.AllItems);

            else return new ErrorDataResult<List<ProductDetailDto>>(null, Messages.ErrorItem);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
