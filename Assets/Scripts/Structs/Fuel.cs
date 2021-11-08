namespace Structs
{
    public class Fuel
    {
        public float fuel {get; set;}
        public float maxFuel {get; set;}

        public float fuelConsumption {get; set;}

        public Fuel(float maxFuel, float fuelConsumption)
        {
            this.maxFuel = maxFuel;
            this.fuel = maxFuel;
            this.fuelConsumption = fuelConsumption;
        }

        public static Fuel operator -(Fuel fuel, float amount)
        {
            fuel.fuel -= amount;
            return fuel;
        }

        public static Fuel operator +(Fuel fuel, float amount)
        {
            fuel.fuel += amount;
            return fuel;
        }

        public static bool operator >=(Fuel fuel, float amount)
        {
            return fuel.fuel >= amount;
        }

        public static bool operator <=(Fuel fuel, float amount)
        {
            return fuel.fuel <= amount;
        }

        public static bool operator >(Fuel fuel, float amount)
        {
            return fuel.fuel > amount;
        }

        public static bool operator <(Fuel fuel, float amount)
        {
            return fuel.fuel < amount;
        }

        public override string ToString()
        {
            return "Fuel: " + fuel + "/" + maxFuel;
        }

    }
}