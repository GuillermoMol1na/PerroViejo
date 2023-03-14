using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   [SerializeField] private UseDoor useDoor;
   [SerializeField] private PlayerMovement player;
   [SerializeField] private Bed bed;
 
   private MessageTrigger msgTrigg;
    private string[] makebedMssg = {"Deberías hacer tu cama antes de bajar primero",
                                    "En serio"};
    private Messages mkBedMsg = new Messages();
    void Start(){
        mkBedMsg.Include(makebedMssg);
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
    }
    void Update()
    {
        if(player.baseColl.IsTouching(useDoor.doorColl) && Input.GetKeyDown(KeyCode.F)){
            if(bed.confirm){
                useDoor.OpenDoor();
            }
            else{
            msgTrigg.UsetheMessages(mkBedMsg);
            msgTrigg.TriggerMessage();
            }
        }
    }
}
