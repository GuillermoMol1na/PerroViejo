using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class InterWind : MonoBehaviour
{
    private Minigame_1 theMinigame;
    private Internet_1_Controller internetController;
    private GameObject link;
    private Vector2 thePosition;
    public TabGroup tabGroup;
    private DownloadLink creation = new DownloadLink();
    private Music_Link musicLink = new Music_Link();
    private Tutorial_1 theTutorial = new Tutorial_1();
    private TMP_FontAsset pixelFont;
    public delegate void CloseRespectiveTab(int childIndex);
    public static event CloseRespectiveTab closeTheTab;
    void Start()
    {
        theMinigame = Minigame_1.FindObjectOfType<Minigame_1>();
        pixelFont= theMinigame.GetFont();
        internetController = Internet_1_Controller.FindObjectOfType<Internet_1_Controller>();
    
        switch(this.transform.name){
            case string a when a.Contains("Tutorial"):
                theTutorial.SetFont(pixelFont);
                this.gameObject.SetActive(true);
                Tutorial();
            break;
            case string b when b.Contains("Website"):
                this.gameObject.SetActive(true);
                MusicWebsite();
            break;
            default:
                this.gameObject.SetActive(true);
                AddTheLinks(theMinigame.Reshuffle());
            break;
        }
        tabGroup.WindowSystem(this.gameObject);
    }
    public void DeleteWind(){
        Debug.Log("Se está eliminando la VENTANA con posición: "+this.transform.GetSiblingIndex() );
        closeTheTab(this.transform.GetSiblingIndex());
        internetController.TabhasbeenRemoved();
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
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
            entry.callback.AddListener( (eventData) => { DeleteWind(); internetController.NewTabwindow("Website"); } );
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
        GameObject icon = new GameObject("Logo");
        Vector2 dimensions = theMinigame.WebsiteLogo().bounds.size;
        icon = musicLink.WebsiteHeader(icon,dimensions,theMinigame.WebsiteLogo());

        //Add the Text
        GameObject antText = new GameObject("WebsiteText");
        antText = musicLink.WebsiteText(antText, pixelFont);
        //Add the DownloadLinks
        float Yposition=0f;
        List<string> listOfRealLinks = theMinigame.GetRealLinks();
        string[] listOfLinks = theMinigame.LinksRandoOrder();
        for(int i=0; i<15;i++){
            GameObject theMusicLink = new GameObject("WebsiteText"+i.ToString());

            theMusicLink = musicLink.CreateMusicLink(theMusicLink, listOfLinks[i]);
            TMP_Text downloadLinkText= theMusicLink.GetComponent<TMP_Text>();

            theMusicLink.transform.SetParent(this.transform);
            theMusicLink.transform.localPosition = new Vector3(-25f,9394f-Yposition);
            //Yposition = Yposition + 3914.75f;
            Yposition = Yposition + 2000f;

            EventTrigger trigger2 = theMusicLink.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            if(listOfRealLinks.Contains(listOfLinks[i])){
                entry.callback.AddListener( (eventData) => { downloadLinkText.color = new Color32(34,214,40,255);} );
            }else{
                entry.callback.AddListener( (eventData) => { downloadLinkText.color = new Color32(181,18,18,255); /*DeleteWind();*/ Debug.Log("GAME OVER");} );
            }
            trigger2.triggers.Add(entry);
        }
        
        icon.transform.SetParent(this.transform);
        antText.transform.SetParent(this.transform);
        icon.transform.localPosition = new Vector3(0.0012818f, 15369f,0f);
        antText.transform.localPosition = new Vector3(-25.00058f, 11236f, 0f);
        
    }
    public void Tutorial(){
        //Declare the Text
        GameObject tutorialT =new GameObject("Tutorial_TextPage");
        tutorialT = theTutorial.TutorialText(tutorialT);
        //Declare the Btton
        GameObject acceptBtnObj = new GameObject("Btn");
        acceptBtnObj = theTutorial.TutorialButton(acceptBtnObj, theMinigame.GetBtn());
        GameObject textBtnObject= new GameObject("Btn_Text");
        textBtnObject = theTutorial.TutorialTextBtn(textBtnObject);

        EventTrigger trigger3 = acceptBtnObj.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener( (eventData) => { DeleteWind(); internetController.NewTabwindow("Window");});
        trigger3.triggers.Add(entry);

        tutorialT.transform.SetParent(this.transform);
        acceptBtnObj.transform.SetParent(this.transform);
        textBtnObject.transform.SetParent(acceptBtnObj.transform);
        tutorialT.transform.localPosition=new Vector3(0f, 4616f, 0);
        acceptBtnObj.transform.localPosition=new Vector3(-216f, -10765f, 0);
    }
    /*void OnEnable(){
        Internet_App.destroyInterWinds += DestroyThis;
    }
    void OnDisable(){
        Internet_App.destroyInterWinds -= DestroyThis;
    }

    void DestroyThis(){
        DeleteWind();
        Debug.Log("Y TODO SE ELIMINÓ Y VIVIMOS ELICES PARA SIEMPRE");
    }*/

}
