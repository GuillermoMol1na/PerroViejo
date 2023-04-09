using UnityEngine;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    public float timeValue = 20;
    public TMP_Text timerText;
    void Start(){
        timerText.transform.SetAsLastSibling();
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
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        this.gameObject.SetActive(true);
    }
    public void DeactivateTimer(){
        this.gameObject.SetActive(false);
    }
}
