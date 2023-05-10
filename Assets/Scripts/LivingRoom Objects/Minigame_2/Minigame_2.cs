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
    private Difficulty_Minigame2 difficulty = new Difficulty_Minigame2();
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
        counter=0;
        switch(PlayerPrefs.GetInt("difficulty")){
            case 0:
                numberScams = difficulty.numberOfCallsEasy();
            break;
            case 1:
                numberScams = difficulty.numberOfCallsMedium();
            break;
            case 2:
                numberScams = difficulty.numberOfCallsHard();
            break;
        }
        //Get the random indexes
        randOrder = storage.RandomOrder(numberScams);
        scamMsg = new Messages[numberScams];
        foreach(var lel in randOrder){
            Debug.Log("Random Oreder Array is: "+lel);
        }
        
        //Start the Minigame 2
        StartCoroutine(RingthePhone());
    }
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
            counter++;
        }
    }
    public void StartOrHangUp(){
        int index = randOrder[counter];
        scamMsg[index] = new Messages();
        dialog = storage.ScamConv(index);
        scamMsg[index].Include(dialog);
        msgTrigg.UsetheMessages(scamMsg[index]);
        msgTrigg.TriggerMessage();
        /*if(counter <= numberScams)
            counter++;*/
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
