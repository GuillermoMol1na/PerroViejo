using UnityEngine;
using UnityEngine.EventSystems;

public class Options_Answers : MonoBehaviour
{
    private MessageTrigger msgTrigg;
    private GameObject[] theChildren;
    int num;
    EventTrigger trigger;
    public delegate void AcceptOffer();
    public static event AcceptOffer showAccept;
    void Start()
    {
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
                entry.callback.AddListener( (eventData) => { Debug.Log("Partida Guardada");
                                                             msgTrigg.TriggerNextMessage();
                                                             showAccept();
                                                             HideOptions(); });
            }
            else{
                entry.callback.AddListener( (eventData) => { Debug.Log("Partida NO Guardada"); msgTrigg.TriggerNextMessage(); });
            }
            trigger.triggers.Add(entry);
        }
    }
    public void ShowOptions(){
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
