using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InterWind : MonoBehaviour
{
    private Minigame_1 theMinigame;
    private Internet_1_Controller internetController;
    private GameObject link;
    private GameObject theTab;
    private Vector2 thePosition;
    public TabGroup tabGroup;
    private DownloadLink creation = new DownloadLink();
    private TMP_FontAsset pixelFont;
    private string nameWindow;
    public delegate void CloseRespectiveTab(int childIndex);
    public static event CloseRespectiveTab closeTheTab;
    void Start()
    {
        theMinigame = Minigame_1.FindObjectOfType<Minigame_1>();
        internetController = Internet_1_Controller.FindObjectOfType<Internet_1_Controller>();
        pixelFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/Pixel_Font");
        
        if(this.transform.name == "FirstElement"){
            this.gameObject.SetActive(true);
        }else{
            this.gameObject.SetActive(false);
            AddTheLinks(theMinigame.Reshuffle());
        }
        tabGroup.WindowSystem(this.gameObject);

        nameWindow = this.name.Substring(this.name.Length -1);
    }
    public void DeleteWind(){
        closeTheTab(this.transform.GetSiblingIndex());
        this.gameObject.SetActive(false);
        Destroy(this);
    }
    public void AddTheLinks(Sprite[] thesprite){
        creation.SetSprites(thesprite);
        for(int i=0; i<15;i++){
        //Creating the link
        link = new GameObject("ICONO_"+i.ToString());

        link = creation.createDLinks(link,i);

        thePosition = creation.givePosition(i);

        //Addinf the Event Trigger
        //theTab = GameObject.Find("Tab"+i+1);
        //TabButton tabBut= theTab.GetComponent<TabButton>();

        EventTrigger trigger = link.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        if(theMinigame.theRealIndex == i){
            entry.callback.AddListener( (eventData) => { internetController.NewTabwindow();} );
        }else{
            entry.callback.AddListener( (eventData) => { DeleteWind();} );
        }
        
        trigger.triggers.Add(entry);
        //Setting thew parent
        link.transform.SetParent(this.transform);
        link.transform.localPosition = thePosition;
        
        }
        GameObject textObject = creation.PageText(pixelFont);
        textObject.transform.SetParent(this.transform);
        textObject.transform.localPosition=new Vector3(526.72f, 85f, 0);

    }

}
