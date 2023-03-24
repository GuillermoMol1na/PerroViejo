using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Vector3 BedroominitialPos = new Vector3(-0.01f, 3.65f, 0f);
    private Vector3 LivingRoominitialPos = new Vector3(5.09f,3.23f,0f);
    
    
    private GameMaster gm;
    // Start is called before the first frame update
void Start(){
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        switch(sceneIndex){
                case 1:
                if(gm.lastCheckpointPosBedRoom.x != 0f && gm.lastCheckpointPosBedRoom.y!= 0f){
                    transform.position = gm.lastCheckpointPosBedRoom;
                }else{
                    transform.position = BedroominitialPos;
                }
                break;
                case 2:
                if(gm.lastCheckpointPosLivingRoom.x != 0f && gm.lastCheckpointPosLivingRoom.y!= 0f){
                    transform.position = gm.lastCheckpointPosLivingRoom;
                }else{
                    transform.position = LivingRoominitialPos;
                }
                break;
            }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

