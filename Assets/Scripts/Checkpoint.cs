
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster  gm;
    
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            gm.lastCheckpointPos = transform.position;
            print("Nuevo checkpoint es: "+gm.lastCheckpointPos);
        }
    }
}
