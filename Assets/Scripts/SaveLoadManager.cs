using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    SerializedData mydata = new SerializedData();

    public void SaveData()
    {
        
        mydata.ser_score = GameData.Score;
        mydata.ser_health = GameData.PlayerHealth;

        /*
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream myfile = File.Create(Application.persistentDataPath + "/SuperCannonData.save");
        binaryFormatter.Serialize(myfile, mydata);
        myfile.Close();
        */

        //  JSON saving

        string jsonToSave = JsonUtility.ToJson(mydata);
        Debug.Log(jsonToSave);
        //Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/SuperCannonData.json", jsonToSave);
        

        }


    public void LoadData()
    {
        /*
        if (File.Exists(Application.persistentDataPath + "/SuperCannonData.save"))
        {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream myfile = File.Open(Application.persistentDataPath + "/SuperCannonData.save", FileMode.Open);
                mydata = (SerializedData)binaryFormatter.Deserialize(myfile);
                myfile.Close();
                GameData.Score = mydata.ser_score;
                GameData.PlayerHealth = mydata.ser_health;
      
        }
        */


        // JSON loading option
        if (File.Exists(Application.persistentDataPath + "/SuperCannonData.json"))
        {
            string loadedJson = System.IO.File.ReadAllText(Application.persistentDataPath + "/SuperCannonData.json");
            Debug.Log(loadedJson);
            //Debug.Log(Application.persistentDataPath);
            mydata = JsonUtility.FromJson<SerializedData>(loadedJson);
            GameData.Score = mydata.ser_score;
            GameData.PlayerHealth = mydata.ser_health;
        }
        

    }

}
