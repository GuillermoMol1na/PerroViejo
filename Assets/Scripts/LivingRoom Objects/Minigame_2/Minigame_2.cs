using UnityEngine;

public class Minigame_2 : MonoBehaviour
{
    private GameMaster gm;
    private Timer_2 timer;
    private MessageTrigger msgTrigg;
    private Messages[] scamMsg;
    private Dialogue_Storage storage = new Dialogue_Storage();
    string[] dialog;
    public int numberScams;
    public int counter;
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer_2>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        numberScams=storage.NumberofScams();
        scamMsg = new Messages[numberScams];
        counter=0;
        //Start the Minigame 2
        Invoke("StartMinigame2",5f);
    }

    private void StartMinigame2(){
        if(gm.startMinigame2){
            timer.ActivateTimer();
            //Start with the messages
            StartOrHangUp();
            //int[] lel = storage.RandomOrder();
        }
    }
    public void StartOrHangUp(){
        scamMsg[counter] = new Messages();
        dialog = storage.ScamConv(counter);
        scamMsg[counter].Include(dialog);
        msgTrigg.UsetheMessages(scamMsg[counter]);
        msgTrigg.TriggerMessage();
        if(counter <= numberScams)
            counter++;
    }
}
