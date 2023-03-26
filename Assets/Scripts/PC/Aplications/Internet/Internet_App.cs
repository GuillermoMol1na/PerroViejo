using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_App : MonoBehaviour
{
 private GameObject internetWindow;
    private bool isActive;
    
    void Start()
    {
        internetWindow = GameObject.FindGameObjectWithTag("InternetWindow");
        isActive = false;
        internetWindow.SetActive(isActive);
    }

    public void OpenInternet(){
        isActive=!isActive;
        internetWindow.SetActive(isActive);
    }
    public void CloseInternet(){
        isActive=!isActive;
        internetWindow.SetActive(isActive);
    }
}
