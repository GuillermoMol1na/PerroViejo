using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Email_App : MonoBehaviour
{
    private GameObject emailWindow;
    private GameObject backBtn;
    private GameObject scrollEmail;
    private bool isActive;
    public TMP_Text emailContent;
    public TMP_Text emailUser;
    public TMP_Text emailAppTitle;
    public TMP_Text blueLink;
    
    void Start()
    {
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        backBtn = GameObject.FindGameObjectWithTag("BackBtn");
        scrollEmail = this.transform.Find("Scroll_Email").gameObject;
        isActive = false;
        emailWindow.SetActive(isActive);
        backBtn.SetActive(isActive);
        emailContent.enabled = emailUser.enabled = blueLink.enabled = false;
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
        backBtn.SetActive(!isActive);
    }

    void OnEnable(){
        Email.showEmail += DisplaytheEmail;
    }
    void OnDisable(){
        Email.showEmail -= DisplaytheEmail;
    }

    void DisplaytheEmail(string thecontact, string theemail, string thelink){
        emailContent.enabled = emailUser.enabled = blueLink.enabled= true;

        emailUser.text = thecontact;
        emailContent.text = theemail;
        blueLink.text = thelink;

        emailAppTitle.enabled=false;
        backBtn.SetActive(true);
    }
}
