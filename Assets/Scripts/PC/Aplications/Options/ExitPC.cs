using UnityEngine;

public class ExitPC : MonoBehaviour
{
    private GameObject OptionsTab;
    private Timer_1 theTimer;
    private bool active;
    void Start()
    {
        OptionsTab = GameObject.FindGameObjectWithTag("OptionsTab");
        theTimer = Timer_1.FindObjectOfType<Timer_1>(true);
        active=false;
        OptionsTab.SetActive(active);
    }
    public void ShoworHideOptions(){
        FindObjectOfType<Music_Manager>().Play("Track6-Click",false);
        if(theTimer.isActive==false){
            active =!active;
        OptionsTab.SetActive(active);
        }
    }
}
