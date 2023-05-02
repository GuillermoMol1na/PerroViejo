using UnityEngine;
using TMPro;
public class Timer_2 : MonoBehaviour
{
    private GameObject background;
    private float timeValue = 120;
    private bool isActive;
    public TMP_Text timerText;
    public delegate void GameOver();
    public static event GameOver goToGameOver;
    void Start(){
        timerText.transform.SetAsLastSibling();
        background = this.transform.GetChild(0).gameObject;
        DeactivateTimer();
    }
    void Update()
    {
        if(isActive){
            if(timeValue>0){
                timeValue -= Time.deltaTime;
            }else{
                timeValue = 0;
            }
            DisplayTime(timeValue);
        }
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay=0;
            //Time Over->Game Over
            goToGameOver();
            //Restart time
            //timeValue=90;
            DeactivateTimer();
        }
        if(timeToDisplay < 11){
            timerText.color = new Color32(255,0,0,255);
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        isActive = true;
        //this.gameObject.SetActive(isActive);
        background.SetActive(isActive);
        timerText.enabled = isActive;
    }
    public void DeactivateTimer(){
        isActive = false;
        background.SetActive(isActive);
        timerText.enabled = isActive;
    }
    public bool GetActive(){
        return isActive;
    }
}
