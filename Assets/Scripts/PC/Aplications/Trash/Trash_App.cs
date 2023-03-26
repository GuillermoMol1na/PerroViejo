using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_App : MonoBehaviour
{
   private GameObject trashWindow;
    private bool isActive;
    
    void Start()
    {
        trashWindow = GameObject.FindGameObjectWithTag("TrashWindow");
        isActive = false;
        trashWindow.SetActive(isActive);
    }

    public void OpenTrash(){
        isActive=!isActive;
        trashWindow.SetActive(isActive);
    }
    public void CloseTrash(){
        isActive=!isActive;
        trashWindow.SetActive(isActive);
    }
}
