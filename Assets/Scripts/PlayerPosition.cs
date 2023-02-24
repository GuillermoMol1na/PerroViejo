using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;
    // Start is called before the first frame update
void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();  
        if(gm.lastCheckpointPos.x != 0f && gm.lastCheckpointPos.y!= 0f){
            transform.position = gm.lastCheckpointPos;
        }else{
            transform.position = new Vector3(5.08f,3.84f,0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

