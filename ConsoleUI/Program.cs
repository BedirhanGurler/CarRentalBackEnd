using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest1();
           
        }

        private static void CarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if(result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }
    }
}
