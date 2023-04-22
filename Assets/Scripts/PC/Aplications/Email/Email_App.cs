using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Email_App : MonoBehaviour
{
    private GameObject emailWindow;
    private GameObject backBtn;
    private GameObject scrollEmail;
    private GameObject obj;
    private RectTransform transObj;
    private Vector2 imageSize;
    private Image imageObj;
    private bool isActive;
    private string displayedContact;
    public TMP_Text emailContent;
    public TMP_Text emailUser;
    public TMP_Text emailAppTitle;
    public TMP_Text blueLink;
    private object[] loadedSprites;
    private Sprite [] thesprites;
    private Sprite thesprite;
    
    void Start()
    {
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        backBtn = GameObject.FindGameObjectWithTag("BackBtn");
        scrollEmail = this.transform.Find("Scroll_Email").gameObject;
        isActive = false;
        emailWindow.SetActive(isActive);
        backBtn.SetActive(isActive);
        emailContent.enabled = emailUser.enabled = blueLink.enabled =  false;
        //Load EmailImages
        loadedSprites = Resources.LoadAll ("Email_Images",typeof(Sprite)) ;
        thesprites = new Sprite[loadedSprites.Length];
        loadedSprites.CopyTo (thesprites,0);
        AddtheImage();
        //Deactivate Image
        obj.SetActive(isActive);
    }

    public void OpenEmails(){
        isActive=true;
        backBtn.SetActive(false);
        emailWindow.SetActive(isActive);
    }
    public void CloseEmails(){
        isActive=false;
        emailWindow.SetActive(isActive);
    }
    public void ShowHideScrollEmail(){
        isActive=!isActive;
        scrollEmail.SetActive(isActive);
        emailAppTitle.enabled=isActive;
        emailUser.enabled=!isActive;
        blueLink.enabled=isActive;
        backBtn.SetActive(!isActive);
    }
    public void HideImage(){
        //Obj
        obj.SetActive(false);
    }
    void OnEnable(){
        Email.showEmail += DisplaytheEmail;
    }
    void OnDisable(){
        Email.showEmail -= DisplaytheEmail;
    }

    void DisplaytheEmail(string thecontact, string theemail, string thelink){
        displayedContact = thecontact;
        emailContent.enabled = emailUser.enabled = true;

        emailUser.text = thecontact;
        emailContent.text = theemail;
        if(!string.IsNullOrEmpty(thelink)){
            AddtriggerToLink(blueLink);
            blueLink.enabled=true;
            blueLink.text = thelink;
        }
        emailAppTitle.enabled=false;
        backBtn.SetActive(true);

        
    }
    public void AddtriggerToLink(TMP_Text blueL){
        EventTrigger trigger3 = blueL.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener( (eventData) => { Debug.Log("BOTÓN OPRIMIDO"); ModifySprite(); });
        trigger3.triggers.Add(entry);
    }
    public void AddtheImage(){
        obj = new GameObject("Image to Show");
        Transform selectedParent = this.transform.GetChild(0);
        transObj = obj.AddComponent<RectTransform>();
        imageObj = obj.AddComponent<Image>();
        
        obj.transform.SetParent(selectedParent);
        obj.transform.localPosition = new Vector3(0f,-2485f,0f);
    }
    public void ModifySprite(){
                //Show Image
            switch(displayedContact){
                case string a when a.Contains("Hijo"):
                    thesprite = thesprites[0];
                    AdjustSizeSprite();
                    obj.SetActive(true);
                break;
                case string b when b.Contains("Seguro"):
                    thesprite = thesprites[1];
                    AdjustSizeSprite();
                    obj.SetActive(true);
                break;
                case string c when c.Contains("Gerardo"):
                    thesprite = thesprites[2];
                    AdjustSizeSprite();
                    obj.SetActive(true);
                break;
            }
            emailContent.enabled  = blueLink.enabled= false;
    }
    public void AdjustSizeSprite(){
        imageSize = thesprite.bounds.size*2f;
        transObj.sizeDelta = imageSize;
        imageObj.sprite = thesprite;
    }
}
