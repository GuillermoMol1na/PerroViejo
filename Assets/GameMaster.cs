using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpointPosBedRoom;
    public Vector2 lastCheckpointPosLivingRoom;
    private int det;
    public float min;
    public float sec;
    public bool BedMade;
    public bool startMinigame2;
    public bool glassfull,usedRedArrowBook,usedRedArrowPC;

    void Start(){
        det = PlayerPrefs.GetInt("dayCompleted");
        glassfull= usedRedArrowBook= usedRedArrowPC= !Converter(det);
        min=PlayerPrefs.GetFloat("minutes");
        sec=PlayerPrefs.GetFloat("seconds");
    }
    void Awake(){
        if(instance==null){
            instance= this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }
    void OnLevelWasLoaded(){
        det = PlayerPrefs.GetInt("dayCompleted");
        if(SceneManager.GetActiveScene().buildIndex != 1){
        min = PlayerPrefs.GetFloat("minutes");
        sec = PlayerPrefs.GetFloat("seconds");
        }else{
            //Acomodate Red Arrows
             RelocateArrowsandBed();
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
       int diff = PlayerPrefs.GetInt("difficulty");
       

       SaveSystem.SaveDay(newDay,0,1,diff,min,sec);

       //RestarDay
       glassfull= usedRedArrowBook= usedRedArrowPC= !Converter(det);
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
