using UnityEngine;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    private GameObject child;
    private GameObject[] strikes = new GameObject[3];
    public float timeValue = 20;
    private int strikeCounter=0;
    public TMP_Text timerText;
    void Start(){
        timerText.transform.SetAsLastSibling();
        child = this.transform.GetChild(3).gameObject;
        for(int i =0;i<3;i++){
            strikes[i] = this.transform.GetChild(i).gameObject;
            strikes[i].SetActive(false);
            Debug.Log("El objeto es: "+strikes[i].name);
        }
        DeactivateTimer();
    }
    void Update()
    {
        if(timeValue>0){
            timeValue -= Time.deltaTime;
        }else{
            timeValue = 0;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay=0;
            DeactivateTimer();
        }
        if(timeToDisplay < 15){
            timerText.color = new Color32(255,0,0,255);
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        child.SetActive(true);
        this.gameObject.SetActive(true);
    }
    public void DeactivateTimer(){
        child.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void SetStrike(){
        strikes[strikeCounter].SetActive(true);
        strikeCounter=strikeCounter+1;
    }
    void OnEnable(){
        InterWind.activateTimer += ActivateTimer;
        InterWind.setTheStrike += SetStrike;
    }
    void OnDisable(){
        InterWind.setTheStrike -= SetStrike;
    }

}
