using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class ColorManager: IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if(color.ColorName.Length < 1)
            {
                return new ErrorResult(Messages.ColorAddedError);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(int id)
        {
            try
            {
                var deleteColor = _colorDal.Get(c => c.ColorId == id);
                _colorDal.Delete(deleteColor);
                return new SuccessResult(Messages.ColorDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}
