using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental {CarId=1,CustomerId=1, RentDate = DateTime.Today, ReturnDate = DateTime.Today};
            rentalManager.Add(rental);
            
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.GetAllDetails();

        }



        private static void CarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.getCarDetail();
            if(result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }
    }
}
