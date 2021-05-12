using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest1();
            //BrandTest();
            ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager efcolorManager = new ColorManager(new EfColorDal());
            Color turquoise = new Color();
            turquoise.ColorName = "Turkuaz";
            efcolorManager.Add(turquoise);
            efcolorManager.Delete(7);
            foreach (var color in efcolorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager efBrandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand();
            brand1.BrandName = "Tofaş";
            efBrandManager.Add(brand1);
            foreach (var brand in efBrandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.getCarDetail())
            {
                Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
            }
        }
    }
}
