using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1
{
    class Filter
    {
        public static List<Car> SearchbyCarMake(List<Car> cars, string make) {
            List<Car> result = new List<Car>();
            foreach (Car car in cars) {
                if (car.make.Contains(make)) result.Add(car);
            }
            return result;
        }

        public static List<Car> SearchforCarsSincetheYear(List<Car> cars, int year)
        {
            List<Car> result = new List<Car>();
            foreach (Car car in cars)
            {
                if (car.year > year) result.Add(car);
            }
            return result;
        }

        public static List<Car> SearchforCarsWithinthePriceRange(List<Car> cars, double min, double max) {
            List<Car> result = new List<Car>();
            foreach (Car car in cars)
            {
                if (car.price <= max && car.price >= min) result.Add(car);
            }
            return result;
        }

        public static List<Car> SearchbyCarMakeandPriceRange(List<Car> cars, string make, double min, double max) {
            List<Car> result = Filter.SearchbyCarMake(cars , make);
            result = Filter.SearchforCarsWithinthePriceRange(result, min, max);
            return result;
        }
    }
}
