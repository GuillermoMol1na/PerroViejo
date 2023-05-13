using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antivirus_App : MonoBehaviour
{
     private GameObject antivirusWindow;
    private bool isActive;
    
    void Start()
    {
        antivirusWindow = GameObject.FindGameObjectWithTag("AntivirusWindow");
        isActive = false;
        antivirusWindow.SetActive(isActive);
    }

    public void OpenAntiVirus(){
        FindObjectOfType<Music_Manager>().Play("Track6-Click",false);
        isActive=!isActive;
        antivirusWindow.SetActive(isActive);
    }
    public void CloseAntivirus(){
        FindObjectOfType<Music_Manager>().Play("Track6-Click",false);
        isActive=!isActive;
        antivirusWindow.SetActive(isActive);
    }
}
