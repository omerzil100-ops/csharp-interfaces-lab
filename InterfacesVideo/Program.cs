using System;

public class Program
{
    public static void Main()
    {
        // משימה 2: צרו כאן את אובייקט ה-Drone לאחר מימוש המחלקה.
        Drone drone = new Drone("dji", 0);

        IFlyable[] flyers =
        {
            new Bird(),
            new Airplane(),
            new Superman(),
            drone
            // משימה 2: הוסיפו גם את ההפניה לרחפן שיצרתם.
        }; 

        IChargeable[] devices =
        {
            new ElectricCar(),
            new Phone(),
            new RobotVacuum(),
            drone
            // משימה 2: הוסיפו את ההפניה לאותו רחפן.
        };

        // טוענים תחילה, כדי שכלי שדורש טעינה יוכל לעוף בהמשך.
        // משימה 3: הדפיסו כאן מצבי סוללה דרך devices לפני הטעינה.
        Console.WriteLine("--- Charge through IChargeable[] ---");
        ChargeAll(devices);
        // משימה 3: הדפיסו שוב מצבי סוללה דרך devices לאחר הטעינה.

        Console.WriteLine("--- Fly through IFlyable[] ---");
        FlyAll(flyers);
        // משימה 2: הדפיסו כאן את אחוז הסוללה של הרחפן לאחר הטיסה.
        Console.WriteLine(drone.BatteryLevel());

        object[] items =
        {
            new Phone(),
            new GasolineCar(),
            new RobotVacuum()
        };

        Console.WriteLine("--- is: type check ---");
        object item = new GasolineCar();
        bool canCharge = item is IChargeable;
        Console.WriteLine(canCharge);

        Console.WriteLine("--- is: check and interface reference ---");
        foreach (object current in items)
        {
            if (current is IChargeable chargeable)
            {
                chargeable.Charge();
            }
        }

        Console.WriteLine("--- as: interface reference or null ---");
        object phone = new Phone();
        IChargeable? phoneChargeable = phone as IChargeable;
        if (phoneChargeable != null)
        {
            phoneChargeable.Charge();
        }

        // אותו דפוס על המערך המעורב: מכונית הבנזין אינה נטענת.
        foreach (object current in items)
        {
            IChargeable? chargeable = current as IChargeable;
            if (chargeable != null)
            {
                chargeable.Charge();
            }
        }
    }

    // לולאת התעופה מהסרטון נארזה בפעולה לקבלת מערך כפרמטר.
    public static void FlyAll(IFlyable[] flyers)
    {
        foreach (IFlyable flyer in flyers)
        {
            flyer.Fly();
        }
    }

    // לולאת הטעינה מהסרטון נארזה בפעולה לקבלת מערך כפרמטר.
    public static void ChargeAll(IChargeable[] devices)
    {
        foreach (IChargeable device in devices)
        {
            device.Charge();
        }
    }
}
