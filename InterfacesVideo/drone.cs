using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesVideo
{
    internal class Drone: IFlyable, IChargeable
    {
        public string Name { get; set; }
        private int batteryLevel;
        public int BatteryLevel
        {
            get { return batteryLevel; }
            set
            {
                if (value >= 0 && value <= 100)
                    batteryLevel = value;
                else
                {
                    Console.WriteLine("Battery level must be between 0 and 100. currently set to 0, change if needed");
                    batteryLevel = 0; // Set to 0 if the value is out of range
                }
            }
        }
            public Drone(string name, int batteryLevel)
            {
                Name = name;
                BatteryLevel = batteryLevel;
            }
        public void Fly()
        {
            if (BatteryLevel >+ 10)
            {
                Console.WriteLine($"{Name} is flying.");
                batteryLevel -= 10;
            }
            else
            {
                Console.WriteLine($"{Name} cannot fly. Battery is too low dude!🤣.");
            }
        }
        public void Charge()
        {
            Console.WriteLine($"{Name} is charging.");
            batteryLevel = 100;
        }
    }
    
}
