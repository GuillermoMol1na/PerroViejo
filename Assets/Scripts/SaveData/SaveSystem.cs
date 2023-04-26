using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SaveDay(int day, bool refre){
        BinaryFormatter formatter = new BinaryFormatter();
        string path= Application.persistentDataPath+"/day.per";
        FileStream stream = new FileStream(path, FileMode.Create);

        DayData data = new DayData(day, refre);

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
            Debug.LogError("Datos Guardados no se encontraron en: "+path);
            return null;
        }
    }
}
