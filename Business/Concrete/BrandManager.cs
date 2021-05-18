using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
       
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(brand.BrandName.Length < 1)
            {
                return new ErrorResult(Messages.BrandAddedError);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(int id)
        {
            try
            {
                var deleteBrand = _brandDal.Get(b => b.BrandId == id);
                _brandDal.Delete(deleteBrand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
            
            
        }
    }
}
