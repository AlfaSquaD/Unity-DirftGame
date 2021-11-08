using UnityEngine;
using Simulation;
using Utils;

namespace Events{   
    public class AddFuelEvent : IEvent
    {
        public AddFuelEvent(float fuel, float delay) : base(delay)
        {
            this.fuel = fuel;
        }

        private float fuel;

        internal override void Command()
        {
            InstanceManager.GetInstance<PlayerScript>().IncreaseFuel(fuel);
        }

        internal override bool Precondition()
        {
            return InstanceManager.GetInstance<PlayerScript>().IsControlEnabled();
        }
    }
}