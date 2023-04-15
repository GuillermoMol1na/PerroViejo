using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

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
    public delegate void CloseRespectiveTab(int childIndex);
    public static event CloseRespectiveTab closeTheTab;
    void Start()
    {
        theMinigame = Minigame_1.FindObjectOfType<Minigame_1>();
        internetController = Internet_1_Controller.FindObjectOfType<Internet_1_Controller>();
        pixelFont = Resources.Load<TMPro.TMP_FontAsset>("Fonts/Pixel_Font");
        
        if(this.transform.name.Contains("Mistake")){
            this.gameObject.SetActive(true);
            CreatetheFailWindow();
        }else{
            this.gameObject.SetActive(false);
            AddTheLinks(theMinigame.Reshuffle());
        }
        tabGroup.WindowSystem(this.gameObject);
    }
    public void DeleteWind(){
        Debug.Log("Se está eliminando la VENTANA con posición: "+this.transform.GetSiblingIndex() );
        closeTheTab(this.transform.GetSiblingIndex());
        internetController.TabhasbeenRemoved();
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

        EventTrigger trigger = link.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        if(theMinigame.theRealIndex == i){
            entry.callback.AddListener( (eventData) => { internetController.NewTabwindow("Window");} );
        }else{
            entry.callback.AddListener( (eventData) => { internetController.NewTabwindow("Mistake"); DeleteWind();} );
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
    public void CreatetheFailWindow(){
        //GameObject baseE = new GameObject("Mistake_Window");
        GameObject icon = new GameObject("Icon");
        RectTransform transicon= icon.AddComponent<RectTransform>();
        Image iconImage = icon.AddComponent<Image>();
        Vector2 dimensions = theMinigame.RealAnti().bounds.size*5f;
        transicon.sizeDelta = dimensions;
        //transicon.localPosition = new Vector3(0.0012818f, 15369f,0f);
        iconImage.sprite = theMinigame.RealAnti();

        icon.transform.SetParent(this.transform);
        icon.transform.localPosition = new Vector3(0.0012818f, 15369f,0f);
        //baseE.transform.SetParent(this.transform);
        
    }

}
