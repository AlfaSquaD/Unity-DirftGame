using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulation;

public class DeactivateFuelEvent : IEvent
{
    private GameObject fuel;
    internal override void Command()
    {
        fuel.SetActive(false);
    }

    internal override bool Precondition()
    {
        return fuel.activeInHierarchy;
    }

    public DeactivateFuelEvent(GameObject fuel, float delay) : base(delay)
    {
        this.fuel = fuel;
    }

}
