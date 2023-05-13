using UnityEngine;
using UnityEngine.EventSystems;

public class Options_Answers : MonoBehaviour
{
    private GameMaster gm;
    private Music_Manager mm;
    private MessageTrigger msgTrigg;
    private GameObject[] theChildren;
    int num;
    EventTrigger trigger;
    public delegate void AcceptOffer();
    public static event AcceptOffer showAccept;
    public delegate void LoadNextD();
    public static event LoadNextD nextDay;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        num = this.transform.childCount;
        theChildren = new GameObject[num];

        for (int i = 0; i < num; ++i){
             theChildren[i]=transform.GetChild(i).gameObject;
             theChildren[i].SetActive(false);
        }
        AddFunctionality();
        
    }
    private void AddFunctionality(){
        for (int i = 0; i < num; ++i){
            trigger = theChildren[i].AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            if(i==0){
                entry.callback.AddListener( (eventData) => {mm.StopMain();
                                                            gm.UpdateDay(true); 
                                                            Debug.Log("Partida Guardada");
                                                             msgTrigg.TriggerNextMessage();
                                                             showAccept();
                                                             HideOptions();
                                                             nextDay();
                                                              });
            }
            else{
                entry.callback.AddListener( (eventData) => { mm.StartMain();
                                                             gm.UpdateDay(false); 
                                                             Debug.Log("Partida NO Guardada");
                                                             msgTrigg.TriggerNextMessage();
                                                             HideOptions();
                                                             nextDay();
                                                              });
            }
            trigger.triggers.Add(entry);
        }
    }
    public void ShowOptions(){
        //Avoid Skiping message with space
        msgTrigg.BlockforSave();
        for (int i = 0; i < num; ++i){
             theChildren[i].SetActive(true);
        }
    }
    public void HideOptions(){
        for (int i = 0; i < num; ++i){
             theChildren[i].SetActive(false);
        }
    }
    void OnEnable(){
        Bed.showTheOptions += ShowOptions;
    }
    void OnDisable(){
        Bed.showTheOptions -= ShowOptions;
    }
}
