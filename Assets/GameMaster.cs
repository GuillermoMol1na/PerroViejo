using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpointPosBedRoom;
    public Vector2 lastCheckpointPosLivingRoom;
    public int det;
    public float min;
    public float sec;
    public int strikes;
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
    public void UpdateDay(bool save){
        BedMade=false;
       //Update the Player Prefas for the next Day
       int newDay = PlayerPrefs.GetInt("day") + 1;
       PlayerPrefs.SetInt("day",newDay);
       PlayerPrefs.SetInt("dayCompleted",0);
       PlayerPrefs.SetInt("tutorial",1);
       int diff = PlayerPrefs.GetInt("difficulty");  
        if(save){
            SaveSystem.SaveDay(newDay,0,1,diff,min,sec);
        }
       //RestarDay
       glassfull= usedRedArrowBook= usedRedArrowPC= true;
    }
    public bool Converter(int num){
        if(num == 1){
            return true;
        }
        else{
            return false;
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }     
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        det = PlayerPrefs.GetInt("dayCompleted");
        if(scene.buildIndex != 1 || (det==1 && PlayerPrefs.GetInt("day")==2)){
        min = PlayerPrefs.GetFloat("minutes");
        sec = PlayerPrefs.GetFloat("seconds");
        strikes = PlayerPrefs.GetInt("strike");
        }
    }
}
