using UnityEngine;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    private GameObject child;
    public float timeValue = 20;
    public TMP_Text timerText;
    void Start(){
        timerText.transform.SetAsLastSibling();
        child = this.transform.GetChild(0).gameObject;
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
}
