using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Email_App : MonoBehaviour
{
    private GameObject emailWindow;
    private GameObject backBtn;
    private bool isActive;
    public TMP_Text emailContent;
    public TMP_Text emailUser;
    public TMP_Text emailAppTitle;
    
    void Start()
    {
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        backBtn = GameObject.FindGameObjectWithTag("BackBtn");
        isActive = false;
        emailWindow.SetActive(isActive);
        backBtn.SetActive(isActive);
        emailContent.enabled = emailUser.enabled = false;
    }

    public void OpenEmails(){
        isActive=!isActive;
        emailWindow.SetActive(isActive);
    }
    public void CloseEmails(){
        isActive=!isActive;
        emailWindow.SetActive(isActive);
    }

    void OnEnable(){
        Email.showEmail += DisplaytheEmail;
    }
    void OnDisable(){
        Email.showEmail -= DisplaytheEmail;
    }

    void DisplaytheEmail(string thecontact){
        emailContent.enabled = emailUser.enabled =true;

        emailUser.text = thecontact;

        emailAppTitle.enabled=false;
        backBtn.SetActive(true);
    }
}
