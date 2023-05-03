using UnityEngine;
using UnityEngine.EventSystems;

public class Minigame2_Options : MonoBehaviour
{
    private Minigame_2 minigame;
    private PlayerMovement player;
    private bool isActive;
    EventTrigger trigger1;
    EventTrigger trigger2;
    private MessageTrigger msgTrigg;
    private GameObject firstOption;
    private GameObject secondOption;
    public delegate void Game_Over();
    public static event Game_Over goToGameOver;
    void Start(){
        isActive = true;
        firstOption = transform.GetChild(0).gameObject;
        secondOption = transform.GetChild(1).gameObject;
        player = FindObjectOfType<PlayerMovement>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        minigame = GameObject.FindGameObjectWithTag("Minigame2").GetComponent<Minigame_2>();
        AddFunctionality();
        ShowHideOptions();
    }
    private void AddFunctionality(){
        trigger1 = firstOption.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener( (eventData) => {Debug.Log("AQUÍ RESPONDE");
                                                    /*msgTrigg.TriggerNextMessage();
                                                    //End Game
                                                    goToGameOver();
                                                    ShowHideOptions();*/
                                                    LeftButton();
                                                    });
        trigger1.triggers.Add(entry);

        trigger2 = secondOption.AddComponent<EventTrigger>();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerClick;
        entry2.callback.AddListener( (eventData) => {Debug.Log("AQUÍ COLGÓ");
                                                    /*player.PickHangPhone();
                                                    msgTrigg.TriggerNextMessage();
                                                    //Trigger the next call
                                                    minigame.Courutine();
                                                    ShowHideOptions();*/
                                                    RightButton();
                                                    });
        trigger2.triggers.Add(entry2);
    }
    public void ShowHideOptions(){
        isActive = !isActive;
        firstOption.SetActive(isActive);
        secondOption.SetActive(isActive);
    }
    private void LeftButton(){
        msgTrigg.TriggerNextMessage();
        if(minigame.counter < minigame.numberScams){
            goToGameOver();
        }else if(minigame.counter == minigame.numberScams)
        {
            player.PickHangPhone();
            Debug.Log("JUEGO GANADO");
            
            //WINGAME
            
            PlayerPrefs.SetInt("dayCompleted",1);
            minigame.GameEnded();
        }
        ShowHideOptions();
    }
    private void RightButton(){
        msgTrigg.TriggerNextMessage();
        if(minigame.counter <= minigame.numberScams){
            player.PickHangPhone();
            minigame.Courutine();
        }else if(minigame.counter > minigame.numberScams)
        {
            goToGameOver();
        }
        ShowHideOptions();
    }
    void OnEnable(){
        MessageManager.showtheOptions += ShowHideOptions;
    }
    void OnDisable(){
        MessageManager.showtheOptions -= ShowHideOptions;
    }
}
