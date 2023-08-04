using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1
{
    class FileManager
    {
        public static bool SaveToTextFile(List<Car> p_cars) {
            try
            {
                using (StreamWriter writer = new StreamWriter("dump.txt"))
                {
                    foreach (Car car in p_cars) {
                        writer.WriteLine(car.make + ":" + car.model + ":" + car.year.ToString() + ":" + car.price.ToString());
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Car> LoadFromTextFile() {
            List<Car> m_cars = new List<Car>();
            using (StreamReader sr = File.OpenText("dump.txt"))
            {
                String s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    String[] strlist = s.Split(':');
                    Car car = new Car(strlist[0], strlist[1], int.Parse(strlist[2]), double.Parse(strlist[3]));
                    m_cars.Add(car);
                }
            }
            return m_cars;
        }
    }
}
