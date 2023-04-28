using UnityEngine;

public class Minigame_2 : MonoBehaviour
{
    private GameMaster gm;
    private Timer_2 timer;
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer_2>();

        Invoke("StartMinigame2",2f);
    }
    private void StartMinigame2(){
        if(gm.startMinigame2){
            timer.ActivateTimer();
        }
    }
}
