using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Concrete
{
    public class EFCarRepository:ICarRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Car> Cars
        {
            get { return context.Cars; }
        }
        public void SaveCar(Car car)
        {
            if (car.CarId == 0)
                context.Cars.Add(car);
            else
            {
                Car dbEntry = context.Cars.Find(car.CarId);
                if (dbEntry != null)
                {
                    dbEntry.Category = car.Category;
                    dbEntry.Description = car.Description;
                    dbEntry.MileageCar = car.MileageCar;
                    dbEntry.NumberOfOwners = car.NumberOfOwners;
                    dbEntry.YearOfManufacture = car.YearOfManufacture;
                    dbEntry.Price = car.Price;
                    dbEntry.ImageData = car.ImageData;
                    dbEntry.ImageMimeType = car.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Car DeleteCar(int carId)
        {
            Car dbEntry = context.Cars.Find(carId);
            if (dbEntry != null)
            {
                context.Cars.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
