using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Email : MonoBehaviour
{
    private string emailName;
    private int emailIndex;
    private GameObject emailWindow;
    private Email_App emailApp;
    public TMP_Text titleEmail;
    public delegate void ShowEmail(string thecontact, string theemail, string thelink, bool read);
    public static event ShowEmail showEmail;
    private string theemailtoDisplay;
    private string theLinkAttatched;
    private Image icon;
    private bool alreadyRead;
    void Start(){
        emailName = this.gameObject.name;
        emailIndex = Int16.Parse(emailName);
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        emailApp = emailWindow.GetComponent<Email_App>();
        titleEmail = this.transform.Find("TextContact").gameObject.GetComponent<TMP_Text>();
        icon = this.transform.Find("Read_or_Not_Image").GetComponent<Image>();
        alreadyRead=false;
    }
    public void OpenEmail(){
        emailApp.ShowHideScrollEmail();
        if(showEmail != null){
            showEmail(titleEmail.text, theemailtoDisplay, theLinkAttatched, alreadyRead);
        }
        icon.sprite = Resources.Load<Sprite>("UIIcons_16");
        if(alreadyRead == false){
            alreadyRead = true;
        }
    }
    public void CloseEmail(){
        emailApp.ShowHideScrollEmail();
    }
    public void SetEmail(string theText, string linkA){
        theemailtoDisplay= theText;
        theLinkAttatched = linkA;
    }
}
