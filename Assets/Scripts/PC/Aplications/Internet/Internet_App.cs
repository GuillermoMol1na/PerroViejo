using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_App : MonoBehaviour
{
 private GameObject internetWindow;
 private GameObject miniGame_1;
 private Internet_1_Controller internetController;
    private bool isActive;
    
    void Start()
    {
        internetWindow = GameObject.FindGameObjectWithTag("InternetWindow");
        miniGame_1 = GameObject.FindGameObjectWithTag("Internet_Minigame_1");
        internetController = Internet_1_Controller.FindObjectOfType<Internet_1_Controller>();
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
        internetController.NewTabwindow();
        break;
        }

    }
    public void CloseInternet(){
        isActive=!isActive;
        internetWindow.SetActive(isActive);
    }
    public void CloseMinigame(){
        isActive=!isActive;
        miniGame_1.SetActive(isActive);
    }
}
