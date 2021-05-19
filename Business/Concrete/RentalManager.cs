using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(p => p.CarId == rental.CarId);
            if(result.ReturnDate > DateTime.Now)
            {
                return new ErrorResult("Kiralanmak İstenen Araba Henüz Teslim Edilmemiş!");
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Araba Kiralandı. Güle Güle Kullanın :))");
            }
        }

        public IDataResult<List<RentalsDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalDal.GetAllDetails(),"Listleme Başarılı.");
        }
    }
}
