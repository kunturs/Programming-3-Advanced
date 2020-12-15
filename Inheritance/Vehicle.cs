using System;
namespace lab5solved
{
    public abstract class Vehicle
    {
        public static int NumberOfCreatedObjects;
        protected readonly int _objectNumber;
        protected string Name;
        public abstract void Travel(double distance);
        public override string ToString()
        {
            //Console.WriteLine($"Vehicle ({NumberOfCreatedObjects}) ({Name})");
            return $"Vehicle ({_objectNumber}) {{{Name}}}";
        }

        public Vehicle()
        {
            ++NumberOfCreatedObjects;
            _objectNumber = NumberOfCreatedObjects;
            Console.WriteLine($"Vehicle {Name} is created! ");

        }

        public virtual void Beep()
        {
            Console.WriteLine($"Vehicle {Name} Honks!");
        }
    }

    class Car : Vehicle
    {
        public Car(string name)
        {
            Name = name;
            Console.WriteLine($"Car ({name}) is created!");

        }
        public override string ToString()
        {
            return $"Car ({_objectNumber}) {{{Name}}}";
        }

        public override void Travel(double distance)
        {
            Console.WriteLine($"Car ({Name}) traveled Distance {distance}");
        }

        public override void Beep()
        {
            Console.WriteLine($"Car {Name} Beeps!");
        }


    }

    class Bus : Vehicle
    {
        public static readonly uint passengerLimit = 42;
        uint numbPass;

        public override void Beep()
        {
            Console.WriteLine($"Bus {Name} Beeps!");
        }

        public Bus(string name)
        {
            Name = name;
            Console.WriteLine($"Bus ({name}) is created!");

        }

        public bool SetPassengerCount(uint count)
        {
            if (count > passengerLimit)
                return false;
            numbPass = count;
            return true;
        }

        public int PassengerCount()
        {
            return (int)numbPass;
        }
        public override string ToString()
        {
            return $"Bus ({_objectNumber}) {{{Name}}}";
        }

        public override void Travel(double distance)
        {
            Console.WriteLine($"Bus {Name} Travelled Distance {distance}");
        }
    }

    class Truck : Vehicle
    {
        public static readonly uint capacity=2500;
        private double current;

        public override void Beep()
        {
            Console.WriteLine($"Truck {Name} Beeps!");
        }
        public bool SetLoad(double load) {
            if (load > 2500)
                return false;
            current = load;
            return true;
        }

        public double Load()
        {
            return current;
        }
        public Truck(string name)
        {
            Name = name;
            Console.WriteLine($"Truck ({name}) is created!");
        }
        public override string ToString()
        {
            return $"Truck ({_objectNumber}) {{{Name}}}";
        }

        public override void Travel(double distance)
        {
            Console.WriteLine($"Truck {Name} Travelled Distance {distance}");
        }
    }
}

/* 
Soulution can not contains any compilation errors or warnings!

STAGE 1: 3.0 points

Create abstract class Vehicle and three child classes: Car, Bus and Truck.
Every vehicle has an unique (consecutive) ID which is assign when object is created (common for all vehicles).
Vehicle has an abstract method Travel() which takes as parametr distance in kilometres and for each class displays proper information:
    Car NAME traveled DISTANCE km.
    Bus NAME traveled DISTANCE km with PASSENGER_COUNT passengers.
    Truck NAME traveled DISTANCE km with load of LOAD kg.
Bus has a limited number of passenger which can be transported (passengerLimit) equals 42. 
It is common for all Bus instances and can not be changed but should be accessible to read within main program.
For each Bus, the number of passengers travelling on it can be set using the function SetPassengerCount() and read PassengerCount(). 
If the value is larger then limit then value is not updated and false is return.

Likewise Truck has a limited amount of load which can be transported (capacity) equals 2500 kg and fuctions SetLoad(), Load().
Each class implements ToString() method which returns information about object:
    Vehicle (ID) { NAME }
    Car (ID) { NAME }
    Bus (ID) { NAME } [ PASSENGER_COUNT/PASSENGER_LIMIT ]
    Truck (ID) { NAME } [ LOAD of CAPACITY kg ]
When Car, Bus and Truck is created message "XXX has been created." where XXX is string with information about vehicle

Detailed scoring:
Basic Vehicle class and Car class - 1.0p,
Unique vehicle ID and message about creation of vehicle - 0.5p, 
Bus passenger limit - 0.5p, 
Truck load limit - 0.5p,
ToString for all classes - 0.5p

STAGE 2: 1.0 points

Add Beep method which outputs apropriate message:
    Car NAME beeps!
    Bus NAME beeps!
    Truck NAME beeps with loud trumpet!
But when Car (and only Car) object is reference as Vehicle it returns a message "Vehicle NAME honks!"
where NAME is a vehicle name.

STAGE 3: 1.0 points

Create class Factory (in Factory.cs file) with static method Manuacture() which takes two parameters:
1. type of vehicle to create (only "car", "bus", "truck")
2. name of new vehicle
Use array below to create new vehicles in factroy (use for loop to iterate over all orders)
Display appropriate information if vehicle can be created or not.
    "New XXX has beed added to fleet." where XXX is an information about created object
    "Factory could not manufactured a TYPE."
*/
