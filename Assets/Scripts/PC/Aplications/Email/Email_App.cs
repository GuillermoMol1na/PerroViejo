using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Email_App : MonoBehaviour
{
    private GameObject emailWindow;
    private bool isActive;
    
    void Start()
    {
        emailWindow = GameObject.FindGameObjectWithTag("EmailWindow");
        isActive = false;
        emailWindow.SetActive(isActive);
    }

    public void OpenEmails(){
        isActive=!isActive;
        emailWindow.SetActive(isActive);
    }
    public void CloseEmails(){
        isActive=!isActive;
        emailWindow.SetActive(isActive);
    }
}
