using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPC : MonoBehaviour
{
    private GameObject OptionsTab;
    private bool active;
    void Start()
    {
        OptionsTab = GameObject.FindGameObjectWithTag("OptionsTab");
        active=false;
        OptionsTab.SetActive(active);
    }
    public void ShoworHideOptions(){
        Debug.Log("DEBRÍA MOSTRARSEEEE");
        active =!active;
        OptionsTab.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
