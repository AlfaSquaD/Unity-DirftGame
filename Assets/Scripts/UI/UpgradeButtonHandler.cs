using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Text _fuelTankCostText;
    [SerializeField]
    private Text _fuelTankLevelText;
    [SerializeField]
    private Text _fuelCapacityCostText;
    [SerializeField]
    private Text _fuelCapacityLevelText;
    [SerializeField]
    private Text _fuelConsumptionCostText;
    [SerializeField]
    private Text _fuelConsumptionLevelText;
    [SerializeField]
    private Text _multiplierCostText;
    [SerializeField]
    private Text _multiplierLevelText;

    private void Awake() {
        _fuelCapacityCostText.text = "Cost: " + SaveController.GetSaveData().fuelCapacityCost;
        _fuelCapacityLevelText.text = "Level: " + SaveController.GetSaveData().fuelCapacityLevel;
        _fuelConsumptionCostText.text = "Cost: " + SaveController.GetSaveData().fuelConsumptionCost;
        _fuelConsumptionLevelText.text = "Level: " + SaveController.GetSaveData().fuelConsumptionLevel;
        _fuelTankCostText.text = "Cost: " + SaveController.GetSaveData().fuelTankCost;
        _fuelTankLevelText.text = "Level: " + SaveController.GetSaveData().fuelTankLevel;
        _multiplierCostText.text = "Cost: " + SaveController.GetSaveData().multiplierCost;
        _multiplierLevelText.text = "Level: " + SaveController.GetSaveData().multiplierLevel;
    }

    public void FuelTankUpgrade(){
        SaveController.GetSaveData().IncremnetFuelTank();
        _fuelTankCostText.text = "Cost: " + SaveController.GetSaveData().fuelTankCost;
        _fuelTankLevelText.text = "Level: " + SaveController.GetSaveData().fuelTankLevel;
    }

    public void FuelCapacityUpgrade(){
        SaveController.GetSaveData().IncremnetFuelCapacity();
        _fuelCapacityCostText.text = "Cost: " + SaveController.GetSaveData().fuelCapacityCost;
        _fuelCapacityLevelText.text = "Level: " + SaveController.GetSaveData().fuelCapacityLevel;
    }

    public void FuelConsumptionUpgrade(){
        SaveController.GetSaveData().IncremnetFuelConsumption();
        _fuelConsumptionCostText.text = "Cost: " + SaveController.GetSaveData().fuelConsumptionCost;
        _fuelConsumptionLevelText.text = "Level: " + SaveController.GetSaveData().fuelConsumptionLevel;
    }

    public void MultiplierUpgrade(){
        SaveController.GetSaveData().IncremnetMultiplier();
        _multiplierCostText.text = "Cost: " + SaveController.GetSaveData().multiplierCost;
        _multiplierLevelText.text = "Level: " + SaveController.GetSaveData().multiplierLevel;
    }
}
