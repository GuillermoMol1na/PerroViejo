using UnityEngine;
public class Stairs : MonoBehaviour
{
    private GameMaster  gm;
    private MessageTrigger msgTrigg;
    private LevelLoader2 thelevelLoader;
    private string[] finishDayFirst = {"Erwin, el día apenas ha iniciado","Debes finalizar la actividad del día primero antes de subir a tu habitación"};
    private Messages upstairsMsg = new Messages();
    private int dayOver;
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
        upstairsMsg.Include(finishDayFirst);
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        msgTrigg.UsetheMessages(upstairsMsg);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {   dayOver = PlayerPrefs.GetInt("dayCompleted");
        if (other.gameObject.tag == "Player" && !gm.startMinigame2)
        {
          if(dayOver==0){
                msgTrigg.TriggerMessage();
          }else{
                //Reasign the position
                gm.lastCheckpointPosLivingRoom=new Vector3(5.09f,3.23f,0f);
                thelevelLoader.LoadBedRoom();
          }
        }
    }
}