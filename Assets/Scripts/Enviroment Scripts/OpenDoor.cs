using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   [SerializeField] private UseDoor useDoor;
   [SerializeField] private PlayerMovement player;
   [SerializeField] private Bed bed;
 
   [SerializeField] private MessageTrigger msgTrigg;
    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(useDoor.doorColl) && Input.GetKeyDown(KeyCode.F)){
            if(bed.confirm){
                useDoor.OpenDoor();
            }
            else{
            msgTrigg.TriggerMessage();
            }
        }
    }
}
