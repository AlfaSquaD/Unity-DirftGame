using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
namespace Structs{
    [Serializable]
    public class SaveData{

        private const float _defaultFuelTank = 10f;

        private const float _defaultFuelConsumption = 5f;

        private const float _defaultFuelCapacity = 30f;

        private const float _defaultMultiplier = .5f;

        public float fuelTank {
            get{
                return (_defaultFuelTank * fuelTankLevel) / 10;
            }
        }

        public float fuelConsumption {
            get{
                return _defaultFuelConsumption - (fuelConsumptionLevel / 50);
            }
        }

        public float fuelCapacity {
            get{
                return (_defaultFuelCapacity * fuelCapacityLevel) / 10;
            }
        }

        public float multiplier { 
            get{
                return (_defaultMultiplier * multiplierLevel) / 10;
            }
        }

        public int fuelTankCost{
            get{
                return (int)Mathf.Pow(fuelTankLevel, 2) * 50;
            }
        }

        public int fuelConsumptionCost{
            get{
                return (int)Mathf.Pow(fuelConsumptionLevel, 2) * 50;
            }
        }

        public int fuelCapacityCost{
            get{
                return (int)Mathf.Pow(fuelCapacityLevel, 2) * 50;
            }
        }

        public int multiplierCost{
            get{
                return (int)Mathf.Pow(multiplierLevel, 2) * 50;
            }
        }

        public int fuelTankLevel { get; private set; }

        public int fuelConsumptionLevel { get; private set; }

        public int fuelCapacityLevel { get; private set; }

        public int multiplierLevel { get; private set; }

        public int money {get; private set; }

        public SaveData(){
            this.fuelTankLevel = 1;
            this.fuelConsumptionLevel = 1;
            this.fuelCapacityLevel = 1;
            this.multiplierLevel = 1;
        }

        public void IncremnetFuelTank(){
            this.fuelTankLevel += 1;
            SaveGame();
        }

        public void IncremnetFuelConsumption(){
            this.fuelConsumptionLevel += 1;
            SaveGame();
        }

        public void IncremnetFuelCapacity(){
            this.fuelCapacityLevel += 1;
            SaveGame();
        }

        public void IncremnetMultiplier(){
            this.multiplierLevel += 1;
            SaveGame();
        }

        public void AddMoney(int amount){
            this.money += amount;
            SaveGame();
        }

        public void SaveGame(){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
            bf.Serialize(file, this);
            file.Close();
        }

        public static SaveData LoadGame(){
            if(File.Exists(Application.persistentDataPath + "/save.dat")){
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);
                file.Close();
                return data;
            }
            
            return new SaveData();
            
        }
    }
    
}