using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulation;
using Utils;
using Events;

public class FuelScript : MonoBehaviour
{
    [SerializeField]
    private float fuelAmount;

    private void Awake() {
        fuelAmount = SaveController.GetSaveData().fuelTank;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            InstanceManager.GetInstance<SimulationQueue>().AddEvent(new AddFuelEvent(SaveController.GetSaveData().fuelTank, 0));
            gameObject.SetActive(false);
        }
    }
}
