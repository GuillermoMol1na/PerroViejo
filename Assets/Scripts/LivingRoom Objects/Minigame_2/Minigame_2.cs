using UnityEngine;

public class Minigame_2 : MonoBehaviour
{
    private GameMaster gm;
    private Timer_2 timer;
    private MessageTrigger msgTrigg;
    private Messages scamMsg = new Messages();
    private Dialogue_Storage storage = new Dialogue_Storage();
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer_2>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        //Start the Minigame 2
        Invoke("StartMinigame2",5f);
    }

    private void StartMinigame2(){
        if(gm.startMinigame2){
            timer.ActivateTimer();

            string[] dialog = storage.ScamConv(0);
            scamMsg.Include(dialog);
            msgTrigg.UsetheMessages(scamMsg);
            msgTrigg.TriggerMessage();
            int[] lel = storage.RandomOrder();
        }
    }

}
