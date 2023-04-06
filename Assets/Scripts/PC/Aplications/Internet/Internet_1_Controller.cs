using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_1_Controller : MonoBehaviour
{
    private GameObject interPanel;
    private GameObject interWindow;
    private GameObject interTab;
    private GameObject theWindow;
    private GameObject theTab;

    void Start()
    {
        interPanel = GameObject.FindGameObjectWithTag("Internet_Minigame_1");
        interWindow = interPanel.transform.Find("Internet_Content").gameObject;
        interTab = interPanel.transform.Find("Tab_Area").gameObject;

        for(int i=0; i<2;i++){
            theWindow= new GameObject("Window"+i.ToString());
            theTab= new GameObject("Tab"+i.ToString());

            theWindow.transform.SetParent(interWindow.transform);
            theTab.transform.SetParent(interTab.transform);
        }
    }
}
