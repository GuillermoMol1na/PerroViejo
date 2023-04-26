using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpointPosBedRoom;
    public Vector2 lastCheckpointPosLivingRoom;
    public bool BedMade;
    public bool glassfull,usedRedArrowBook,usedRedArrowPC;

    void Start(){
        bool glass= Converter(PlayerPrefs.GetInt("minibar"));
        bool book= Converter(PlayerPrefs.GetInt("bookshelf"));
        bool pc= Converter(PlayerPrefs.GetInt("pc"));
        glassfull= glass;
        usedRedArrowBook= book;
        usedRedArrowPC= pc;

    }
    void Awake(){
        if(instance==null){
            instance= this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
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
