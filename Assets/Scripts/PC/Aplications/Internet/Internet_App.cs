using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_App : MonoBehaviour
{
 private GameObject internetWindow;
 private GameObject miniGame_1;
    private bool isActive;
    
    void Start()
    {
        internetWindow = GameObject.FindGameObjectWithTag("InternetWindow");
        miniGame_1 = GameObject.FindGameObjectWithTag("Internet_Minigame_1");
        isActive = false;
        internetWindow.SetActive(isActive);
        miniGame_1.SetActive(isActive);
    }

    public void OpenInternet(){
        switch(PlayerPrefs.GetInt("day")){
        case 0:
        isActive=!isActive;
        internetWindow.SetActive(isActive);
        break;
        case 1:
        isActive=!isActive;
        miniGame_1.SetActive(isActive);
        break;
        }

    }
    public void CloseInternet(){
        isActive=!isActive;
        internetWindow.SetActive(isActive);
    }
}
