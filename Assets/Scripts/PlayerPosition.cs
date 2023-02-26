using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Vector3 BedroominitialPos = new Vector3(-0.01f, 3.65f, 0f);
    private Vector3 LivingRoominitialPos = new Vector3(5.08f,3.84f,0f);
    
    private GameMaster gm;
    // Start is called before the first frame update
void Start(){
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        switch(sceneIndex){
                case 0:
                    transform.position = BedroominitialPos;
                break;
                case 1:
                if(gm.lastCheckpointPos.x != 0f && gm.lastCheckpointPos.y!= 0f){
                    transform.position = gm.lastCheckpointPos;
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

