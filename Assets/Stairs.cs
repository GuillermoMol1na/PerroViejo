
using UnityEngine;

public class Stairs : MonoBehaviour
{
    private MessageTrigger msgTrigg;
    private LevelLoader2 thelevelLoader;
    private string[] finishDayFirst = {"Erwin, el día apenas ha iniciado","Debes finalizar la actividad del día primero antes de subir a tu habitación"};
    private Messages upstairsMsg = new Messages();
    private int dayOver;
    void Start(){
        thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
        upstairsMsg.Include(finishDayFirst);
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        msgTrigg.UsetheMessages(upstairsMsg);
        dayOver = PlayerPrefs.GetInt("dayCompleted");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          if(dayOver==0){
                msgTrigg.TriggerMessage();
          }else{
                thelevelLoader.LoadBedRoom();
          }
        }
    }
}
