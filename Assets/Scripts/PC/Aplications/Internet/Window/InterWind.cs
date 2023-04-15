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
        
        if(this.transform.name.Contains("Website")){
            this.gameObject.SetActive(true);
            MusicWebsite();
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
            entry.callback.AddListener( (eventData) => { internetController.NewTabwindow("Website"); DeleteWind();} );
        }
        trigger.triggers.Add(entry);
        //Setting thew parent
        link.transform.SetParent(this.transform);
        link.transform.localPosition = thePosition;
        }
        GameObject textObject = creation.PageText(pixelFont);
        textObject.transform.SetParent(this.transform);
        textObject.transform.localPosition=new Vector3(526.72f, 13035f, 0);

    }
    public void MusicWebsite(){
        //GameObject baseE = new GameObject("Mistake_Window");
        GameObject icon = new GameObject("Logo");
        RectTransform transicon= icon.AddComponent<RectTransform>();
        Image iconImage = icon.AddComponent<Image>();
        Vector2 dimensions = theMinigame.WebsiteLogo().bounds.size;
        transicon.sizeDelta = dimensions;
        iconImage.sprite = theMinigame.WebsiteLogo();
        //Add the Text
        GameObject antText = new GameObject("WebsiteText");
        TMP_Text websiteText = antText.AddComponent<TextMeshProUGUI>();
        RectTransform transText= antText.GetComponent<RectTransform>();
        Vector2 thepos = new Vector2(950.37f, 62.93f);
        transText.sizeDelta = thepos;
        websiteText.font = pixelFont;
        websiteText.fontSize = 30f;
        websiteText.color = new Color32(0,0,0,255);
        websiteText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopJustified;
        websiteText.text = "Descarga todas las canciones que reflejen tu actitud:";
        //Add the DownloadLinks
        float Yposition=0f;
        for(int i=0; i<5;i++){
            GameObject theMusicLink = new GameObject("WebsiteText"+i.ToString());
            TMP_Text downloadLinkText = theMusicLink.AddComponent<TextMeshProUGUI>();
            RectTransform transDownload = theMusicLink.GetComponent<RectTransform>();
            transDownload.sizeDelta = new Vector2(1103.42f, 63.43f);
            downloadLinkText.font = pixelFont;
            downloadLinkText.fontSize = 50f;
            downloadLinkText.color = new Color32(63,102,183,255);
            downloadLinkText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopJustified;
            downloadLinkText.text= i.ToString()+"hamilton008796465746757394234532.mp3";            
            theMusicLink.transform.SetParent(this.transform);
            theMusicLink.transform.localPosition = new Vector3(-25f,5353.75f-Yposition);
            Yposition = Yposition + 3914.75f;

            EventTrigger trigger2 = theMusicLink.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            if(2 == i){
                entry.callback.AddListener( (eventData) => { downloadLinkText.color = new Color32(34,214,40,255);} );
            }else{
                entry.callback.AddListener( (eventData) => { downloadLinkText.color = new Color32(181,18,18,255); Debug.Log("GAME OVER");} );
            }
            trigger2.triggers.Add(entry);
        }
        
        icon.transform.SetParent(this.transform);
        antText.transform.SetParent(this.transform);
        icon.transform.localPosition = new Vector3(0.0012818f, 15369f,0f);
        antText.transform.localPosition = new Vector3(-25.00058f, 7471.547f, 0f);
        
    }

}
