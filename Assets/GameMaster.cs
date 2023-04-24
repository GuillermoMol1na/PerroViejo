using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpointPosBedRoom;
    public Vector2 lastCheckpointPosLivingRoom;
    public bool BedMade;
    public bool glassfull,usedRedArrowBook,usedRedArrowPC;

    void Start(){
        glassfull=usedRedArrowBook=usedRedArrowPC=true;
    }
    void Awake(){
        if(instance==null){
            instance= this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }
}
