using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Email : MonoBehaviour
{
    private string emailName;
    private int emailIndex;
    private GameObject emailWindow;
    private Email_App emailApp;
    public TMP_Text titleEmail;
    public delegate void ShowEmail(string thecontact, string theemail);
    public static event ShowEmail showEmail;
    private Email_Storage emailStorage = new Email_Storage();
    
    void Start(){
        emailName = this.gameObject.name;
        emailIndex = Int16.Parse(emailName);
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        emailApp = emailWindow.GetComponent<Email_App>();
        titleEmail = this.transform.Find("TextContact").gameObject.GetComponent<TMP_Text>();
    }
    public void OpenEmail(){
        emailApp.ShowHideScrollEmail();
        if(showEmail != null){
            showEmail(titleEmail.text, emailStorage.theEmails[emailIndex]);
        }
    }
    public void CloseEmail(){
        emailApp.ShowHideScrollEmail();
    }
}
