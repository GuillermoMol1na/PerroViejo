using UnityEngine;
using System.Collections;
public class Minigame_2 : MonoBehaviour
{
    private GameMaster gm;
    private PlayerMovement player;
    private Timer_2 timer;
    private MessageTrigger msgTrigg;
    private Messages[] scamMsg;
    private Messages realMsg;
    private Dialogue_Storage storage = new Dialogue_Storage();
    string[] dialog;
    int[] randOrder;
    public int numberScams;
    public int counter;
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        player = FindObjectOfType<PlayerMovement>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer_2>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        numberScams=storage.NumberofScams();
        scamMsg = new Messages[numberScams];
        //Get the random indexes
        randOrder = storage.RandomOrder();
        counter=0;
        Debug.Log("El día de hoy es: "+PlayerPrefs.GetInt("day"));
        //Start the Minigame 2
        StartCoroutine(RingthePhone());
    }
    /*private void StartMinigame2(){
        if(gm.startMinigame2){
            timer.ActivateTimer();
            //Start with the messages
            StartOrHangUp();
            //int[] lel = storage.RandomOrder();
        }
    }*/
    public void Courutine(){
        StartCoroutine(RingthePhone());
    }
    public IEnumerator RingthePhone(){
        if(gm.startMinigame2){
            //Wait 5 seconds before the call
            yield return new WaitForSeconds(5f);
            Debug.Log("The RINGING STARTS");
            yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.F) );
            Debug.Log("the RINGING STOPS");
            timer.ActivateTimer();
            //Activate the Animation
            player.PickHangPhone();
            //Answering the call
            if(counter < numberScams){
                StartOrHangUp();
            }else if(counter == numberScams){
                PickRealCall();
            }
            
        }

    }
    public void StartOrHangUp(){
        int index = randOrder[counter];
        scamMsg[index] = new Messages();
        dialog = storage.ScamConv(index);
        scamMsg[index].Include(dialog);
        msgTrigg.UsetheMessages(scamMsg[index]);
        msgTrigg.TriggerMessage();
        if(counter <= numberScams)
            counter++;
    }
    public void PickRealCall(){
        realMsg = new Messages();
        dialog = storage.RealCall();
        realMsg.Include(dialog);
        msgTrigg.UsetheMessages(realMsg);
        msgTrigg.TriggerMessage();
    }
    public void GameEnded(){
        timer.DeactivateTimer();
        gm.startMinigame2 =false;
    }
}
