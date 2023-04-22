using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_App : MonoBehaviour
{
 private GameObject internetWindow;
 private GameObject miniGame_1;
 private GameObject internetContent;
 private TabGroup theTabGroup;
 private Internet_1_Controller internetController;
 private Timer_1 theTimer;
 public delegate void EmptyTabLists();
 public static event EmptyTabLists emptyLists;
 private bool isActive;
    
    void Start()
    {
        internetWindow = GameObject.FindGameObjectWithTag("InternetWindow");
        miniGame_1 = GameObject.FindGameObjectWithTag("Internet_Minigame_1");
        internetContent = GameObject.FindGameObjectWithTag("Internet_Content");
        theTimer = Timer_1.FindObjectOfType<Timer_1>(true);
        theTabGroup = TabGroup.FindObjectOfType<TabGroup>();
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
        internetController.NewTabwindow("Tutorial");
        break;
        }
    }
    public void CloseInternet(){
        //emptyLists();
        isActive=!isActive;
        internetWindow.SetActive(isActive);
    }
    public void CloseMinigame(){
        if(theTimer.GetActive()==false){
            emptyLists();
            isActive=!isActive;
            miniGame_1.SetActive(isActive);
            //destroyInterWinds();
            DestroyAll();
        }
    }
    public void DestroyAll(){
         foreach (Transform child in internetContent.transform) {
            Destroy(child.gameObject);
         }
         foreach (Transform child in theTabGroup.transform) {
            Destroy(child.gameObject);
         }
    }
    
}
