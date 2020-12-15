using System;
namespace lab5solved
{
    public class Factory
    {
        public static Vehicle Manufacture(string type, string name)
        {
            if (type == "car")
            {
                Car newV = new Car(name);
                Console.WriteLine($"New ({newV}) was manufacture");
                return newV;
                
            }

            else if (type == "bus")
            {
                Bus newV = new Bus(name);
                Console.WriteLine($"New ({newV}) was manufacture");
                return newV;


            }

            else if (type == "truck")
            {
                Truck newV = new Truck(name);
                Console.WriteLine($"New ({newV}) was manufacture");
                return newV;


            }


            Console.WriteLine($"Factory couldnt manufacture ({type})");
            return null;


        }
    }
}
