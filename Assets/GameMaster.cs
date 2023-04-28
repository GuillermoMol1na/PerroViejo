using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpointPosBedRoom;
    public Vector2 lastCheckpointPosLivingRoom;
    public bool BedMade;
    public bool startMinigame2;
    public bool glassfull,usedRedArrowBook,usedRedArrowPC;

    void Start(){
        int det = PlayerPrefs.GetInt("dayCompleted");
        glassfull= usedRedArrowBook= usedRedArrowPC= !Converter(det);
    }
    void Awake(){
        if(instance==null){
            instance= this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }
    private void RelocateArrowsandBed(){
        glassfull= usedRedArrowBook= usedRedArrowPC= true;
        BedMade=false;
    }
    public void UpdateSaveDay(){
       int newDay = PlayerPrefs.GetInt("day") + 1;
       PlayerPrefs.SetInt("day",newDay);
       PlayerPrefs.SetInt("dayCompleted",0);
       PlayerPrefs.SetInt("tutorial",1);
       //Acomodate Red Arrows
       RelocateArrowsandBed();

       SaveSystem.SaveDay(newDay,0,1);
    }
    public bool Converter(int num){
        if(num == 1){
            return true;
        }
        else{
            return false;
        }
    }
}
