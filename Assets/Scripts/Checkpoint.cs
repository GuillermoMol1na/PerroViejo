using UnityEngine.SceneManagement;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster  gm;
    int sceneIndex;
    
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            switch(sceneIndex){
                case 1:
                    gm.lastCheckpointPosBedRoom = transform.position;
                break;
                case 2:
                    gm.lastCheckpointPosLivingRoom = transform.position;
                    Debug.Log("La nueva posición de checkpoint es: "+gm.lastCheckpointPosLivingRoom );
                break;
            }
        }
    }
}
