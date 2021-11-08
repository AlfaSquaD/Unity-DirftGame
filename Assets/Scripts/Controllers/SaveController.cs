using UnityEngine;
using Structs;
public class SaveController{
    private static SaveData data;
    

    public static SaveData GetSaveData(){
        return data = SaveData.LoadGame();
    }

    public static void SaveGame(){
        data.SaveGame();
    }
}