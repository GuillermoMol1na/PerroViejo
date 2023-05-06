using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SaveDay(int day, int dayOver, int tutorial, int difficulty, float minutes, float seconds){
        BinaryFormatter formatter = new BinaryFormatter();
        string path= Application.persistentDataPath+"/day.per";
        FileStream stream = new FileStream(path, FileMode.Create);

        DayData data = new DayData(day, dayOver, tutorial,difficulty, minutes, seconds);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }
    public static DayData LoadData(){
        string path= Application.persistentDataPath+"/day.per";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            DayData data = formatter.Deserialize(stream) as DayData;
            stream.Close();

            return data;
        }else{
            Debug.Log("Datos Guardados no se encontraron en: "+path);
            DayData spareData =new DayData(0,0,1,0,0,0);
            return spareData;
        }
    }
}
