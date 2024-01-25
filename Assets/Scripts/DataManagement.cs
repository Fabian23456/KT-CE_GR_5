using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour
{
    public static DataManagement datamanagement;
    public int score; //score to load
    
    void Awake(){
        if (datamanagement == null)
    {
        DontDestroyOnLoad(gameObject);
        datamanagement = this;
    }
    else if (datamanagement != this)
    {
        Destroy(gameObject);
    }
    }

    public void SaveData (){
        BinaryFormatter BinForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath +  "/gameInfo.dat");
        gameData data = new gameData();
        data.score_1 = score;
        BinForm.Serialize (file, data);
        file.Close();
    }

    public void LoadData(){
        if(File.Exists(Application.persistentDataPath +  "/gameInfo.dat")){
            BinaryFormatter BinForm = new BinaryFormatter(); 
            FileStream file = File.Open(Application.persistentDataPath +  "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            score = data.score_1;
        }
    }
}
[Serializable]
class gameData {
    public int score_1; //The score in file
}
